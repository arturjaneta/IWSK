using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Int32 DataBits;
        private StopBits StopBits;
        private Parity Parity;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(SerialPort.GetPortNames());

            comboBox2.Items.Add(150);
            comboBox2.Items.Add(300);
            comboBox2.Items.Add(600);
            comboBox2.Items.Add(1200);
            comboBox2.Items.Add(1800);
            comboBox2.Items.Add(2400);
            comboBox2.Items.Add(4800);
            comboBox2.Items.Add(7200);
            comboBox2.Items.Add(9600);
            comboBox2.Items.Add(14400);
            comboBox2.Items.Add(19200);
            comboBox2.Items.Add(31250);
            comboBox2.Items.Add(38400);
            comboBox2.Items.Add(56000);
            comboBox2.Items.Add(57600);
            comboBox2.Items.Add(76800);
            comboBox2.Items.Add(115200);

            comboBox3.Items.Add("7E1");
            comboBox3.Items.Add("7O1");
            comboBox3.Items.Add("7N2");
            comboBox3.Items.Add("8E1");
            comboBox3.Items.Add("8O1");
            comboBox3.Items.Add("8N2");

            comboBox4.Items.Add("brak kontroli");
            comboBox4.Items.Add("DTR/DSR");
            comboBox4.Items.Add("RTS/CTS");
            comboBox4.Items.Add("XON/XOFF");

            comboBox5.Items.Add("brak terminatora");
            comboBox5.Items.Add("CR");
            comboBox5.Items.Add("LF");
            comboBox5.Items.Add("CR-LF");
            comboBox5.Items.Add("własny");

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;

            textBox3.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text); 
                serialPort1.PortName = comboBox1.Text;   
                serialPort1.DataBits = DataBits;    
                serialPort1.StopBits = StopBits; 
                serialPort1.Parity = Parity;   
                serialPort1.Open();

                if (textBox3.Text.Length == 0 || textBox3.Text.Length > 2)
                {
                    serialPort1.Write(textBox1.Text.ToString());

                    if (comboBox5.Text=="CR"|| comboBox5.Text == "CR-LF")
                    {
                        serialPort1.Write("\r");
                    }
                    if (comboBox5.Text == "LF" || comboBox5.Text == "CR-LF") 
                    {
                        serialPort1.Write("\n");
                    }

                }
                else
                {
                    serialPort1.Write(textBox1.Text.ToString() + textBox3.Text.ToString());
                }

                textBox1.Clear();
                //serialPort1.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort1.ReadExisting();

     
            if (textBox2.InvokeRequired)
            {
                Action act = () => textBox2.Text += data;

 
                Invoke(act); 
            }
            else
            {
                textBox2.Text += data;
            }

        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)    
                serialPort1.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.Text)
            {
                case "7E1":
                    DataBits=7;
                    StopBits= (StopBits)Enum.Parse(typeof(StopBits), "One");
                    Parity= (Parity)Enum.Parse(typeof(Parity), "Even");
                    break;
                case "7O1":
                    DataBits = 7;
                    StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                    Parity = (Parity)Enum.Parse(typeof(Parity), "Odd");
                    break;
                case "7N2":
                    DataBits = 7;
                    StopBits = (StopBits)Enum.Parse(typeof(StopBits), "Two");
                    Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                    break;
                case "8E1":
                    DataBits = 8;
                    StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                    Parity = (Parity)Enum.Parse(typeof(Parity), "Even");
                    break;
                case "8O1":
                    DataBits = 8;
                    StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                    Parity = (Parity)Enum.Parse(typeof(Parity), "Odd");
                    break;
                case "8N2":
                    DataBits = 8;
                    StopBits = (StopBits)Enum.Parse(typeof(StopBits), "Two");
                    Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                    break;
            }
        }
    }
}
