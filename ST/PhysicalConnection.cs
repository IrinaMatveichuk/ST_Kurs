using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Timers;

namespace ST
{
    class PhysicalConnection
    {
        public void Connect(COMPORT port1, COMPORT port2)
        {
            port1.port.DtrEnable = true;
            port1.my_logic_state = true;
            port1.connectionTimer.Start();

            port2.port.DtrEnable = true;
            port2.my_logic_state = true;
            port2.connectionTimer.Start();
        }
    }
}
