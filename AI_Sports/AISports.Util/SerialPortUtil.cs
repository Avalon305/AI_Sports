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
            byte xor = XorByByte(data_xor);
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
        public static byte XorByByte(byte[] bytes)
        {
            byte temp = bytes[0];
            for (int i = 2; i < bytes.Length; i++)
            {
                temp ^= bytes[i];
            }


            return temp;
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

    }
}
