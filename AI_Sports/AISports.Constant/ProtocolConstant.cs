using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Constant
{
    class ProtocolConstant
    {
        /// <summary>
        /// 加密狗通讯加密密钥
        /// </summary>
        public static readonly byte[] USB_DOG_PASSWORD = { 0x4D, 0x61, 0x6E, 0x49, 0x6E, 0x42, 0x6C, 0x61, 0x63, 0x6B, 0x2D, 0x7A, 0x68, 0x75, 0x78, 0x67 };
        /// <summary>
        /// 加密狗鉴权密钥
        /// </summary>
        public static readonly byte[] USB_DOG_AUTH_PASSWORD = { 0x41, 0x6C, 0x69, 0x65, 0x6E, 0x74, 0x65, 0x6B, 0x45, 0x78, 0x70, 0x6C, 0x6F, 0x72, 0x65, 0x72 };
        /// <summary>
        /// 加密狗的内容
        /// </summary>
        public static byte[] USB_DOG_CONTENT;
       
    }
}
