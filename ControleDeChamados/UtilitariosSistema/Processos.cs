using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilitariosSistema
{
    public static class Processos
    {
        public static string ProcessadorSerial()
        {
            string _tmp1 = String.Empty;
            ManagementObjectCollection mbsList = null;
            ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
            mbsList = mbs.Get();
            foreach (ManagementObject mo in mbsList)
            {
                _tmp1 = _tmp1 + mo["ProcessorID"].ToString();
            }
            return _tmp1;
        }
    }
}
