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

        /// <summary>
        ///  打包数据 完成！
        /// </summary>
        public static byte[] packData(byte[] cmd, byte[] data)
        {
            int len = data.Length;
            byte[] result = new byte[len + 5];
            result[0] = 0xAA;
            result[1] = cmd[0];
            result[2] = BitConverter.GetBytes(len)[0];
            byte[] data_xor = new byte[2 + data.Length];
            data_xor[0] = cmd[0];
            data_xor[1] = result[2];
            Buffer.BlockCopy(data, 0, result, 3, data.Length);
            Buffer.BlockCopy(result, 1, data_xor, 0, data_xor.Length);
            Console.WriteLine(ByteToHexStr(data_xor));
            byte xor = Get_CheckXor(data_xor);
            Console.WriteLine(xor.ToString("x2"));
            result[result.Length - 2] = xor;
            result[result.Length - 1] = 0xCC;
            Console.WriteLine(ByteToHexStr(result));
            return result;
        }

        /// <summary>
        /// 按字节异或  完成！
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public  static byte Get_CheckXor(byte[] data)
        {
            byte CheckCode = 0;
            int len = data.Length;
            for (int i = 0; i < len; i++)
            {
                CheckCode ^= data[i];
            }
            return CheckCode;
        }


        /// <summary>
        /// 判断；两个byte数组是否完全相等   完成！
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool ArraysEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 获取\0终结符的字符串  完成！
        /// </summary>
        /// <param name="source"></param>
        /// <param name="beginIndex"></param>
        /// <returns></returns>
        public static string GetEndString(byte[] source, int beginIndex)
        {
            for (int i = beginIndex; i < source.Length; i++)
            {
                if (source[i] == 0x00)
                {
                    return Encoding.GetEncoding("GBK").GetString(source, beginIndex, i - beginIndex);
                }
            }
            return "";
        }


        /// <summary>
        /// byte[]转为16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ByteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        //将16进制的字符串转为byte[]   "01"-0x01
        public static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }
        /// <summary>
        /// 切分memberID
        /// </summary>
        public static void splitMemberId(ref string name,ref byte[] crc,ref string phone,string memberId)
        {
            if (memberId.Length==9) {
                //3+2+4
                name = memberId.Substring(0, 3);
                phone = memberId.Substring(3, 2);
                crc = strToToHexByte(memberId.Substring(5, 4));
            }
            if (memberId.Length == 10)
            {
                //4+2+4
                name = memberId.Substring(0, 4);
                phone = memberId.Substring(4, 2);
                crc = strToToHexByte(memberId.Substring(6, 4));
            }
            if (memberId.Length == 8) {
                //2+2+4
                name = memberId.Substring(0, 2);
                phone = memberId.Substring(2, 2);
                crc = strToToHexByte(memberId.Substring(4, 4));
            }


        }
        /// <summary>
        /// 切分memberID New
        /// </summary>
        public static void splitMemberId(ref string name, ref string phone, string memberId)
        {
            if (memberId.Length == 6)
            {
                //2+4
                name = memberId.Substring(0, 2);
                phone = memberId.Substring(3, 4);
               
            }
            if (memberId.Length == 7)
            {
                //3+4
                name = memberId.Substring(0, 3);
                phone = memberId.Substring(4, 4);
                
            }
            if (memberId.Length == 8)
            {
                //4+4
                name = memberId.Substring(0, 4);
                phone = memberId.Substring(5, 4);
                
            }
            if (memberId.Length == 9)
            {
                //5+4
                name = memberId.Substring(0, 5);
                phone = memberId.Substring(6, 4);
              
            }


        }

        public static byte[] CRC16(byte[] data)
        {
            int len = data.Length;
            if (len > 0)
            {
                ushort crc = 0xFFFF;

                for (int i = 0; i < len; i++)
                {
                    crc = (ushort)(crc ^ (data[i]));
                    for (int j = 0; j < 8; j++)
                    {
                        crc = (crc & 1) != 0 ? (ushort)((crc >> 1) ^ 0xA001) : (ushort)(crc >> 1);
                    }
                }
                byte hi = (byte)((crc & 0xFF00) >> 8);  //高位置
                byte lo = (byte)(crc & 0x00FF);         //低位置

                return new byte[] { hi, lo };
            }
            return new byte[] { 0, 0 };
        }

    }
}
