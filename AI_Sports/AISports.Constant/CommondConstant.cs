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
        //失败
        public static byte error = 0x01;
        //成功
        public static byte success = 0x00;
        //无卡
        public static byte noCard = 0x02;
        //应答命令字
        public static byte[] ResSendCard = { 0x81 };
    }
}
