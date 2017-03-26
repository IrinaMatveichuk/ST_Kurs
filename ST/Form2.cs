using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace ST
{
    public class COMPORT
    {
        public SerialPort port;
        public Int32 speed;
        public bool my_logic_state; //логическое состояние этого порта
        public bool p_connected; //флаг на установку физического подключения
        public bool p_active; //флаг на поддержание физического соединения
        public bool l_connected; //флаг на установку логического соединения
        public bool linkactive; //флаг на поддержание логического соединения
        public int linkactive_try; //колво попыток для поддержания пользователя в активном состоянии
        public System.Windows.Forms.Timer logicConnectionTimer = new System.Windows.Forms.Timer(); //таймер на установку логического соединения
        public System.Windows.Forms.Timer send_timer = new System.Windows.Forms.Timer(); //таймер на отправку сообщения
        public System.Windows.Forms.Timer connectionTimer = new System.Windows.Forms.Timer(); //таймер физического соединения
    }
    public partial class Form2 : Form
    {
        private const byte START = 0xFF;
        private ConnectionManager _manager = new ConnectionManager();
        private PhysicalConnection _phys_manager = new PhysicalConnection();
        public static string selected_user;
        string this_path = Directory.GetCurrentDirectory();
        public static string path;
        public static COMPORT port1 = new COMPORT();
        public static COMPORT port2 = new COMPORT();
        public static List<COMPORT> ports = new List<COMPORT>();
        public static string current_user;
        private string message; //сообщение

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!port1.send_timer.Enabled && !port2.send_timer.Enabled)
            {
                message = MsgTextBox.Text;
                ConnectionManager.last_msg = message;
                if (message == "") emptyMsgLabel.Visible = true;
                else
                {
                    if (sendToAllCheck.Checked == true)
                    {
                        if (usersListBox.Items.Count == 0) MessageBox.Show("Нет пользователей в сети");
                        else
                        {
                            for (var i=0; i<usersListBox.Items.Count; i++)
                            {
                                if (ConnectionManager.Users.ContainsValue(Convert.ToString(usersListBox.Items[i])))
                                {
                                    foreach (var a in ConnectionManager.Users.Keys)
                                    {
                                        if (ConnectionManager.Users[a] == Convert.ToString(usersListBox.Items[i]))
                                        {
                                            _manager.WriteData(message, ConnectionManager.FrameType.DAT, false, a);
                                            a.send_timer.Start();
                                        }
                                    }
                                }
                            }
                            msgListBox.Items.Add("Я > " + message);
                            _manager.WriteHistory("Я > " + message);
                            ConnectionManager.last_msg_stat = false;
                        }
                    }
                    else
                    {
                        if (ConnectionManager.Users.ContainsValue(selected_user))
                        {
                            foreach (var a in ConnectionManager.Users.Keys)
                            {
                                if (ConnectionManager.Users[a] == selected_user)
                                {
                                    _manager.WriteData(message, ConnectionManager.FrameType.DAT, true, a);
                                    a.send_timer.Start();
                                }
                            }
                        }
                        msgListBox.Items.Add("Я [" + selected_user + "]> " + message);
                        _manager.WriteHistory("Я [" + selected_user + "]> " + message);
                        ConnectionManager.last_msg_stat = true;
                    }
                }
            }
            else MessageBox.Show("Подождите, идет отправка");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormClosing += Form2_FormClosing;
            usersListBox.Click += usersListBox_Click;
            path = Path.Combine(this_path, "History_" + current_user + ".txt");
            if (File.Exists(path))
                File.Delete(path);

            SetParametrs(port1, port2);

            sendToAllCheck.CheckedChanged += checkChanged;
            current_user = Form1.CurrentUser;
            disconnectButton.Enabled = false;
            path = Path.Combine(this_path, "History_" + current_user + ".txt");
            if (File.Exists(path))
                File.Delete(path);
            File.Create(path).Dispose();
            ConnectionManager.f2.CreateForm2(sendButton, connectButton, disconnectButton, msgListBox, MsgTextBox, usersListBox);
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            connectButton.Enabled = false;

            //msgListBox.Items.Add("SYSTEM> Ожидание подключения...");
            _phys_manager.Connect(port1, port2);
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            port1.my_logic_state = false;
            if (port1.p_active)
                _manager.WriteData(null, ConnectionManager.FrameType.DOWNLINK, false, port1);
            port2.my_logic_state = false;
            if (port2.p_active)
                _manager.WriteData(null, ConnectionManager.FrameType.DOWNLINK, false, port2);
            usersListBox.Items.Clear();
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        #region Timer на установку физического соединения
        private void connectionTimer1_Tick(object sender, EventArgs e)
        {
            if (port1.port.DsrHolding && !port1.p_active)
            {
                _manager.WriteData(null, ConnectionManager.FrameType.UPLINK, false, port1);
                port1.my_logic_state = true;
                port1.p_active = true;
                port1.logicConnectionTimer.Start();
            }
            else if (!port1.port.DsrHolding && port1.p_active)
            {

                msgListBox.Items.Add("SYSTEM> Проверьте соединение 1 кабеля");
                _manager.WriteHistory("SYSTEM> Проверьте соединение 1 кабеля");
                port1.logicConnectionTimer.Stop();
                ConnectionManager.ActivePorts[port1.port] = false;
                port1.l_connected = false;
                port1.linkactive = false;
                port1.my_logic_state = false;
                port1.p_connected = false;
                port1.p_active = false;
                if (usersListBox.Items.Contains(ConnectionManager.Users[port1]))
                    usersListBox.Items.Remove(ConnectionManager.Users[port1]);
            }
        }

        private void connectionTimer2_Tick(object sender, EventArgs e)
        {
            if (port2.port.DsrHolding && !port2.p_active)
            {
                _manager.WriteData(null, ConnectionManager.FrameType.UPLINK, false, port2);
                port2.my_logic_state = true;
                port2.p_active = true;
                port2.logicConnectionTimer.Start();
            }
            else if (!port2.port.DsrHolding && port2.p_active)
            {
                msgListBox.Items.Add("SYSTEM> Проверьте соединение 2 кабеля");
                port2.logicConnectionTimer.Stop();
                ConnectionManager.ActivePorts[port2.port] = false;
                port2.l_connected = false;
                port2.linkactive = false;
                port2.my_logic_state = false;
                port2.p_connected = false;
                port2.p_active = false;
                if (usersListBox.Items.Contains(ConnectionManager.Users[port2]))
                    usersListBox.Items.Remove(ConnectionManager.Users[port2]);
            }
        }
        #endregion

        #region Timer на уставку логического соединения
        private void logicConnectionTimer1_Tick(object sender, EventArgs e)
        {
            if (!port1.l_connected && port1.my_logic_state)
                _manager.WriteData(null, ConnectionManager.FrameType.UPLINK, false, port1);
            else if (port1.my_logic_state)
            {
                if (port1.linkactive_try != 3)
                {
                    _manager.WriteData(null, ConnectionManager.FrameType.LINKACTIVE, false, port1);
                    port1.linkactive_try--;
                }
                else
                {
                    ConnectionManager.ActivePorts[port1.port] = false;
                    port1.l_connected = false;
                    port1.linkactive_try = 0;
                }
            }
        }

        private void logicConnectionTimer2_Tick(object sender, EventArgs e)
        {
            if (!port2.l_connected && port2.my_logic_state)
                _manager.WriteData(null, ConnectionManager.FrameType.UPLINK, false, port2);
            else if (port2.my_logic_state)
            {
                if (port2.linkactive_try != 3)
                {
                    _manager.WriteData(null, ConnectionManager.FrameType.LINKACTIVE, false, port2);
                    port2.linkactive_try--;
                }
                else
                {
                    ConnectionManager.ActivePorts[port2.port] = false;
                    port2.l_connected = false;
                    port2.linkactive_try = 0;
                }
            }
        }
        #endregion

        #region Событие получения данных на порт
        private void comPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(1000);
            if (Form1.ComPort1.BytesToRead != 0)
            {
                switch (Form1.ComPort1.ReadByte())
                {
                    case START:
                        {
                            _manager.FrameAnalysis((byte)Form1.ComPort1.ReadByte(), port2, msgListBox, usersListBox, port1);
                        }
                        break;
                    default:
                        _manager.WriteData(null, ConnectionManager.FrameType.RET, true, port1);
                        break;
                }
            }
        }

        private void comPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(1000);
            if (Form1.ComPort2.BytesToRead != 0)
            {
                switch (Form1.ComPort2.ReadByte())
                {
                    case START:
                        {
                            _manager.FrameAnalysis((byte)Form1.ComPort2.ReadByte(), port1, msgListBox, usersListBox, port2);
                        }
                        break;
                    default:
                        _manager.WriteData(null, ConnectionManager.FrameType.RET, true, port2);
                        break;
                }
            }
        }
        #endregion

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Close();
        }

        private void usersListBox_Click(object sender, EventArgs e)
        {
             //selected_user = usersListBox.SelectedItem.ToString();
             selected_user = Convert.ToString(usersListBox.Items[usersListBox.SelectedIndex]);
             if (!sendToAllCheck.Checked)
                sendToLabel.Text = "Получатель: " + selected_user;
        }

        private void checkChanged(object sender, EventArgs e)
        {
            if (sendToAllCheck.Checked)
            {
                sendToLabel.Text = "Получатель: все";
            }
            else
            {
                if (selected_user == "")
                   sendToLabel.Text = "Получатель не выбран";
                else sendToLabel.Text = "Получатель: " + selected_user;
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoForm info = new InfoForm();
            info.ShowDialog();
        }

        private void посмотретьИсториюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(path);
        }

        private void SetParametrs(COMPORT port1, COMPORT port2)
        {
            port1.port = Form1.ComPort1;
            port1.port.DataReceived += comPort1_DataReceived;
            port1.speed = Convert.ToInt32(Form1.com1_speed);
            port1.l_connected = false;
            port1.linkactive = false;
            port1.my_logic_state = false;
            port1.p_active = false;
            port1.p_connected = false;
            port1.linkactive_try = 0;
            port1.logicConnectionTimer.Tick += new EventHandler(logicConnectionTimer1_Tick);
            port1.connectionTimer.Tick += new EventHandler(connectionTimer1_Tick);
            port1.logicConnectionTimer.Interval = 7000;

            port2.port = Form1.ComPort2;
            port2.port.DataReceived += comPort2_DataReceived;
            port2.speed = Convert.ToInt32(Form1.com2_speed);
            port2.l_connected = false;
            port2.linkactive = false;
            port2.my_logic_state = false;
            port2.p_active = false;
            port2.p_connected = false;
            port2.linkactive_try = 0;
            port2.logicConnectionTimer.Tick += new EventHandler(logicConnectionTimer2_Tick);
            port2.connectionTimer.Tick += new EventHandler(connectionTimer2_Tick);
            port2.logicConnectionTimer.Interval = 7000;
        }
    }
}
