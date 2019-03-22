using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Constant
{
    class CommondConstant
    {
        //发卡命令字
        public static byte[] sendCard = { 0x01 };
        //读卡命令字
        public static byte[] readCard = { 0x02 };
        //应答命令字
        public static byte[] ResSendCard = { 0x81 };
    }
}
