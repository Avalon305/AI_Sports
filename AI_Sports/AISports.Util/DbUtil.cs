﻿
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace AI_Sports.Util
{


   public class DbUtil
    {

        private static string DbName;
        private static string DbUserName;
        private static string DbPassword;
        private static string DbUrl;
        private static string connstr;

        private DbUtil()
        {

        }
        /// <summary>
        /// 静态代码块初始化
        /// </summary>
        static DbUtil()
        {
            
            DbName = "ai_sports";
            DbUserName = "root";  
            DbPassword = "hengxingqingdao";
            DbUrl = "127.0.0.1";

            connstr = string.Format("server={0};user id={1}; password={2}; database={3}; pooling=true;Charset=utf8", DbUrl, DbUserName, DbPassword, DbName);
        }
 
        public static MySqlConnection getConn()
        {
            return new MySqlConnection(connstr);
        }



    }


}