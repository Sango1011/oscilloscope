namespace Ngo_Oscillocope
{
    partial class frmPortSettings
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
            this.combo_Port = new System.Windows.Forms.ComboBox();
            this.combo_bps = new System.Windows.Forms.ComboBox();
            this.combo_DataBits = new System.Windows.Forms.ComboBox();
            this.combo_Parity = new System.Windows.Forms.ComboBox();
            this.combo_StopBits = new System.Windows.Forms.ComboBox();
            this.combo_FlowCtrl = new System.Windows.Forms.ComboBox();
            this.Apply = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // combo_Port
            // 
            this.combo_Port.FormattingEnabled = true;
            this.combo_Port.Location = new System.Drawing.Point(193, 22);
            this.combo_Port.Name = "combo_Port";
            this.combo_Port.Size = new System.Drawing.Size(121, 21);
            this.combo_Port.TabIndex = 0;
            // 
            // combo_bps
            // 
            this.combo_bps.FormattingEnabled = true;
            this.combo_bps.Items.AddRange(new object[] {
            "110",
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.combo_bps.Location = new System.Drawing.Point(193, 65);
            this.combo_bps.Name = "combo_bps";
            this.combo_bps.Size = new System.Drawing.Size(121, 21);
            this.combo_bps.TabIndex = 1;
            // 
            // combo_DataBits
            // 
            this.combo_DataBits.FormattingEnabled = true;
            this.combo_DataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.combo_DataBits.Location = new System.Drawing.Point(193, 111);
            this.combo_DataBits.Name = "combo_DataBits";
            this.combo_DataBits.Size = new System.Drawing.Size(121, 21);
            this.combo_DataBits.TabIndex = 2;
            // 
            // combo_Parity
            // 
            this.combo_Parity.FormattingEnabled = true;
            this.combo_Parity.Location = new System.Drawing.Point(193, 154);
            this.combo_Parity.Name = "combo_Parity";
            this.combo_Parity.Size = new System.Drawing.Size(121, 21);
            this.combo_Parity.TabIndex = 3;
            // 
            // combo_StopBits
            // 
            this.combo_StopBits.FormattingEnabled = true;
            this.combo_StopBits.Location = new System.Drawing.Point(193, 197);
            this.combo_StopBits.Name = "combo_StopBits";
            this.combo_StopBits.Size = new System.Drawing.Size(121, 21);
            this.combo_StopBits.TabIndex = 4;
            // 
            // combo_FlowCtrl
            // 
            this.combo_FlowCtrl.FormattingEnabled = true;
            this.combo_FlowCtrl.Location = new System.Drawing.Point(193, 246);
            this.combo_FlowCtrl.Name = "combo_FlowCtrl";
            this.combo_FlowCtrl.Size = new System.Drawing.Size(121, 21);
            this.combo_FlowCtrl.TabIndex = 5;
            // 
            // Apply
            // 
            this.Apply.Location = new System.Drawing.Point(63, 330);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(100, 23);
            this.Apply.TabIndex = 6;
            this.Apply.Text = "Apply Settings";
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(193, 330);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(121, 23);
            this.Reset.TabIndex = 7;
            this.Reset.Text = "Reset to Default";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Bits Per Second";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Data Bits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Parity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Stop Bits";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Flow Control";
            // 
            // frmPortSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 379);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Apply);
            this.Controls.Add(this.combo_FlowCtrl);
            this.Controls.Add(this.combo_StopBits);
            this.Controls.Add(this.combo_Parity);
            this.Controls.Add(this.combo_DataBits);
            this.Controls.Add(this.combo_bps);
            this.Controls.Add(this.combo_Port);
            this.Name = "frmPortSettings";
            this.Text = "Port Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPortSettings_FormClosed);
            this.Load += new System.EventHandler(this.frmPortSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combo_Port;
        private System.Windows.Forms.ComboBox combo_bps;
        private System.Windows.Forms.ComboBox combo_DataBits;
        private System.Windows.Forms.ComboBox combo_Parity;
        private System.Windows.Forms.ComboBox combo_StopBits;
        private System.Windows.Forms.ComboBox combo_FlowCtrl;
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}