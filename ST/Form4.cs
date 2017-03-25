using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ST
{
    public partial class Form4 : Form
    {
        private PhysicalConnection _phys_manager = new PhysicalConnection();
        private ConnectionManager _manager = new ConnectionManager();
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            errorLabel.Visible = false;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            var allUsers = new List<string> { "1", "2", "Ира", "Уля", "Марина", "Ira", "Ulya", "Marina" };
            if (!allUsers.Contains(userTextBox.Text))
                errorLabel.Visible = true;
            else
            {
                Form2.current_user = userTextBox.Text;
                Form2.port1.my_logic_state = true;
                if (Form2.port1.l_connected)
                    _manager.WriteData(null, ConnectionManager.FrameType.SUNH, false, Form2.port1);
                Form2.port2.my_logic_state = true;
                if (Form2.port2.l_connected)
                    _manager.WriteData(null, ConnectionManager.FrameType.SUNH, false, Form2.port2);
                this.Close();
            }
        }
    }
}
