using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Timers;

namespace ST
{
    class Form2Form
    {
        public Button send;
        public Button disconnect;
        public Button connect;
        public ListBox messages;
        public TextBox msg_to_send;
        public ListBox users;
        public void CreateForm2(Button send1, Button connect1, Button disconnect1, ListBox messages1, TextBox msg_to_send1, ListBox users1)
        {
            send = send1;
            connect = connect1;
            disconnect = disconnect1;
            messages = messages1;
            msg_to_send = msg_to_send1;
            users = users1;
        }
    }
  
    class ConnectionManager
    {
        public static Form2Form f2 = new Form2Form();
        public PhysicalConnection _phys_connect = new PhysicalConnection();
        private CycleCode coder = new CycleCode();
        public enum MessageType
        {
            Incoming,
            Outgoing,
            Normal,
            Warning,
            Error,
            Public,
            Private
        };
        public enum FrameType : byte
        {
            UPLINK, //кадр установки соединения
            ACK_UPLINK,
            ACK,
            ACK_DOWNLINK,
            ACK_LINKACTIVE, //кадры -квитанция
            RET_UPLINK,
            RET_DOWNLINK,
            RET_LINKACITVE,
            RET_DAT,
            RET, //кадры - ARQ
            DOWNLINK, //кадр разрыва соединения
            LINKACTIVE,
            DAT,
            SUNH, //Кадр синхронизации пользователей
            ACK_SUNH,
            SUNHP,
            ACK_SUNHP
        }
        private const byte Start = 0xFF; //стартовый бит
        public static Dictionary<COMPORT, string> Users = new Dictionary<COMPORT, string>();
        public static Dictionary<SerialPort, Int32> Speeds = new Dictionary<SerialPort, Int32>();
        public static Dictionary<SerialPort, bool> ActivePorts = new Dictionary<SerialPort, bool>();
        private int reSendCount = 3;
        private byte previousOperation;
        public static string last_msg;
        public static bool last_msg_stat;


        public void WriteData(string msg, FrameType currentFrameType, bool _private, COMPORT comPort) //Запись в порт
        {
            //lastMsg = msg;
            var frameFields = new List<byte> { Start, (byte)currentFrameType };
            switch (currentFrameType)
            {
                case FrameType.DAT:
                    try
                    {
                        if (string.IsNullOrEmpty(msg))
                            return;
                        if (_private) { frameFields.Add(1); }
                        else { frameFields.Add(0); }
                        frameFields.Add((byte)coder.Code(msg).Length);
                        frameFields.AddRange(coder.Code(msg));
                        comPort.port.Write(frameFields.ToArray(), 0, frameFields.Count);
                    }
                    catch (FormatException ex)
                    {
                        DisplayData(MessageType.Error, ex.Message, false, f2.messages, comPort);
                    }
                    break;
                case FrameType.ACK_SUNH:
                    frameFields = new List<byte> { Start, (byte)currentFrameType };
                    frameFields.Add((byte)coder.Code(msg).Length);
                    frameFields.AddRange(coder.Code(msg));
                    comPort.port.Write(frameFields.ToArray(), 0, frameFields.Count);
                    break;
                case FrameType.SUNHP:
                    frameFields = new List<byte> { Start, (byte)currentFrameType };
                    frameFields.Add((byte)coder.Code(msg).Length);
                    frameFields.AddRange(coder.Code(msg));
                    comPort.port.Write(frameFields.ToArray(), 0, frameFields.Count);
                    break;
                default:
                    //DisplayData(MessageType.Outgoing, DateTime.Now + " отправили " + currentFrameType + "\n", false, f2.messages, comPort);
                    comPort.port.Write(frameFields.ToArray(), 0, 2);
                    break;
            }
        }

        private void DisplayData(MessageType type, string msg, bool isMsg, ListBox list, COMPORT port)
        {
            string user;
            string msg_to_display;
            try { user = Users[port]; }
            catch { user = ""; }
            if (type == MessageType.Private)
            {
                msg_to_display = user + " [личное] > " + msg;
            }
            else
            {
                if (isMsg) msg_to_display = user + "> " + msg;
                else msg_to_display = "SYSTEM> " + msg;
            }
            list.Invoke(new Action(() => { list.Items.Add(msg_to_display); }));
            WriteHistory(msg_to_display);
            list.SelectedItem = -1;
        } //Вывод сообщений на форму

        public void FrameAnalysis(byte mybyte, COMPORT comPort, ListBox list, ListBox list2, COMPORT port) //Анализ приходящих кадров
        {
            previousOperation = mybyte;
            switch (mybyte)
            {
                case (byte)FrameType.UPLINK:
                    //DisplayData(MessageType.Incoming, DateTime.Now + " UPLINK \n", false, list, port);
                    if (port.my_logic_state)
                    {
                        WriteData(null, FrameType.ACK_UPLINK, false, port);
                    }
                    break;
                case (byte)FrameType.ACK_UPLINK:
                    //DisplayData(MessageType.Incoming, DateTime.Now + " ACK_UPLINK \n", false, list, port);
                    port.l_connected = true;
                    if (port.p_connected)
                        WriteData(null, FrameType.SUNH, false, port);
                    else
                    {
                        WriteData(Convert.ToString(port.speed), FrameType.SUNHP, false, port);
                    }
                    break;
                case (byte)FrameType.LINKACTIVE:
                    //DisplayData(MessageType.Incoming, DateTime.Now + " LINKACTIVE \n", false, list, port);
                    if (port.my_logic_state)
                    {
                        WriteData(null, FrameType.ACK_LINKACTIVE, false, port);
                    }
                    break;
                case (byte)FrameType.ACK_LINKACTIVE:
                    //DisplayData(MessageType.Incoming, DateTime.Now + " ACK_LINKACTIVE \n", false, list, port);
                    port.linkactive_try = 0;
                    break;
                case (byte)FrameType.SUNHP:
                    var Count = Convert.ToInt32(port.port.ReadByte());
                    var text = new byte[Count];
                    port.port.Read(text, 0, Count);
                    var decoded = coder.Decode(text);
                    if (Convert.ToInt32(decoded) >= port.speed)
                        port.port.BaudRate = port.speed;
                    else if (Convert.ToInt32(decoded) < port.speed)
                        port.port.BaudRate = Convert.ToInt32(decoded);
                    port.p_connected = true;
                    WriteData(null, FrameType.SUNH, false, port);
                    break;
                case (byte)FrameType.SUNH:
                    //DisplayData(MessageType.Incoming, DateTime.Now + " SUNH \n", false, list, port);
                    WriteData(Form2.current_user, FrameType.ACK_SUNH, false, port);
                    break;
                case (byte)FrameType.ACK_SUNH:
                    //DisplayData(MessageType.Incoming, DateTime.Now + " ACK_SUNH \n", false, list, port);
                    Count = Convert.ToInt32(port.port.ReadByte());
                    text = new byte[Count];
                    port.port.Read(text, 0, Count);
                    decoded = coder.Decode(text);
                    if (Users.ContainsKey(port))
                        Users.Remove(port);
                    Users.Add(port, decoded);
                    f2.disconnect.Invoke(new Action(() => { f2.disconnect.Enabled = true; }));
                    f2.messages.Invoke(new Action(() => { DisplayData(MessageType.Public, "Пользователь " + decoded + " активен", false, f2.messages, port); }));                   
                    ShowUsers(decoded, list2);
                    break;
                case (byte)FrameType.DOWNLINK:
                    //DisplayData(MessageType.Incoming, DateTime.Now + " DOWNLINK \n", false, list, port);
                    DisplayData(MessageType.Incoming, " Пользоваель " + Form2.current_user + " вышел из сети", false, list, port);
                    port.l_connected = false; //сделали порт логически неактивным
                    if (f2.users.Items.Contains(Users[port]))
                        f2.users.Invoke(new Action(() => { f2.users.Items.Remove(Users[port]); })); //убрали имя из списка
                    break;
                case (byte)FrameType.DAT:
                    //DisplayData(MessageType.Incoming, DateTime.Now + " DAT \n", false, list);
                    var sendUser = port.port.ReadByte();
                    Count = Convert.ToInt32(port.port.ReadByte());
                    text = new byte[Count];
                    port.port.Read(text, 0, Count);
                    decoded = coder.Decode(text);
                    if (decoded == "") WriteData(null, FrameType.RET_DAT, false, port);
                    else
                    {
                        if (sendUser == 0)
                            DisplayData(MessageType.Public, decoded, true, list, port);
                        else if (sendUser == 1)
                        {
                            DisplayData(MessageType.Private, decoded, true, list, port);
                        }
                    }
                    WriteData(null, FrameType.ACK, false, port);
                    break;
                case (byte)FrameType.ACK:
                    reSendCount = 3;
                    port.send_timer.Stop();
                    //DisplayData(MessageType.Incoming, DateTime.Now + " ACK \n", false, list);
                    break;
                default:
                    DisplayData(MessageType.Normal, DateTime.Now + " unknow frame \n", false, list, port);
                    break;
                case (byte)FrameType.RET_DAT:
                    //DisplayData(MessageType.Incoming, DateTime.Now + " RET \n", false, list);
                    if (reSendCount > 0)
                    {
                        reSendCount--;
                        if (last_msg_stat)
                            WriteData(last_msg, FrameType.DAT, true, port);
                        else
                            WriteData(last_msg, FrameType.DAT, false, port);
                    }
                    else
                    {
                        reSendCount = 3;
                    }
                    break;
                case (byte)FrameType.RET:
                    if (previousOperation != (byte)FrameType.DAT)
                        FrameAnalysis(previousOperation, comPort, list, list2, port);
                    break;
            }
        }

        public void ShowUsers(string name, ListBox list) //Обновление активных пользователей на форме
        {
            list.Invoke(new Action(() => { list.Items.Add(name); }));
        }
        
        public void WriteHistory(string msg) //Запись в файл истории
        {
            File.AppendAllText(Form2.path, msg + Environment.NewLine, Encoding.Default);
        }
    }
}
