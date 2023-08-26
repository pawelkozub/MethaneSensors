namespace MQ4_PC
{
    partial class Form1
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
            this.G_Port = new System.Windows.Forms.GroupBox();
            this.L_port = new System.Windows.Forms.Label();
            this.B_connect_port = new System.Windows.Forms.Button();
            this.CB_port = new System.Windows.Forms.ComboBox();
            this.G_Calibration = new System.Windows.Forms.GroupBox();
            this.B_get_calibration = new System.Windows.Forms.Button();
            this.B_set_calibration = new System.Windows.Forms.Button();
            this.G_Panel = new System.Windows.Forms.GroupBox();
            this.B_Clear = new System.Windows.Forms.Button();
            this.B_Start = new System.Windows.Forms.Button();
            this.G_Export = new System.Windows.Forms.GroupBox();
            this.B_Export_excel = new System.Windows.Forms.Button();
            this.B_Export_notepad = new System.Windows.Forms.Button();
            this.G_Sample = new System.Windows.Forms.GroupBox();
            this.L_delay_value = new System.Windows.Forms.Label();
            this.L_Delay = new System.Windows.Forms.Label();
            this.CB_sample_time = new System.Windows.Forms.ComboBox();
            this.CB_sample_count = new System.Windows.Forms.ComboBox();
            this.L_time = new System.Windows.Forms.Label();
            this.L_count = new System.Windows.Forms.Label();
            this.L_value = new System.Windows.Forms.Label();
            this.CC_methane = new LiveCharts.WinForms.CartesianChart();
            this.L_calibration = new System.Windows.Forms.Label();
            this.L_CH4 = new System.Windows.Forms.Label();
            this.G_Port.SuspendLayout();
            this.G_Calibration.SuspendLayout();
            this.G_Panel.SuspendLayout();
            this.G_Export.SuspendLayout();
            this.G_Sample.SuspendLayout();
            this.SuspendLayout();
            // 
            // G_Port
            // 
            this.G_Port.Controls.Add(this.L_port);
            this.G_Port.Controls.Add(this.B_connect_port);
            this.G_Port.Controls.Add(this.CB_port);
            this.G_Port.Location = new System.Drawing.Point(13, 13);
            this.G_Port.Name = "G_Port";
            this.G_Port.Size = new System.Drawing.Size(236, 59);
            this.G_Port.TabIndex = 0;
            this.G_Port.TabStop = false;
            this.G_Port.Text = "Port";
            // 
            // L_port
            // 
            this.L_port.AutoSize = true;
            this.L_port.Location = new System.Drawing.Point(17, 25);
            this.L_port.Name = "L_port";
            this.L_port.Size = new System.Drawing.Size(42, 13);
            this.L_port.TabIndex = 2;
            this.L_port.Text = "Nr port:";
            // 
            // B_connect_port
            // 
            this.B_connect_port.Location = new System.Drawing.Point(148, 19);
            this.B_connect_port.Name = "B_connect_port";
            this.B_connect_port.Size = new System.Drawing.Size(75, 23);
            this.B_connect_port.TabIndex = 1;
            this.B_connect_port.Text = "Open";
            this.B_connect_port.UseVisualStyleBackColor = true;
            this.B_connect_port.Click += new System.EventHandler(this.B_connect_port_Click);
            // 
            // CB_port
            // 
            this.CB_port.FormattingEnabled = true;
            this.CB_port.Location = new System.Drawing.Point(68, 20);
            this.CB_port.Name = "CB_port";
            this.CB_port.Size = new System.Drawing.Size(74, 21);
            this.CB_port.TabIndex = 0;
            // 
            // G_Calibration
            // 
            this.G_Calibration.Controls.Add(this.B_get_calibration);
            this.G_Calibration.Controls.Add(this.B_set_calibration);
            this.G_Calibration.Location = new System.Drawing.Point(255, 13);
            this.G_Calibration.Name = "G_Calibration";
            this.G_Calibration.Size = new System.Drawing.Size(175, 59);
            this.G_Calibration.TabIndex = 1;
            this.G_Calibration.TabStop = false;
            this.G_Calibration.Text = "Kalibracja";
            // 
            // B_get_calibration
            // 
            this.B_get_calibration.Location = new System.Drawing.Point(89, 20);
            this.B_get_calibration.Name = "B_get_calibration";
            this.B_get_calibration.Size = new System.Drawing.Size(75, 23);
            this.B_get_calibration.TabIndex = 1;
            this.B_get_calibration.Text = "Wczytaj";
            this.B_get_calibration.UseVisualStyleBackColor = true;
            this.B_get_calibration.Click += new System.EventHandler(this.B_get_calibration_Click);
            // 
            // B_set_calibration
            // 
            this.B_set_calibration.Location = new System.Drawing.Point(8, 20);
            this.B_set_calibration.Name = "B_set_calibration";
            this.B_set_calibration.Size = new System.Drawing.Size(75, 23);
            this.B_set_calibration.TabIndex = 0;
            this.B_set_calibration.Text = "Ustaw";
            this.B_set_calibration.UseVisualStyleBackColor = true;
            this.B_set_calibration.Click += new System.EventHandler(this.B_set_calibration_Click);
            // 
            // G_Panel
            // 
            this.G_Panel.Controls.Add(this.B_Clear);
            this.G_Panel.Controls.Add(this.B_Start);
            this.G_Panel.Location = new System.Drawing.Point(311, 78);
            this.G_Panel.Name = "G_Panel";
            this.G_Panel.Size = new System.Drawing.Size(119, 84);
            this.G_Panel.TabIndex = 2;
            this.G_Panel.TabStop = false;
            this.G_Panel.Text = "Panel";
            // 
            // B_Clear
            // 
            this.B_Clear.Location = new System.Drawing.Point(20, 48);
            this.B_Clear.Name = "B_Clear";
            this.B_Clear.Size = new System.Drawing.Size(75, 23);
            this.B_Clear.TabIndex = 3;
            this.B_Clear.Text = "Clear";
            this.B_Clear.UseVisualStyleBackColor = true;
            this.B_Clear.Click += new System.EventHandler(this.B_Clear_Click);
            // 
            // B_Start
            // 
            this.B_Start.Location = new System.Drawing.Point(20, 19);
            this.B_Start.Name = "B_Start";
            this.B_Start.Size = new System.Drawing.Size(75, 23);
            this.B_Start.TabIndex = 2;
            this.B_Start.Text = "Start";
            this.B_Start.UseVisualStyleBackColor = true;
            this.B_Start.Click += new System.EventHandler(this.B_Start_Click);
            // 
            // G_Export
            // 
            this.G_Export.Controls.Add(this.B_Export_excel);
            this.G_Export.Controls.Add(this.B_Export_notepad);
            this.G_Export.Location = new System.Drawing.Point(1077, 12);
            this.G_Export.Name = "G_Export";
            this.G_Export.Size = new System.Drawing.Size(119, 81);
            this.G_Export.TabIndex = 3;
            this.G_Export.TabStop = false;
            this.G_Export.Text = "Eksport do pliku";
            // 
            // B_Export_excel
            // 
            this.B_Export_excel.Location = new System.Drawing.Point(20, 19);
            this.B_Export_excel.Name = "B_Export_excel";
            this.B_Export_excel.Size = new System.Drawing.Size(75, 23);
            this.B_Export_excel.TabIndex = 1;
            this.B_Export_excel.Text = "Excel";
            this.B_Export_excel.UseVisualStyleBackColor = true;
            this.B_Export_excel.Click += new System.EventHandler(this.B_Export_excel_Click);
            // 
            // B_Export_notepad
            // 
            this.B_Export_notepad.Location = new System.Drawing.Point(20, 48);
            this.B_Export_notepad.Name = "B_Export_notepad";
            this.B_Export_notepad.Size = new System.Drawing.Size(75, 23);
            this.B_Export_notepad.TabIndex = 0;
            this.B_Export_notepad.Text = "Notatnik";
            this.B_Export_notepad.UseVisualStyleBackColor = true;
            this.B_Export_notepad.Click += new System.EventHandler(this.B_Export_notepad_Click);
            // 
            // G_Sample
            // 
            this.G_Sample.Controls.Add(this.L_delay_value);
            this.G_Sample.Controls.Add(this.L_Delay);
            this.G_Sample.Controls.Add(this.CB_sample_time);
            this.G_Sample.Controls.Add(this.CB_sample_count);
            this.G_Sample.Controls.Add(this.L_time);
            this.G_Sample.Controls.Add(this.L_count);
            this.G_Sample.Location = new System.Drawing.Point(13, 78);
            this.G_Sample.Name = "G_Sample";
            this.G_Sample.Size = new System.Drawing.Size(292, 84);
            this.G_Sample.TabIndex = 4;
            this.G_Sample.TabStop = false;
            this.G_Sample.Text = "Próbkowania";
            // 
            // L_delay_value
            // 
            this.L_delay_value.AutoSize = true;
            this.L_delay_value.Location = new System.Drawing.Point(217, 53);
            this.L_delay_value.Name = "L_delay_value";
            this.L_delay_value.Size = new System.Drawing.Size(35, 13);
            this.L_delay_value.TabIndex = 7;
            this.L_delay_value.Text = "label1";
            // 
            // L_Delay
            // 
            this.L_Delay.AutoSize = true;
            this.L_Delay.Location = new System.Drawing.Point(207, 24);
            this.L_Delay.Name = "L_Delay";
            this.L_Delay.Size = new System.Drawing.Size(59, 13);
            this.L_Delay.TabIndex = 6;
            this.L_Delay.Text = "Delay [ms]:";
            this.L_Delay.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // CB_sample_time
            // 
            this.CB_sample_time.FormattingEnabled = true;
            this.CB_sample_time.Location = new System.Drawing.Point(73, 48);
            this.CB_sample_time.Name = "CB_sample_time";
            this.CB_sample_time.Size = new System.Drawing.Size(85, 21);
            this.CB_sample_time.TabIndex = 5;
            this.CB_sample_time.SelectedIndexChanged += new System.EventHandler(this.CB_sample_time_SelectedIndexChanged);
            // 
            // CB_sample_count
            // 
            this.CB_sample_count.FormattingEnabled = true;
            this.CB_sample_count.Location = new System.Drawing.Point(73, 18);
            this.CB_sample_count.Name = "CB_sample_count";
            this.CB_sample_count.Size = new System.Drawing.Size(85, 21);
            this.CB_sample_count.TabIndex = 4;
            this.CB_sample_count.SelectedIndexChanged += new System.EventHandler(this.CB_sample_count_SelectedIndexChanged);
            // 
            // L_time
            // 
            this.L_time.AutoSize = true;
            this.L_time.Location = new System.Drawing.Point(12, 51);
            this.L_time.Name = "L_time";
            this.L_time.Size = new System.Drawing.Size(55, 13);
            this.L_time.TabIndex = 1;
            this.L_time.Text = "Czas [ms]:";
            // 
            // L_count
            // 
            this.L_count.AutoSize = true;
            this.L_count.Location = new System.Drawing.Point(12, 25);
            this.L_count.Name = "L_count";
            this.L_count.Size = new System.Drawing.Size(32, 13);
            this.L_count.TabIndex = 0;
            this.L_count.Text = "Ilość:";
            // 
            // L_value
            // 
            this.L_value.AutoSize = true;
            this.L_value.Font = new System.Drawing.Font("BankGothic Md BT", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_value.Location = new System.Drawing.Point(762, 60);
            this.L_value.Name = "L_value";
            this.L_value.Size = new System.Drawing.Size(60, 50);
            this.L_value.TabIndex = 5;
            this.L_value.Text = "0";
            // 
            // CC_methane
            // 
            this.CC_methane.Location = new System.Drawing.Point(13, 168);
            this.CC_methane.Name = "CC_methane";
            this.CC_methane.Size = new System.Drawing.Size(1183, 524);
            this.CC_methane.TabIndex = 6;
            this.CC_methane.Text = "Methane";
            // 
            // L_calibration
            // 
            this.L_calibration.AutoSize = true;
            this.L_calibration.Location = new System.Drawing.Point(1074, 129);
            this.L_calibration.Name = "L_calibration";
            this.L_calibration.Size = new System.Drawing.Size(35, 13);
            this.L_calibration.TabIndex = 7;
            this.L_calibration.Text = "label1";
            // 
            // L_CH4
            // 
            this.L_CH4.AutoSize = true;
            this.L_CH4.Font = new System.Drawing.Font("BankGothic Md BT", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_CH4.Location = new System.Drawing.Point(462, 60);
            this.L_CH4.Name = "L_CH4";
            this.L_CH4.Size = new System.Drawing.Size(313, 50);
            this.L_CH4.TabIndex = 8;
            this.L_CH4.Text = "CH4 [ppm]:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 701);
            this.Controls.Add(this.L_CH4);
            this.Controls.Add(this.L_calibration);
            this.Controls.Add(this.CC_methane);
            this.Controls.Add(this.L_value);
            this.Controls.Add(this.G_Sample);
            this.Controls.Add(this.G_Export);
            this.Controls.Add(this.G_Panel);
            this.Controls.Add(this.G_Calibration);
            this.Controls.Add(this.G_Port);
            this.Name = "Form1";
            this.Text = "Analizator metanu MQ4";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.G_Port.ResumeLayout(false);
            this.G_Port.PerformLayout();
            this.G_Calibration.ResumeLayout(false);
            this.G_Panel.ResumeLayout(false);
            this.G_Export.ResumeLayout(false);
            this.G_Sample.ResumeLayout(false);
            this.G_Sample.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox G_Port;
        private System.Windows.Forms.Button B_connect_port;
        private System.Windows.Forms.ComboBox CB_port;
        private System.Windows.Forms.GroupBox G_Calibration;
        private System.Windows.Forms.Button B_get_calibration;
        private System.Windows.Forms.Button B_set_calibration;
        private System.Windows.Forms.GroupBox G_Panel;
        private System.Windows.Forms.GroupBox G_Export;
        private System.Windows.Forms.Button B_Export_excel;
        private System.Windows.Forms.Button B_Export_notepad;
        private System.Windows.Forms.Button B_Clear;
        private System.Windows.Forms.Button B_Start;
        private System.Windows.Forms.GroupBox G_Sample;
        private System.Windows.Forms.Label L_time;
        private System.Windows.Forms.Label L_count;
        private System.Windows.Forms.Label L_value;
        private System.Windows.Forms.Label L_calibration;
        private System.Windows.Forms.Label L_CH4;
        private LiveCharts.WinForms.CartesianChart CC_methane;
        private System.Windows.Forms.ComboBox CB_sample_time;
        private System.Windows.Forms.ComboBox CB_sample_count;
        private System.Windows.Forms.Label L_delay_value;
        private System.Windows.Forms.Label L_Delay;
        private System.Windows.Forms.Label L_port;
    }
}

