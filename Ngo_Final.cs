using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
//using System.IO;
using System.Threading;
//using static System.String;
using ZedGraph;
//using System.Globalization;
 

namespace Ngo_Oscillocope
{
    public partial class Ngo_Final : Form
    {
        private double CON = 0.02381;       //used to convert samples to volts with 210 highest value
        private int[] in_array = new int[200];  //used for graphing input data
        private double[] graph = new double[200];  //for the y values of the time plot
        private string in_string;       //incoming string of input data
        private string rxString;        //holds the incoming data
        private string[] input;         //used as a temp array while converting the samples
        private double delta_f = 1, delta_t = 1;    //holds the value to calculte appropriate x-values
        private double[] result = new double[200];  //holds y values of the dft plot
        private bool scale_flag = false;    //flag to know when the button to toggle magnitude from linear to dB
        private double[] phase = new double[200];   //holds y values of the phase plot
        private double y_min, y_max;    //hold the y max and min to scale the axis as needed
        private string freq;    //used to update the freq value in the quick measure
        private int duty_cycle = 50, function = 5000;   //used for the function gernerator values
        

        public Ngo_Final()
        {
            InitializeComponent();
        }

        public void CreateChart(ZedGraphControl zedGraphControl1)
        {       //time plot
            //Declare a new GraphPane object
            GraphPane myPane = zedGraphControl1.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "Ngo Oscilloscope";
            myPane.XAxis.Title.Text = "Time (seconds)";
            myPane.YAxis.Title.Text = "Amplitude (V)";
            //myPane.Y2Axis.Title.Text = "Output Amplitude";

            // Make up some data points based on the data
            PointPairList list = new PointPairList();
            PointPairList list2 = new PointPairList();

            //create the data points to be plotted
            for (int i = 0; i < graph.Length - 1; i++)
            {
                double x = (double)i*delta_t;  //convert to time
                double y = graph[i];      //value in volts
                double y2 = triggerBar.Value;
                list.Add(x, y);         //add points to the list
                list2.Add(x, y2);
            }

            // Note: All data being plotted by zedgraph have to be “Double” format.
            // Data should be saved as a PointPairList before plotting.
            // So “List.Add()” method should be called after you define or
            // change the data that are plotted.
            // Generate a red curve with diamond symbols, and "Alpha" in the legend
            LineItem myCurve = myPane.AddCurve("Signal", list, Color.Red, SymbolType.Diamond);
            // Fill the symbols with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Generate a blue curve with circle symbols, and "Beta" in the legend
            myCurve = myPane.AddCurve("Trigger", list2, Color.Blue, SymbolType.Circle);
            // Fill the symbols with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
            myCurve.IsY2Axis = true;
            //Some enhancing setting:
            // Show the x axis grid
            myPane.XAxis.MajorGrid.IsVisible = true;
            // Make the Y axis scale red
            myPane.YAxis.Scale.FontSpec.FontColor = Color.Red;
            myPane.YAxis.Title.FontSpec.FontColor = Color.Red;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane.YAxis.Scale.Align = AlignP.Inside;
            // Manually set the axis range
            myPane.YAxis.Scale.Min = y_min;
            myPane.YAxis.Scale.Max = y_max;
            myPane.Y2Axis.Scale.Min = 0;
            myPane.Y2Axis.Scale.Max = 210;
            // Enable the Y2 axis display
            //myPane.Y2Axis.IsVisible = true;
            // Make the Y2 axis scale blue
            myPane.Y2Axis.Scale.FontSpec.FontColor = Color.Blue;
            myPane.Y2Axis.Title.FontSpec.FontColor = Color.Blue;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            myPane.Y2Axis.MajorTic.IsOpposite = false;
            myPane.Y2Axis.MinorTic.IsOpposite = false;
            // Display the Y2 axis grid lines
            myPane.Y2Axis.MajorGrid.IsVisible = false;
            // Align the Y2 axis labels so they are flush to the axis
            myPane.Y2Axis.Scale.Align = AlignP.Inside;
            // Fill the axis background with a gradient
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
            // Calculate the Axis Scale Ranges
            //Note: ZedGraphControl.AxisChange() command keep checking and
            // adjusting the display axis setting according to the List changes.
            zedGraphControl1.AxisChange();
        }
        //private void zedGraphControl2_Load(object sender, EventArgs e)
        public void CreateChart2(ZedGraphControl zedGraphControl2)
        {       //dft magnitude plot
            //Declare a new GraphPane object
            GraphPane myPane2 = zedGraphControl2.GraphPane;

            // Set the titles and axis labels
            myPane2.Title.Text = "DFT Magnitude";
            myPane2.XAxis.Title.Text = "Frequency (Hz)";
            myPane2.YAxis.Title.Text = "Amplitude";
            //myPane2.Y2Axis.Title.Text = "Output Amplitude";

            // Make up some data points based on the data
            PointPairList list3 = new PointPairList();
            PointPairList list4 = new PointPairList();

            //create the data points to be plotted
            for (int i = 0; i < result.Length - 1; i++)
            {
                double x = ((double)i-100) * delta_f;   //convert to frequency
                double y = result[i];     //magnitude value
                //double y2 = triggerBar.Value;
                list3.Add(x, y);         //add points to the list
                //list4.Add(x, y2);
            }

            // Note: All data being plotted by zedgraph have to be “Double” format.
            // Data should be saved as a PointPairList before plotting.
            // So “List.Add()” method should be called after you define or
            // change the data that are plotted.
            // Generate a red curve with diamond symbols, and "Alpha" in the legend
            LineItem myCurve2 = myPane2.AddCurve("Magnitude", list3, Color.Red, SymbolType.Diamond);
            // Fill the symbols with white
            myCurve2.Symbol.Fill = new Fill(Color.White);
            // Generate a blue curve with circle symbols, and "Beta" in the legend
            //myCurve = myPane.AddCurve("Trigger", list2, Color.Blue, SymbolType.Circle);
            // Fill the symbols with white
            myCurve2.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
            myCurve2.IsY2Axis = true;
            //Some enhancing setting:
            // Show the x axis grid
            myPane2.XAxis.MajorGrid.IsVisible = true;
            // Make the Y axis scale red
            myPane2.YAxis.Scale.FontSpec.FontColor = Color.Red;
            myPane2.YAxis.Title.FontSpec.FontColor = Color.Red;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane2.YAxis.MajorTic.IsOpposite = false;
            myPane2.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane2.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane2.YAxis.Scale.Align = AlignP.Inside;
            // Manually set the axis range
            myPane2.YAxis.Scale.Min = 0;
            //myPane2.YAxis.Scale.Max = DFT_Max;
            //myPane2.Y2Axis.Scale.Min = 0;
            //myPane2.Y2Axis.Scale.Max = 226;
            // Enable the Y2 axis display
            //myPane.Y2Axis.IsVisible = true;
            // Make the Y2 axis scale blue
            myPane2.Y2Axis.Scale.FontSpec.FontColor = Color.Blue;
            myPane2.Y2Axis.Title.FontSpec.FontColor = Color.Blue;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            myPane2.Y2Axis.MajorTic.IsOpposite = false;
            myPane2.Y2Axis.MinorTic.IsOpposite = false;
            // Display the Y2 axis grid lines
            myPane2.Y2Axis.MajorGrid.IsVisible = false;
            // Align the Y2 axis labels so they are flush to the axis
            myPane2.Y2Axis.Scale.Align = AlignP.Inside;
            // Fill the axis background with a gradient
            myPane2.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
            // Calculate the Axis Scale Ranges
            //Note: ZedGraphControl.AxisChange() command keep checking and
            // adjusting the display axis setting according to the List changes.
            zedGraphControl2.AxisChange();
        }
        public void CreateChart3(ZedGraphControl zedGraphControl3)
        {       //phase plot graph
            //Declare a new GraphPane object
            GraphPane myPane3 = zedGraphControl3.GraphPane;

            // Set the titles and axis labels
            myPane3.Title.Text = "DFT Phase";
            myPane3.XAxis.Title.Text = "Frequency (Hz)";
            myPane3.YAxis.Title.Text = "Degrees";
            //myPane2.Y2Axis.Title.Text = "Output Amplitude";

            // Make up some data points based on the data
            PointPairList list5 = new PointPairList();
            PointPairList list6 = new PointPairList();

            //create the data points to be plotted
            for (int i = 0; i < result.Length - 1; i++)
            {
                double x = (double)i * delta_f; //convert to frequency
                double y = phase[i];      //phase value
                //double y2 = triggerBar.Value;
                list5.Add(x, y);         //add points to the list
                //list4.Add(x, y2);
            }

            // Note: All data being plotted by zedgraph have to be “Double” format.
            // Data should be saved as a PointPairList before plotting.
            // So “List.Add()” method should be called after you define or
            // change the data that are plotted.
            // Generate a red curve with diamond symbols, and "Alpha" in the legend
            LineItem myCurve3 = myPane3.AddCurve("Degrees", list5, Color.Red, SymbolType.Diamond);
            // Fill the symbols with white
            myCurve3.Symbol.Fill = new Fill(Color.White);
            // Generate a blue curve with circle symbols, and "Beta" in the legend
            //myCurve = myPane.AddCurve("Trigger", list2, Color.Blue, SymbolType.Circle);
            // Fill the symbols with white
            myCurve3.Symbol.Fill = new Fill(Color.White);
            // Associate this curve with the Y2 axis
            myCurve3.IsY2Axis = true;
            //Some enhancing setting:
            // Show the x axis grid
            myPane3.XAxis.MajorGrid.IsVisible = true;
            // Make the Y axis scale red
            myPane3.YAxis.Scale.FontSpec.FontColor = Color.Red;
            myPane3.YAxis.Title.FontSpec.FontColor = Color.Red;
            // turn off the opposite tics so the Y tics don't show up on the Y2 axis
            myPane3.YAxis.MajorTic.IsOpposite = false;
            myPane3.YAxis.MinorTic.IsOpposite = false;
            // Don't display the Y zero line
            myPane3.YAxis.MajorGrid.IsZeroLine = false;
            // Align the Y axis labels so they are flush to the axis
            myPane3.YAxis.Scale.Align = AlignP.Inside;
            // Manually set the axis range
            myPane3.YAxis.Scale.Min = -180;
            myPane3.YAxis.Scale.Max = 180;
            //myPane2.Y2Axis.Scale.Min = 0;
            //myPane2.Y2Axis.Scale.Max = 226;
            // Enable the Y2 axis display
            //myPane.Y2Axis.IsVisible = true;
            // Make the Y2 axis scale blue
            myPane3.Y2Axis.Scale.FontSpec.FontColor = Color.Blue;
            myPane3.Y2Axis.Title.FontSpec.FontColor = Color.Blue;
            // turn off the opposite tics so the Y2 tics don't show up on the Y axis
            myPane3.Y2Axis.MajorTic.IsOpposite = false;
            myPane3.Y2Axis.MinorTic.IsOpposite = false;
            // Display the Y2 axis grid lines
            myPane3.Y2Axis.MajorGrid.IsVisible = false;
            // Align the Y2 axis labels so they are flush to the axis
            myPane3.Y2Axis.Scale.Align = AlignP.Inside;
            // Fill the axis background with a gradient
            myPane3.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
            // Calculate the Axis Scale Ranges
            //Note: ZedGraphControl.AxisChange() command keep checking and
            // adjusting the display axis setting according to the List changes.
            zedGraphControl3.AxisChange();
        }
        private void phasePlot(object sender, EventArgs e)
        {
            zedGraphControl3.GraphPane.CurveList.Clear();   //clear the graph
            CreateChart3(zedGraphControl3);  //create the graph
            zedGraphControl3.AxisChange();  //change the axis
            zedGraphControl3.Invalidate();  //confirm
            zedGraphControl3.Refresh();     //update
        }
        private void timePlot(object sender, EventArgs e)
        {   //used to update the quick reference measurements
            this.Invoke(new EventHandler(Calculate_deltaF));
            double max = graph.Max();   //finding the max value
            double min = graph.Min();   //finding the min value
            double peak = max - min;       //calculating peak to peak
            //pass to temp variables
            double max_v = max;
            double min_v = min;
            double peak_v = peak;
            //convert to stringsa
            string string_max = max_v.ToString("0.###" + " V");
            string string_min = min_v.ToString("0.###" + " V");
            string string_peak = peak_v.ToString("0.###" + " V");
            //update labels
            label7.Text = string_max;
            label8.Text = string_min;
            label9.Text = string_peak;

            zedGraphControl1.GraphPane.CurveList.Clear();   //clear the graph
            CreateChart(zedGraphControl1);  //create the graph
            zedGraphControl1.AxisChange();  //change the axis
            zedGraphControl1.Invalidate();  //confirm
            zedGraphControl1.Refresh();     //update
       }
        private void Ngo_Final_Load(object sender, EventArgs e)
        {
            y_min = 0; y_max = 5;   //default values
            //update plots
            this.Invoke(new EventHandler(timePlot));
            this.Invoke(new EventHandler(DFT_Plot));
            this.Invoke(new EventHandler(phasePlot));
            double x = 2.5; //defalut starting of trigger
            string x_v = x.ToString("0.##" + " V");   //convert to string
            label19.Text = x_v;     //update label
            label21.Text = "0 Hz";  //ensure the frequency label shows 0
        }

        private void portSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {   //call the form to update serial port settings
            frmPortSettings frm = new frmPortSettings();
            frm.Show();
        }

        private void addTo_String (object sender, EventArgs e)
        {
            in_string += rxString;  //append to string
        }

        private void Clear_String (object sender, EventArgs e)
        {
            in_string = string.Empty;   //clear string
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //AddTextToLabel(serialPort1.ReadExisting());            //Read data from serial port object
            string data = serialPort1.ReadExisting();

            //Choose one of the approaches below

            //Approach 1: call Invoke method and pass data via external variable
            rxString = data;  //assign to external variable
            //tb_Received.Clear();

            if (rxString.Contains("Q"))
            {       //reset everything in the gui
                this.Invoke(new EventHandler(clear_gui));
            }

            else if (rxString.Contains("!"))
            {   //flag for incoming samples
                this.Invoke(new EventHandler(Clear_String)); //clear the string
                this.Invoke(new EventHandler(addTo_String));  //append to string
            }

            else if (rxString.Contains("^"))
            {   //flag for end of incoming samples
                this.Invoke(new EventHandler(addTo_String));
                this.Invoke(new EventHandler(Input_Convert));
            }

            else if (rxString.Contains("+"))
            {    //increase sampling frequency flag
                this.Invoke(new EventHandler(Freq_Inc));
            }
            else if (rxString.Contains("_"))
            {   //decrease sampling frequency flag
                this.Invoke(new EventHandler(Freq_Dec));
            }
            else if (rxString.Contains("z"))
            {   //send trigger value flag
                this.Invoke(new EventHandler(trigger_data));
            }
            else if (rxString.Contains("F"))
            {   //send function generator period data flag
                this.Invoke(new EventHandler(freq_data));
            }
            else if (rxString.Contains("D"))
            {   //send duty data flag
                this.Invoke(new EventHandler(duty_data));
            }
            else
            {
                this.Invoke(new EventHandler(addTo_String));    //append to string
                this.Invoke(new EventHandler(ShowText));    //add to textbox
            }
        }
        private void Freq_Inc(object sender, EventArgs e)
        {
            if (trackBar1.Value < 4)
            {
                trackBar1.Value = trackBar1.Value + 1;  //speed up sampling frequency
                this.Invoke(new EventHandler(Calculate_deltaF));  //update calculations for x-axis
                this.Invoke(new EventHandler(trackBar1_Scroll));  //update the trackbar
            }
        }
        private void Freq_Dec(object sender, EventArgs e)
        {
            if (trackBar1.Value > 1)
            {
                trackBar1.Value = trackBar1.Value - 1;  //slow down sampling frequency
                this.Invoke(new EventHandler(Calculate_deltaF));    //update calculations for x-axis
                this.Invoke(new EventHandler(trackBar1_Scroll));    //update the trackbar
            }
        }
        private void Input_Convert(object sender, EventArgs e)
        {
            //in_string = tb_Received.Text;       //transfer the text from the textbox into a string
            in_string = in_string.Substring(in_string.IndexOf('!') + 1);  //get rid of first flag
            in_string = in_string.Substring(0, in_string.IndexOf('^') - 1); //get rid of ending flag
            input = in_string.Split(',');   //split based on , into an array of small strings
            for (int i = 0; i < input.Length; i++)
            {       //convert each small string into an integer
                in_array[i] = Convert.ToInt32(input[i]);
                graph[i] = in_array[i] * CON;
            }
            //update plots
            this.Invoke(new EventHandler(timePlot));
            this.Invoke(new EventHandler(DFT_Plot));
            this.Invoke(new EventHandler(phasePlot));
        }
        private void Calculate_deltaF(object sender, EventArgs e)
        {
            switch (trackBar1.Value)        
            {       //calculate delta f and delta t for the x-axis of the plots
                case 1: delta_f = 13.775; delta_t = 0.000362976;  break;
                case 2: delta_f = 86.09; delta_t = 0.00005808; break;
                case 3: delta_f = 344.355; delta_t = 0.00001452; break;
                case 4: delta_f = 1377.41; delta_t = 0.00000363; break;
            }
        }
        private void ShowText(object sender, EventArgs e)
        {
            tb_Received.AppendText(rxString);      //display incoming data
        }
        private void Connect(SerialPort handle)
        {
            //Configure serial port
            serialPort1.PortName = "COM10";
            serialPort1.BaudRate = 9600;

            if (serialPort1.IsOpen == false)
            {
                try
                {
                    serialPort1.Open();  //attempt to open the configured serial port
                    if (serialPort1.IsOpen)
                    {
                        //Com Port is connected
                        connectToolStripMenuItem.Enabled = false;
                        disconnectToolStripMenuItem1.Enabled = true;
                        tb_Received.ReadOnly = false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to open serial port");
                }
            }
        }
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //handle serial port connect
            Connect(serialPort1);
        }

        private void disconnectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                //Disconnect serial port
                serialPort1.Close();
                connectToolStripMenuItem.Enabled = true;
                disconnectToolStripMenuItem1.Enabled = false;
                tb_Received.ReadOnly = true;
            }
        }

        private void Ngo_Final_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close(); //close the serial port connection
        }

        public delegate void AddnewText(string str);
        public void AddTextToLabel(string str)
        {
            if (this.tb_Received.InvokeRequired)
            {
                this.Invoke(new AddnewText(AddTextToLabel), str); //add to textbox
            }
            else
            {
                this.tb_Received.Text += str;       //appdend to string
            }
        }

        private void triggerBar_Scroll(object sender, EventArgs e)
        {
            this.Invoke(new EventHandler(timePlot));    //update the trigger on the time plot 
            int value = triggerBar.Value;       //store value of trigger
            double value_v = value * CON;       //convert it to volts
            string trigger = value_v.ToString("0.##"+ " V");    //convert to string
            label19.Text = trigger;     //update label
        }

        private void triggerBar_MouseUp(object sender, MouseEventArgs e)
        {
            serialPort1.Write("z");     //send trigger value flag to chip 
        }
        private void trigger_data(object sender, EventArgs e)
        {
            string temp = Convert.ToString(triggerBar.Value);   //convert trigger value to string
            temp = temp.Replace("\n", "");  //replace end line with nothing
            char[] array = temp.ToCharArray();      //convert to a char array
            //send one character at a time
            for (int i = 0; i < array.Length; i++)
            {       //send each value of the trigger
                string c = array[i].ToString();
                serialPort1.Write(c);
                Thread.Sleep(10);
            }
            serialPort1.Write("y"); //send done flag
        }
        private void SampFreq(object sender, MouseEventArgs e)
        {
            this.Invoke(new EventHandler(Calculate_deltaF));
            switch (trackBar1.Value)        //send sampling frequency value to chip
            {
                case 1: serialPort1.Write("d"); break;    //Fs/100 ~ 2.8 K
                case 2: serialPort1.Write("c"); break;    //Fs/16 ~ 17 K
                case 3: serialPort1.Write("b"); break;    //Fs/4 ~ 69 K
                case 4: serialPort1.Write("a"); break;     //Fs ~ 275 
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            switch (trackBar1.Value)        //update the label with the sampling frequency
            {
                case 1: label4.Text = "2.755 KHz"; break;
                case 2: label4.Text = "17.218 KHz"; break;
                case 3: label4.Text = "68.871 KHz"; break;
                case 4: label4.Text = "275.482 KHz"; break;
            }
        }

        private void Run_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Write("*");     //start sampling
            }
        }

        private void clear_gui(object sender, EventArgs e)
        {   //set back to defaults
            delta_f = 1; trackBar1.Value = 4; freq = "0";
            trackBar2.Value = 1;  triggerBar.Value = 105;
            DutyBar.Value = 7; freq_bar.Value = 5000;
            label7.Text = "0";
            label8.Text = "0"; label9.Text = "0"; delta_t = 1;
            duty_cycle = 50; duty.Text = duty_cycle.ToString();
            function = 5000; fctn_freq.Text = function.ToString();
            for (int i = 0; i < graph.Length; i++)
            {       //clear arrays
                graph[i] = 0; 
                result[i] = 0;
                phase[i] = 0;
                in_array[i] = 0;
            }
            tb_Received.Clear();        //clear textbox
            //update plots
            this.Invoke(new EventHandler(timePlot));       
            this.Invoke(new EventHandler(trackBar1_Scroll));
            this.Invoke(new EventHandler(DFT_Plot));
            this.Invoke(new EventHandler(phasePlot));
            label21.Text = "0 Hz";  //ensure the frequency label shows 0
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            serialPort1.Write("#");     //stop and reset
            this.Invoke(new EventHandler(clear_gui));        
        }
        private void DFT_Math(object sender, EventArgs e)
        {
            double[] real = new double[200];        //store real part 
            double[] imaginary = new double[200];      //store imaginary part
            double[] temp = new double[200];        //used to store samples so dft goes from -Fs to +Fs
            double[] split = new double[100];       //store the first half to find the max without DC
            for (int n = 0; n < in_array.Length; n++)
            {
                temp[n]= Math.Pow(-1, n) * in_array[n];     //convert samples so dft plot is centered at 0.
            }
            for (int i = 0; i < 200; i++)   //
            {
                double w = i * (2 * Math.PI) / 200;     //updating value to be used in dft calculation
                for (int t = 0; t < in_array.Length; t++)
                {
                    real[i] += temp[t] * Math.Cos(w * t);   //calculating the real part    
                    imaginary[i] += temp[t] * Math.Sin(w * t);      //calculating the imaginary part
                }               
                result[i] = Math.Sqrt(real[i] * real[i] + imaginary[i] * imaginary[i]);     //finding magnitude
                if (scale_flag)
                {
                    result[i] = Math.Log10(result[i]);      //used to convert to dB
                }
                phase[i] = Math.Atan2(imaginary[i], real[i]) * 180 / Math.PI;       //findng the phase
            }
            for (int h = 0; h < 100; h++)
            {
                split[h] = result[h];       //store first half without DC
            }
            double dft_max = split.Max();       //find the max
            int index = Array.IndexOf(result, dft_max);     //find the location of the max
            double frequency = (index - 100) * delta_f;     //use the location fo find the frequency of sampled signal
            frequency = Math.Abs(frequency);        //make it positive since the first half is negative
            freq = frequency.ToString("0" + " Hz");     //convert to a string
            label21.Text = freq;        //update label
        }
        private void DFT_Plot(object sender, EventArgs e)
        {
            this.Invoke(new EventHandler(DFT_Math));
            zedGraphControl2.GraphPane.CurveList.Clear();   //clear the graph
            CreateChart2(zedGraphControl2);  //create the graph
            zedGraphControl2.AxisChange();  //change the axis
            zedGraphControl2.Invalidate();  //confirm
            zedGraphControl2.Refresh();     //update
        }

        private void freq_bar_MouseUP(object sender, MouseEventArgs e)
        {
            serialPort1.Write("F");     //send value flag to chip
        }
        private void freq_data(object sender, EventArgs e)
        {
            fctn_freq.Text = freq_bar.Value.ToString();
            string temp = Convert.ToString(freq_bar.Value);   //convert value to string
            temp = temp.Replace("\n", "");  //replace end line with nothing
            char[] array = temp.ToCharArray();      //convert to a char array
            //send one character at a time
            for (int i = 0; i < array.Length; i++)
            {       //send each value 
                string c = array[i].ToString();
                serialPort1.Write(c);
                Thread.Sleep(10);
            }
            serialPort1.Write("y"); //send done flag
        }

        private void dutyBar_MouseUp(object sender, MouseEventArgs e)
        {
            serialPort1.Write("D");     //send trigger value flag to chip
        }
        private void duty_data(object sender, EventArgs e)
        {
            string temp;
            switch (DutyBar.Value)
            {
                case 1: duty.Text = "20"; temp = "20"; break;
                case 2: duty.Text = "25"; temp = "25"; break;
                case 3: duty.Text = "30"; temp = "30"; break;
                case 4: duty.Text = "35"; temp = "35"; break;
                case 5: duty.Text = "40"; temp = "40"; break;
                case 6: duty.Text = "45"; temp = "45"; break;
                case 7: duty.Text = "50"; temp = "50"; break;
                case 8: duty.Text = "55"; temp = "55"; break;
                case 9: duty.Text = "60"; temp = "60"; break;
                case 10: duty.Text = "65"; temp = "65"; break;
                case 11: duty.Text = "70"; temp = "70"; break;
                case 12: duty.Text = "75"; temp = "75"; break;
                case 13: duty.Text = "80"; temp = "80"; break;
                default: duty.Text = "50"; temp = "50"; break;
            }
            char[] array = temp.ToCharArray();      //convert to a char array
            //send one character at a time
            for (int i = 0; i < array.Length; i++)
            {       //send each value of the trigger
                string c = array[i].ToString();
                serialPort1.Write(c);
                Thread.Sleep(10);
            }
            serialPort1.Write("y"); //send done flag
        }

        private void button1_Click(object sender, EventArgs e)
        {       //toggle flag to switch dft plot from linear to dB
            if (scale_flag == true)
            {
                scale_flag = false;     //dft plot is linear
            }
            else
            {
                scale_flag = true;      //dft plot is dB
            }
        }

        private void tb_Send_TextChanged(object sender, EventArgs e)
        {
            string y = tb_Send.Text;        //convert the text to a string
            serialPort1.Write(y);     //send character typed in textbox           
            tb_Send.Clear();        //clear text box
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            switch (trackBar2.Value)
            {       //update the y axis of the time plot accpording to zoom
                case 1: y_min = 0; y_max = 5; this.Invoke(new EventHandler(timePlot)); break;
                case 2: y_min = 2.5 - 2.55 / 2; y_max = 2.5 + 2.55 / 2; this.Invoke(new EventHandler(timePlot)); break;
                case 3: y_min = 2.5 - 2.55 / 8; y_max = 2.5 + 2.55 / 8; this.Invoke(new EventHandler(timePlot)); break;
                case 4: y_min = 2.5 - 2.55 / 32; y_max = 2.5 + 2.55 / 32; this.Invoke(new EventHandler(timePlot)); break;
                case 5: y_min = 2.5 - 2.55 / 100; y_max = 2.5 + 2.55 / 100; this.Invoke(new EventHandler(timePlot)); break;
            }
        }
    }
}