using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace AI_Sports.AISports.Util
{

        /// <summary>
        /// 协议解析通用工具类
        /// </summary>
        public class ProtocolUtil
        {
            private static Int16 serialNo = 0;

            /// <summary>
            /// 获取\0终结符所在的用户ID
            /// </summary>
            /// <param name="source"></param>
            /// <param name="beginIndex"></param>
            /// <returns></returns>
            public static string GetEndUserIdString(byte[] source, int beginIndex)
            {
                for (int i = beginIndex; i < beginIndex + 32; i++)
                {
                    if (source[i] == 0x00)
                    {
                        return Encoding.GetEncoding("GBK").GetString(source, beginIndex, i - beginIndex);
                    }
                }
                return "";
            }
            /// <summary>
            /// 获取\0终结符的字符串
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

            public static Int16 GetSerialNo()
            {
                if (serialNo == Int16.MaxValue)
                {
                    serialNo = 0;
                }
                return serialNo++;
            }
            /// <summary>
            /// string转为BCD码，若string有奇数个字符，byte[]长度为len/2+1,左侧补零
            /// </summary>
            /// <param name="source"></param>
            /// <returns></returns>
            public static byte[] StringToBcd(string source)
            {
                source = source.Trim();
                if (source.Length % 2 != 0)
                {
                    source = "0" + source;
                }
                byte[] result = new byte[source.Length / 2];
                for (int i = 0; i < source.Length / 2; i++)
                {
                    result[i] = Convert.ToByte(source.Substring(i * 2, 2), 16);
                }

                return result;
            }

            
            /// <summary>
            /// 将0x7D 0x02,0x7D 0x01转回0x7E和0x7D
            /// </summary>
            /// <param name="source"></param>
            /// <returns></returns>
            public static byte[] UnTransfer(byte[] source)
            {
                List<byte> list = new List<byte>();
                list.Add(source[0]);

                for (int i = 1; i < source.Length - 1; i++)
                {
                    if (source[i] == 0x7D)
                    {
                        if (source[i + 1] == 0x01)
                        {
                            list.Add(0x7D);
                        }
                        else if (source[i + 1] == 0x02)
                        {
                            list.Add(0x7E);
                        }
                        i++;
                    }
                    else
                    {
                        list.Add(source[i]);
                    }
                }
                list.Add(source[source.Length - 1]);
                return list.ToArray();
            }
            /// <summary>
            /// 7E和7D转义
            /// </summary>
            /// <param name="source"></param>
            /// <returns></returns>
            public static byte[] Transfer(byte[] source)
            {
                List<byte> list = new List<byte>(source);

                for (int i = 1; i < list.Count - 1; i++)
                {
                    if (list[i] == 0x7E)
                    {
                        list[i] = 0x7D;
                        list.Insert(i + 1, 0x02);

                    }
                    else if (list[i] == 0x7D)
                    {
                        list.Insert(i + 1, 0x01);
                    }
                }


                return list.ToArray();

            }
            public static string BytesToString(byte[] InBytes)
            {
                string StringOut = "";
                foreach (byte InByte in InBytes)
                {
                    StringOut = StringOut + String.Format("{0:X2}", InByte);
                }
                return StringOut;
            }

            /// <summary>
            /// 判断两个数组是否相等
            /// </summary>
            /// <param name="arr1"></param>
            /// <param name="arr2"></param>
            /// <returns></returns>
            public static Boolean ArrayEqual(byte[] arr1, byte[] arr2)
            {
                if (arr1.Length != arr2.Length)
                {
                    return false;
                }
                for (int i = 0; i < arr2.Length; i++)
                {
                    if (arr1[i] != arr2[i])
                    {
                        return false;
                    }
                }
                return true;
            }

            /// <summary>
            /// 按字节异或
            /// </summary>
            /// <param name="bytes"></param>
            /// <returns></returns>
            public static byte XorByByte(byte[] bytes)
            {
                byte temp = bytes[0];
                for (int i = 1; i < bytes.Length; i++)
                {
                    temp ^= bytes[i];
                }
                return temp;
            }
            /// <summary>
            /// 按字节异或
            /// </summary>
            /// <param name="bytes"></param>
            /// <param name="beginIndex"></param>
            /// <param name="len"></param>
            /// <returns></returns>
            public static byte XorByByte(byte[] bytes, int beginIndex, int len)
            {
                byte temp = bytes[beginIndex];
                for (int i = beginIndex + 1; i < beginIndex + len; i++)
                {
                    temp ^= bytes[i];
                }
                return temp;
            }

            public static string BcdToString(byte[] source, int startIndex, int len)
            {
                string outString = "";
                for (int i = startIndex; i < startIndex + len; i++)
                {
                    outString += source[i].ToString("X2");
                }
                return outString;
            }
            public static byte BcdToInt(byte b)
            {
                //高四位    
                byte b1 = (byte)((b >> 4) & 0xF);
                //低四位    
                byte b2 = (byte)(b & 0xF);

                return (byte)(b1 * 10 + b2);
            }

            /// <summary>
            ///  打包发卡数据
            /// </summary>
            /// <param name="cmd">命令字</param>
            /// <param name="data">数据</param>
            /// <returns></returns>
            public static byte[] packHairpinData(byte cmd, byte[] data)
            {
                int len = data.Length;

                byte[] result = new byte[len + 5];

                result[0] = 0xAA;
                result[1] = cmd;
                result[2] = (byte)data.Length;

                for (int i = 0; i < data.Length; i++)
                {
                    result[3 + i] = data[i];
                }

                //异或校检
                byte xor = XorByByte(result.Skip(1).Take(len + 2).ToArray());
                result[result.Length - 2] = xor;
                Console.WriteLine(ByteToStringOk(result));

                //协议尾
                result[result.Length - 1] = 0xCC;

                return result;
            }

            public static string ByteToStringOk(byte[] InBytes)
            {
                string StringOut = "";
                foreach (byte InByte in InBytes)
                {
                    StringOut = StringOut + String.Format("{0:X2} ", InByte);
                }
                return StringOut;
            }
        }
    }

