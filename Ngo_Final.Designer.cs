namespace Ngo_Oscillocope
{
    partial class Ngo_Final
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tb_Received = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.portSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.triggerBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Run = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            this.button1 = new System.Windows.Forms.Button();
            this.Max = new System.Windows.Forms.Label();
            this.PeakToPeak = new System.Windows.Forms.Label();
            this.Min = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tb_Send = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.duty = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.fctn_freq = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.freq_bar = new System.Windows.Forms.TrackBar();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.DutyBar = new System.Windows.Forms.TrackBar();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.triggerBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DutyBar)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_Received
            // 
            this.tb_Received.Location = new System.Drawing.Point(449, 250);
            this.tb_Received.Multiline = true;
            this.tb_Received.Name = "tb_Received";
            this.tb_Received.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_Received.Size = new System.Drawing.Size(147, 147);
            this.tb_Received.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portSettingsToolStripMenuItem,
            this.ComPortToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1059, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // portSettingsToolStripMenuItem
            // 
            this.portSettingsToolStripMenuItem.Name = "portSettingsToolStripMenuItem";
            this.portSettingsToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.portSettingsToolStripMenuItem.Text = "Port Settings";
            this.portSettingsToolStripMenuItem.Click += new System.EventHandler(this.portSettingsToolStripMenuItem_Click);
            // 
            // ComPortToolStripMenuItem
            // 
            this.ComPortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem1});
            this.ComPortToolStripMenuItem.Name = "ComPortToolStripMenuItem";
            this.ComPortToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.ComPortToolStripMenuItem.Text = "Com Port";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem1
            // 
            this.disconnectToolStripMenuItem1.Name = "disconnectToolStripMenuItem1";
            this.disconnectToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem1.Text = "Disconnect";
            this.disconnectToolStripMenuItem1.Click += new System.EventHandler(this.disconnectToolStripMenuItem1_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(15, 27);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(428, 357);
            this.zedGraphControl1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sampling Frequency";
            // 
            // triggerBar
            // 
            this.triggerBar.LargeChange = 50;
            this.triggerBar.Location = new System.Drawing.Point(113, 403);
            this.triggerBar.Maximum = 210;
            this.triggerBar.Name = "triggerBar";
            this.triggerBar.Size = new System.Drawing.Size(351, 45);
            this.triggerBar.SmallChange = 20;
            this.triggerBar.TabIndex = 6;
            this.triggerBar.Value = 105;
            this.triggerBar.Scroll += new System.EventHandler(this.triggerBar_Scroll);
            this.triggerBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.triggerBar_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Trigger Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 409);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "275.482 KHz";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 425);
            this.trackBar1.Maximum = 4;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 104);
            this.trackBar1.TabIndex = 10;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 4;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SampFreq);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 435);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "2.5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(441, 435);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "5";
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(6, 540);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(75, 23);
            this.Run.TabIndex = 13;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(87, 540);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(75, 23);
            this.Stop.TabIndex = 14;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.Location = new System.Drawing.Point(602, 27);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(433, 267);
            this.zedGraphControl2.TabIndex = 15;
            // 
            // zedGraphControl3
            // 
            this.zedGraphControl3.Location = new System.Drawing.Point(602, 300);
            this.zedGraphControl3.Name = "zedGraphControl3";
            this.zedGraphControl3.ScrollGrace = 0D;
            this.zedGraphControl3.ScrollMaxX = 0D;
            this.zedGraphControl3.ScrollMaxY = 0D;
            this.zedGraphControl3.ScrollMaxY2 = 0D;
            this.zedGraphControl3.ScrollMinX = 0D;
            this.zedGraphControl3.ScrollMinY = 0D;
            this.zedGraphControl3.ScrollMinY2 = 0D;
            this.zedGraphControl3.Size = new System.Drawing.Size(433, 258);
            this.zedGraphControl3.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(530, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 55);
            this.button1.TabIndex = 17;
            this.button1.Text = "Linear/DB";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Max
            // 
            this.Max.AutoSize = true;
            this.Max.Location = new System.Drawing.Point(449, 140);
            this.Max.Name = "Max";
            this.Max.Size = new System.Drawing.Size(27, 13);
            this.Max.TabIndex = 19;
            this.Max.Text = "Max";
            // 
            // PeakToPeak
            // 
            this.PeakToPeak.AutoSize = true;
            this.PeakToPeak.Location = new System.Drawing.Point(449, 197);
            this.PeakToPeak.Name = "PeakToPeak";
            this.PeakToPeak.Size = new System.Drawing.Size(72, 13);
            this.PeakToPeak.TabIndex = 21;
            this.PeakToPeak.Text = "Peak to Peak";
            // 
            // Min
            // 
            this.Min.AutoSize = true;
            this.Min.Location = new System.Drawing.Point(449, 168);
            this.Min.Name = "Min";
            this.Min.Size = new System.Drawing.Size(24, 13);
            this.Min.TabIndex = 22;
            this.Min.Text = "Min";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(527, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(527, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(527, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(337, 535);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(449, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 16);
            this.label11.TabIndex = 27;
            this.label11.Text = "Quick Measure";
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 3;
            this.trackBar2.Location = new System.Drawing.Point(82, 468);
            this.trackBar2.Maximum = 5;
            this.trackBar2.Minimum = 1;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(141, 45);
            this.trackBar2.TabIndex = 28;
            this.trackBar2.Value = 1;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(79, 500);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "X";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(110, 458);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Magnitude Zoom";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(92, 500);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(120, 500);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "2";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(148, 500);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(13, 13);
            this.label16.TabIndex = 33;
            this.label16.Text = "8";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(167, 500);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(19, 13);
            this.label17.TabIndex = 34;
            this.label17.Text = "32";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(198, 500);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(25, 13);
            this.label18.TabIndex = 35;
            this.label18.Text = "100";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(306, 387);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(13, 13);
            this.label19.TabIndex = 36;
            this.label19.Text = "0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(449, 224);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 13);
            this.label20.TabIndex = 37;
            this.label20.Text = "Frequency";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(523, 224);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(13, 13);
            this.label21.TabIndex = 38;
            this.label21.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(449, 278);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(0, 16);
            this.label22.TabIndex = 39;
            // 
            // tb_Send
            // 
            this.tb_Send.Location = new System.Drawing.Point(43, 569);
            this.tb_Send.Name = "tb_Send";
            this.tb_Send.Size = new System.Drawing.Size(100, 20);
            this.tb_Send.TabIndex = 44;
            this.tb_Send.TextChanged += new System.EventHandler(this.tb_Send_TextChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(383, 484);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(58, 13);
            this.label23.TabIndex = 45;
            this.label23.Text = "Duty Cycle";
            // 
            // duty
            // 
            this.duty.AutoSize = true;
            this.duty.Location = new System.Drawing.Point(457, 484);
            this.duty.Name = "duty";
            this.duty.Size = new System.Drawing.Size(19, 13);
            this.duty.TabIndex = 46;
            this.duty.Text = "50";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(383, 550);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(123, 13);
            this.label24.TabIndex = 51;
            this.label24.Text = "Function Frequency (Hz)";
            // 
            // fctn_freq
            // 
            this.fctn_freq.AutoSize = true;
            this.fctn_freq.Location = new System.Drawing.Point(541, 550);
            this.fctn_freq.Name = "fctn_freq";
            this.fctn_freq.Size = new System.Drawing.Size(31, 13);
            this.fctn_freq.TabIndex = 52;
            this.fctn_freq.Text = "5000";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(260, 500);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(98, 20);
            this.label25.TabIndex = 59;
            this.label25.Text = "FUNCTION";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(238, 525);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(120, 20);
            this.label26.TabIndex = 60;
            this.label26.Text = "GENERATOR";
            // 
            // freq_bar
            // 
            this.freq_bar.LargeChange = 1000;
            this.freq_bar.Location = new System.Drawing.Point(170, 564);
            this.freq_bar.Maximum = 10000;
            this.freq_bar.Minimum = 100;
            this.freq_bar.Name = "freq_bar";
            this.freq_bar.Size = new System.Drawing.Size(865, 45);
            this.freq_bar.SmallChange = 100;
            this.freq_bar.TabIndex = 61;
            this.freq_bar.TickFrequency = 100;
            this.freq_bar.Value = 5000;
            this.freq_bar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.freq_bar_MouseUP);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(167, 596);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(25, 13);
            this.label27.TabIndex = 62;
            this.label27.Text = "100";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(583, 594);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(34, 13);
            this.label28.TabIndex = 63;
            this.label28.Text = "5,000";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(1007, 594);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(40, 13);
            this.label29.TabIndex = 64;
            this.label29.Text = "10,000";
            // 
            // DutyBar
            // 
            this.DutyBar.LargeChange = 3;
            this.DutyBar.Location = new System.Drawing.Point(364, 500);
            this.DutyBar.Maximum = 13;
            this.DutyBar.Minimum = 1;
            this.DutyBar.Name = "DutyBar";
            this.DutyBar.Size = new System.Drawing.Size(217, 45);
            this.DutyBar.TabIndex = 65;
            this.DutyBar.Value = 7;
            this.DutyBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dutyBar_MouseUp);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(365, 525);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(19, 13);
            this.label30.TabIndex = 66;
            this.label30.Text = "20";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(562, 530);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(19, 13);
            this.label31.TabIndex = 67;
            this.label31.Text = "80";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(466, 525);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(19, 13);
            this.label32.TabIndex = 68;
            this.label32.Text = "50";
            // 
            // Ngo_Final
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 616);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.DutyBar);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.freq_bar);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.fctn_freq);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.duty);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.tb_Send);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Min);
            this.Controls.Add(this.PeakToPeak);
            this.Controls.Add(this.Max);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zedGraphControl3);
            this.Controls.Add(this.zedGraphControl2);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.triggerBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.tb_Received);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Ngo_Final";
            this.Text = "Scope of Ngo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ngo_Final_FormClosing);
            this.Load += new System.EventHandler(this.Ngo_Final_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SampFreq);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.triggerBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freq_bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DutyBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Received;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem portSettingsToolStripMenuItem;
        public System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem ComPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem1;
        private System.Windows.Forms.TrackBar triggerBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Button Stop;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private ZedGraph.ZedGraphControl zedGraphControl3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Max;
        private System.Windows.Forms.Label PeakToPeak;
        private System.Windows.Forms.Label Min;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tb_Send;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label duty;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label fctn_freq;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TrackBar freq_bar;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TrackBar DutyBar;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
    }
}

