using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using LiveCharts.Geared;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace MQ4_PC
{
    public partial class Form1 : Form
    {
        SerialPort myPort = new SerialPort();
        private Chartslive _chartslive = new Chartslive();
        private Export _export = new Export();
        private MQ4 _mq4 = new MQ4();
        volatile bool reading = false;
        static object syncLock = new object();
        bool connected = false;
        bool calibration = true;
        bool useport = false;
        Thread oThread;
        DataGridView dgv;
        int time = 0;
        Random rand = new Random();

        delegate void SetTextCallback(string text);

        public Form1()
        {
            InitializeComponent();

            CC_methane.Series.Add(
               new GLineSeries
               {
                   Values = _chartslive.Values1
               });
            CC_methane.DisableAnimations = true;
            L_value.Text = "";

            this.Icon = new Icon("ch4.ico");

            Closes();

            oThread = new Thread(new ThreadStart(Read));
            try
            {
                oThread.Start();
            }
            catch (ThreadStateException ex)
            {
                MessageBox.Show(ex.Message, "Threads Read", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Closing += (o, e) => {
                if (useport)
                {
                    if (myPort.IsOpen)
                    {
                        myPort.WriteLine("0;0;0");
                        myPort.Close();
                    }
                }
                oThread.Abort();
            };

            dgv = new DataGridView();
            dgv.Columns.Add("col1", "time");
            dgv.Columns.Add("col2", "CH4%");
    }

        private void Opened()
        {
            G_Panel.Enabled = true;
            G_Calibration.Enabled = true;
            G_Export.Enabled = true;
            G_Sample.Enabled = true;
        }

        private void Closes()
        {
            G_Panel.Enabled = false;
            G_Calibration.Enabled = false;
            G_Export.Enabled = false;
            G_Sample.Enabled = false;
            calibration = true;
            Calibration_Clear();
            L_calibration.Text = "";
            L_value.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (useport) Load_Ports();
            Load_Sample();
        }

        #region Ports

        private void Load_Ports()
        {
            string[] ports = SerialPort.GetPortNames();
            CB_port.Items.AddRange(ports);
            CB_port.SelectedIndex = 1;
        }

        private void B_connect_port_Click(object sender, EventArgs e)
        {
            try
            {
                lock (syncLock) { 
                    if (connected == false && myPort.IsOpen == false)
                    {
                        if (useport)
                        {
                            myPort = new SerialPort(CB_port.SelectedItem.ToString(), 9600);
                            myPort.Open();
                        }
                       
                        Opened();
                        B_connect_port.Text = "Close";
                        B_Start.Text = "Start";
                        connected = true;
                    }
                    else if (connected == true && myPort.IsOpen == true)
                    {
                        reading = false;
                        if (useport)
                        {
                            myPort.WriteLine("0;0;0");
                            Thread.Sleep(100);
                            myPort.Close();
                        }
                        
                        Closes();
                        B_connect_port.Text = "Open";
                        connected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Connection Port", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion 

        #region Calibration

        private void B_set_calibration_Click(object sender, EventArgs e)
        {
            try
            {
                G_Calibration.Enabled = false;
                G_Sample.Enabled = false;
                if (useport)
                {
                    myPort.Write(Config.Sample_count + ";" + Config.Sample_time + ";1");
                    int bit = Convert.ToInt32(myPort.ReadLine());
                    bit /= Config.Sample_count;
                    _mq4.Set_Calibration(bit);
                    Calibration_View();
                }
                calibration = false;
                G_Sample.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Set Calibration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void B_get_calibration_Click(object sender, EventArgs e)
        {
            if (_mq4.Read_Calibration())
            {
                Calibration_View();
                calibration = false;
                G_Calibration.Enabled = false;
            }
            else
            {
                MessageBox.Show("Nie istnieje pliki calibration.txt w Pulpitu", "Nie istnieje pliku", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }

        private void Calibration_View()
        {
            L_calibration.Text = "Ro_air: " + Math.Round(Config.Ro_calibration, 3).ToString();
        }

        private void Calibration_Clear()
        {
            L_calibration.Text = "";
        }
        #endregion

        #region Panel

        private void B_Start_Click(object sender, EventArgs e)
        {
            try
            {
                if (calibration)
                {
                    MessageBox.Show("Konieczne ustaw kalibracji", "Kalibracji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (reading)
                    {
                        reading = false;
                        if(useport) myPort.WriteLine("0;0;0");
                        B_Start.Text = "Start";
                        G_Sample.Enabled = true;
                        G_Export.Enabled = true;
                    }
                    else
                    {
                        reading = true;
                        if(useport) myPort.WriteLine(Config.Sample_count + ";" + Config.Sample_time+";0");
                        B_Start.Text = "Stop";
                        G_Sample.Enabled = false;
                        G_Export.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Recive", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void B_Clear_Click(object sender, EventArgs e)
        {
            _chartslive.Clear();
            dgv.Rows.Clear();
            dgv.Columns.Add("col1", "time");
            dgv.Columns.Add("col2", "CH4%");
            time = 0;
            L_value.Text = "0";
        }

        private double Random_number()
        {
            double rd = rand.Next(1000, 5000) * rand.Next(23, 30);
            return rd;
        }

        public void Read()
        {
            double ppm = 0;
            int data = 0;

            while (true)
            {
                if (reading)
                {
                    try
                    {
                        if (useport)
                        {
                            if (myPort.IsOpen)
                            {
                                if (!calibration)
                                {
                                    lock (syncLock)
                                    {
                                        data = Convert.ToInt32(myPort.ReadLine());
                                    }
                                    if (data == -1)
                                    {
                                        reading = false;
                                        data = 0;
                                    }
                                    else
                                    {
                                        data /= Config.Sample_count;
                                        ppm = _mq4.PPM(data);
                                        ppm = Math.Round(ppm, 3);
                                        _chartslive.Read(ppm);
                                        dgv.Rows.Add(time, ppm);
                                        Write_Textbox(ppm.ToString());
                                        time += Config.Sample_delay;
                                    }
                                }
                                else
                                {
                                    Write_Textbox("Kalibracja");
                                }
                            }
                        }else
                        {
                            ppm = Random_number();
                            _chartslive.Read(ppm);
                            dgv.Rows.Add(time, ppm);
                            Write_Textbox(ppm.ToString());
                            time += Config.Sample_delay;
                            Thread.Sleep(Config.Sample_delay);
                        }
                       
                    }
                    catch (ThreadAbortException tae)
                    {
                        Console.Write((string)tae.ExceptionState);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Reading", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void Write_Textbox(string data)
        {
            if (this.L_value.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(Write_Textbox);
                this.Invoke(d, new object[] { data });
            }
            else
            {
                this.L_value.Text = data;
            }
        }

        #endregion

        #region Export

        private void B_Export_excel_Click(object sender, EventArgs e)
        {
            if(dgv.RowCount > 1)
            {
                _export.Save_Excel(dgv);
            }
            else
            {
                MessageBox.Show("Pusty dane, nie ma sensu ekspertuj", "Pusty dane", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void B_Export_notepad_Click(object sender, EventArgs e)
        {
            if(dgv.RowCount > 1)
            {
                _export.Save_txt(dgv);
            }
            else
            {
                MessageBox.Show("Pusty dane, nie ma sensu eksportuj", "Pusty dane", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        #endregion

        #region Sample

        private void Load_Sample()
        {
            string[] sample_count = { "1", "5", "10", "25", "50", "100", "150", "200" };
            CB_sample_count.Items.AddRange(sample_count);
            CB_sample_count.SelectedIndex = 4;
            string[] sample_time = { "1", "2", "4", "5", "10", "20", "50", "100" };
            CB_sample_time.Items.AddRange(sample_time);
            CB_sample_time.SelectedIndex = 2;
            Config.Sample_count = Convert.ToInt32(CB_sample_count.SelectedItem);
            Config.Sample_time = Convert.ToInt32(CB_sample_time.SelectedItem);
            Config.Sample_delay = Config.Sample_count* Config.Sample_time;
            L_delay_value.Text = Config.Sample_delay.ToString();
        }

        private void CB_sample_count_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.Sample_count = Convert.ToInt32(CB_sample_count.SelectedItem);
            Config.Sample_delay = Config.Sample_count * Config.Sample_time;
            L_delay_value.Text = Config.Sample_delay.ToString();
        }

        private void CB_sample_time_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.Sample_time = Convert.ToInt32(CB_sample_time.SelectedItem);
            Config.Sample_delay = Config.Sample_count * Config.Sample_time;
            L_delay_value.Text = Config.Sample_delay.ToString();
        }

        #endregion       
    }
}
