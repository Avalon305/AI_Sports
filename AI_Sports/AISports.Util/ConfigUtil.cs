using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISports.Util
{
    class ConfigUtil
    {
        private static readonly byte[] PASSWORD = { 0x12, 0x23, 0xee, 0xff, 0xa2, 0x7c, 0x89, 0x0e, 0x63, 0x6B, 0x2D, 0x7A, 0x68, 0x75, 0x78, 0x67 };

        /// <summary>
        /// 获取配置文件的指定值，无加密
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultVal">默认值</param>
        /// <returns></returns>
        public static string Get(string key, string defaultVal)
        {
            string val = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(val))
            {
                return defaultVal;
            }
            return val;
        }

        /// <summary>
        /// 获取配置文件中的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int Get(string key, int defaultVal)
        {
            string val = ConfigurationManager.AppSettings[key];
           
            if (string.IsNullOrEmpty(val))
            {
                return defaultVal;
            }
            return int.Parse(val); ;
        }

        /// <summary>
        /// 获取配置文件的指定值，无加密,无值时候返回null
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string Get(string key)
        {
            return Get(key, null);
        }
    }
}
