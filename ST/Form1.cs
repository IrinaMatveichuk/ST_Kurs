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

namespace ST
{
    public partial class Form1 : Form
    {
        public static string CurrentUser;
        public static string com1_num;
        public static string com2_num;
        public static string com1_speed;
        public static string com2_speed;
        public static SerialPort ComPort1 = new SerialPort();
        public static SerialPort ComPort2 = new SerialPort();
        public Form1 current_form = (ST.Form1)Form1.ActiveForm;
        public bool port1_check;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
            string[] ports = SerialPort.GetPortNames();
            comPortNum1.Items.Clear();
            comPortNum1.Items.AddRange(ports);
            comPortNum2.Items.Clear();
            comPortNum2.Items.AddRange(ports);
            comPortNum1.SelectedIndex = 0;
            comPortNum2.SelectedIndex = 2;
            speedComboBox1.SelectedIndex = 0;
            speedComboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            port1_check = false;
            var allUsers = new List<string> { "A", "B", "C", "D", "Ира", "Уля", "Марина", "Ira", "Ulya", "Marina"};
            if (!allUsers.Contains(userName.Text))
                errorLabel.Visible = true;
            else
            {
                #region Настойка параметров передачи
                com1_speed = speedComboBox1.Items[speedComboBox1.SelectedIndex].ToString();
                com2_speed = speedComboBox2.Items[speedComboBox2.SelectedIndex].ToString();
                try
                {
                    com1_num = comPortNum1.Items[comPortNum1.SelectedIndex].ToString();
                    ComPort1.PortName = com1_num;
                    ComPort1.Open();
                    ComPort1.DiscardInBuffer();
                    port1_check = true;
                }
                catch
                {
                    MessageBox.Show("Не удалось открыть указанные порты");
                }
                if (port1_check)
                {
                    try
                    {
                        com2_num = comPortNum2.Items[comPortNum2.SelectedIndex].ToString();
                        ComPort2.PortName = com2_num;
                        ComPort2.Open();
                        ComPort2.DiscardInBuffer();
                        ConnectionManager.Speeds.Add(ComPort1, Convert.ToInt32(com1_speed));
                        ConnectionManager.Speeds.Add(ComPort2, Convert.ToInt32(com2_speed));
                        //ConnectionManager.ActivePorts.Add(ComPort1, false);
                        //ConnectionManager.ActivePorts.Add(ComPort2, false);
                        CurrentUser = userName.Text;
                        Form2 f2 = new Form2();
                        f2.Show();
                        this.Hide();
                    }
                    catch
                    {
                        ComPort1.Close();
                        MessageBox.Show("Не удалось открыть указанные порты");
                    }
                }
                #endregion
            }
        }

        public void OpenForm1(bool _this)
        {
            if (_this)
                this.Show();
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }
    }
}
