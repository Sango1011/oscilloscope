#include <24FV16KM202.h>
#DEVICE ADC=8

#use delay(clock = 32MHZ, internal = 8MHZ)
#USE RS232(UART2, BAUD = 9600, PARITY = N, BITS = 8, STOP = 1, TIMEOUT = 500))

#include <math.h>
#include <stdlib.h>
#include <stdio.h>

#FUSES NOWDT          //No Watch Dog Timer
#FUSES CKSFSM         //Clock Switching is enabled, fail Safe clock monitor is enabled
#FUSES NOBROWNOUT     //No brownout reset
#FUSES BORV_LOW       //Brown-out Reset set to lowest voltage
#use fast_io(B)
#FUSES FRC_PLL
#fuses HS
#FUSES NOPROTECT

#define LCD_ENABLE_PIN  PIN_B2
#define LCD_RS_PIN      PIN_B8
#define LCD_RW_PIN      PIN_B9
#define LCD_DATA4       PIN_B12
#define LCD_DATA5       PIN_B13
#define LCD_DATA6       PIN_B14
#define LCD_DATA7       PIN_B15

#include <LCD.C>
#include "kbd_mod.c"

#define NUM 200
#define T 3200
#define D 1600

int timer;  //used for the dsired frequency for slower sampling
int1 data_flag = 0, trigger_flag = 0, timer_flag = 0, state_flag = 0; //global flags
char key;  //uart recieved character
unsigned int16 samples [NUM];  //array to store samples
int16 cur = 0;       //used to track the index of the stored samples
int8 state = 0, Tstate = 0;      //used to keep track of the state
int trigger = 105;   //triger value defautl is 2.5V
int8 freq = 4;       //sampling frequency defalut is ~275K
unsigned int16 sample = 0; //temp stroage samples value until trigger is met
int duty = 50, period = 5000; //ccp duty and period defauls of 50% and 5K

#INT_RDA2
void isr_uart()   // recieving from the GUI or keyboard
{
   key = getc(); data_flag = 1;   // get the character recieved
   //printf("%c U ", key);
}

#INT_TIMER1
void  timer1_isr(void)  // used for sampling
{    
   output_toggle (PIN_A2);     //add additional tick to get to intterupt faster
   set_timer1(timer + get_timer1());  //since the time isn't equal to overflow
   timer_flag = 1;
}

#INT_EXT0
void isr_ext()
{
   disable_interrupts(INT_TIMER1);
   key = kbd_getc();  data_flag = 1;   //keypad interrupt
}

void lcd_display(char c)      //function to dislay a string on the LCD
{
   disable_interrupts(INT_EXT0);  set_pullup(false);
   lcd_putc(c);  kbd_init();
   clear_interrupt(INT_EXT0);  enable_interrupts(INT_EXT0);
}

void freq_set()
{ 
   int x;
   switch (freq)  //set timer value appropriately for the frequency and display
   {
      case 1: x = 59728; printf(lcd_display,"\f2,755 Hz"); break;    
      case 2: x = 64607; printf(lcd_display,"\f17,218 Hz"); break;
      case 3: x = 65304; printf(lcd_display,"\f68,871 Hz"); break;
      case 4: x = 0; printf(lcd_display,"\f275,482 Hz"); break; 
      default:  break;
   }
   timer = x;     //pass value to variable
}

void data_decoder()
{
      switch (key)
      {
         case '*':         //start sampling
            if (freq == 4)    //fastest sampling state
            {
               state = 1; freq_set(); break;
            }
            else     //slower sampling state
            {
               state = 2; freq_set(); break;
            }
         case 'a': freq = 4; freq_set(); break;   //freq ~ 275K
         case 'b': freq = 3; freq_set(); break;   //freq ~ 69K
         case 'c': freq = 2; freq_set(); break;   //freq ~ 17K
         case 'd': freq = 1; freq_set(); break;   //freq ~ 3k  
         case '2':  printf("+");//increase sampling frequency
            if (freq == 1){
                 freq = 2; freq_set();}
            else if (freq == 2){
                 freq = 3; freq_set();}
            else if (freq == 3){
                 freq = 4; freq_set();}
            else if (freq == 4){
                 freq = 4; freq_set();} 
             break;
         case '3':  printf("_"); //decrease sampling freqency
            if (freq == 1){
                freq = 1;  freq_set();}
            else if (freq == 2){
                freq = 1; freq_set();}
            else if (freq == 3){
                freq = 2; freq_set();}
            else if (freq == 4){
                freq = 3; freq_set();} 
            break;         
         default:  break;
      }
}

void main()
{    
   // Setup ADC
   setup_adc(ADC_CLOCK_DIV_2 | ADC_TAD_MUL_2);   
   setup_adc_ports(sAN0 | VSS_VDD); 
   // Setup Timer 
   setup_timer1(T1_INTERNAL | T1_DIV_BY_1); 

   //setup serial interrupt
   enable_interrupts(INT_RDA2);
   enable_interrupts(INTR_GLOBAL);
   
   lcd_init();
   printf(lcd_display,"Sarah Ngo");
   
   //setup keypad interrupt
   kbd_init();
   ext_int_edge(L_TO_H);  clear_interrupt(INT_EXT0);
   enable_interrupts(INT_EXT0);  enable_interrupts(INTR_GLOBAL);
   
   //setup default ccp 5K with 50% duty cycle
   setup_ccp5(CCP_PWM | CCP_DIV_BY_1);
   set_timer_period_ccp5(T);
   set_pwm5_duty(D);
         
   while(true)
   {
////////////////////////////////////////////////////////////////////////STATE 0
      while (state == 0)
      {
         
         if (data_flag)
         {
            data_flag = 0;
            if (key == '#')      //stop and reset
            {
               state = 3; printf("Q"); break;
            }
            else if (key == 'z')    //trigger value setting
            {
               state = 4; Tstate = 0; state_flag = 1; break; 
            }
            else if (key == 'D')    //duty set state
            {
               state = 5; Tstate = 0; state_flag = 1; break;
            }
            else if (key == 'F')    //period set state
            {
               state = 6; Tstate = 0; state_flag = 1; break;
            }
            else
            {
               data_decoder();  //decode incoming data
            }
            //state = Tstate;
         }
      }
////////////////////////////////////////////////////////////////////////STATE 1            
      while (state == 1)  //fastest sampling
       {
            //check sample against trigger value on rising edge
            for (int i = 0; i < NUM; i++)
            {
               sample = read_adc();
               if (sample < trigger)
               {
                  trigger_flag = 1;    //value is below trigger
               }
               else if (sample >= trigger && trigger_flag == 1)   
               {     //value equal or above trigger
                   trigger_flag = 0; break;
               }
            }
            
            samples[0] = sample;    //store the last value           
            //collect and store 200 samples
            for (cur = 1; cur < NUM; cur++)
            {
               samples[cur] = read_adc();
            }
            //send the 200 samples to the gui
            printf("!");
            for (int j = 0; j < NUM; j++)
            {
               printf("%u,", samples[j]);
            }
            printf("^");
            delay_ms(100);
        
         if (data_flag)    //incoming data
         {
            if (key == '#')      //stop and reset
            {
               state = 3; printf("Q"); break;
            }
            else if (key == 'z')   //trigger value setting
            {
               state = 4; Tstate = 1; state_flag = 1; break;
            }
            else if (key == 'D') //set duty
            {
               state = 5; Tstate = 1; duty = 0; state_flag = 1; break;
            }
            else if (key == 'F')    //set period
            {
               state = 6; Tstate = 1; period = 0; state_flag = 1; break;
            }
            else
            {
               data_decoder();   //decode the data
               //check to see the state to go to
               if (freq == 4)
               {
                  state = 1; freq_set(); break; //fastest
               }
               else
               {
                  state = 2; freq_set(); break; //slower
               }
            }
            data_flag = 0;
         }
      }
////////////////////////////////////////////////////////////////////////STATE 2      
      while (state == 2)   //slower sampling
      {  
            //initialize timer for the apprepriate frequency
            clear_interrupt(INT_TIMER1);    
            enable_interrupts(INT_TIMER1);
            enable_interrupts(GLOBAL);
            set_timer1(timer);
            int i = 0;
            while (i < NUM) //check sample against trigger value on rising edge
            {
                  if (timer_flag == 1)
                  {
                     timer_flag = 0; i++;
                     sample = read_adc();
                     if (sample < trigger)
                     {
                        trigger_flag = 1;    //sammple is below trigger
                     }
                     else if (sample >= trigger && trigger_flag == 1)
                     {
                         trigger_flag = 0; break;   //sample is equal or above
                     }              
                  }
            }
               
               samples[0] = sample; //store the value
               cur = 1;
               //collect and store 200 samples
               while (cur < NUM)
               {
                  if(timer_flag)
                  {
                     samples[cur] = read_adc();
                     timer_flag = 0; cur++;
                  }
               }
               disable_interrupts(INT_TIMER1);
               //send the 200 samples to the gui
               printf("!");
               for (int j = 0; j < NUM; j++)
               {
                  printf("%u,", samples[j]);
               }
               printf("^");
               delay_ms(100);
        
         if (data_flag) //incoming data
         {
            disable_interrupts(INT_TIMER1); data_flag = 0; 
            if (key == '#')   //stop and reset
            {
               state = 3; printf("Q"); break;
            }
            else if (key == 'z')   //trigger value setting
            {
               state = 4; Tstate = 2; state_flag = 1; break;
            }
            else if (key == 'D')
            {
               state = 5; Tstate = 2; duty = 0; state_flag = 1; break;
            }
            else if (key == 'F')
            {
               state = 6; Tstate = 2; period = 0; state_flag = 1; break;
            }
            else
            {
               data_decoder();      //decode the inoming 
               if (freq == 4)
               {
                  state = 1; freq_set(); break; //go to fastest sampling state
               }
               else
               {
                  state = 2; freq_set(); break; //go to slower sampling state
               }
            }
         }
      }
////////////////////////////////////////////////////////////////////////STATE 3      
      while (state == 3)   //reset state
      {  //reset to default
         trigger = 105; freq = 4;   
         period = 5000; duty = 50;
         setup_ccp5(CCP_PWM | CCP_DIV_BY_1);
         set_timer_period_ccp5(T);
         set_pwm5_duty(D);
         printf(lcd_display,"\f");
         //clear the samples
         for (int k = 0; k < NUM; k++)
         {
            samples[k] = 0;
         }
         state = 0; break;
      } 
///////////////////////////////////////////////?////////////////////////STATE 4
      while (state == 4)   //setting of the trigger value
      {
         if (state_flag)
         {  //send flag to start transmission
            printf("z"); state_flag = 0;
         }
         int triggerT;
         if (data_flag)
         {
            data_flag = 0;
            if (key >= '0' && key <= '9')    //update the trigger value
            {
               key = key - '0';
               triggerT = triggerT*10 + key;
            }
            else if (key == 'y'){      //done sending trigger
               state = Tstate;        //go back to previous state
               trigger = triggerT;     //pass value to varaiable
               triggerT = 0;     //reset value
            }
            else
            ;     //do nothing
         }
      }
////////////////////////////////////////////////////////////////////////STATE 5
      while (state == 5)   //setting duty value for ccp
      {  
         if (state_flag)
         {    //send flag to start transmission
            printf("D"); state_flag = 0;
         }
         int dutyT, periodT;
         if (data_flag)
         {
            data_flag = 0;
            if (key >= '0' && key <= '9')    //update the value
            {
               key = key - '0';
               dutyT = dutyT*10 + key;
            }
            else if (key == 'y'){      //done sending value
               duty = dutyT;
               //setup ccp
               if (period <= 250)
               {  
                  periodT = 250000/period;     //convert
                  int temp = periodT/100;
                  dutyT = (100 - duty)*temp;     //convert
                  setup_ccp5(CCP_PWM | CCP_DIV_BY_64);
                  set_timer_period_ccp5(periodT);
                  set_pwm5_duty(dutyT);
               }
               else
               {
                  periodT = 16000000/period;     //convert
                  int temp = periodT/100;
                  dutyT = (100 - duty)*temp;     //convert
                  setup_ccp5(CCP_PWM | CCP_DIV_BY_1);
                  set_timer_period_ccp5(periodT);
                  set_pwm5_duty(dutyT);
               }
               state = Tstate;        //go back to previous state
               periodT = 0; dutyT = 0; //reset values             
            }
            else
            ;     //do nothing
         }
      }
////////////////////////////////////////////////////////////////////////STATE 6
      while (state == 6)   //setting frequency value for ccp
      {
         if (state_flag)
         {  //send flag to start transmission
            printf("F"); state_flag = 0;
         }
         int periodT, dutyT;
         if (data_flag)
         {
            data_flag = 0;
            if (key >= '0' && key <= '9')    //update the  value
            {
               key = key - '0';
               periodT = periodT*10 + key;
            }
            else if (key == 'y'){      //done sending 
               //state = Tstate;        //go back to previous state
               period = periodT;
               if (period <= 250)
               {
                  periodT = 250000/period;     //convert
                  int temp = periodT/100;
                  dutyT = (100 - duty)*temp;     //convert
                  setup_ccp5(CCP_PWM | CCP_DIV_BY_64);   //resetup ccp
                  set_timer_period_ccp5(periodT);
                  set_pwm5_duty(dutyT);
               }
               else
               {
                  periodT = 16000000/period;     //convert
                  int temp = periodT/100;
                  dutyT = (100 - duty)*temp;     //convert
                  setup_ccp5(CCP_PWM | CCP_DIV_BY_1);   //resetup ccp
                  set_timer_period_ccp5(periodT);
                  set_pwm5_duty(dutyT);
               }
               state = Tstate;
               periodT = 0; dutyT = 0;    //reset values
            }
            else
            ;     //do nothing
         }
      }
   }
}

