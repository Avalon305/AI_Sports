using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Util
{
    class SerialPortUtil
    {
        /// <summary>
        /// 初始化搜索到的串口
        /// </summary>
        public static List<String> initPort()
        {
            string[] names = SerialPort.GetPortNames();
            List<String> list = new List<String>();
            foreach (string name in names)
            {
                list.Add(name);
            }
            return list;
        }
    }
}
