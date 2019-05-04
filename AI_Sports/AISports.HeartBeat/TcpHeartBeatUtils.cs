using AI_Sports.AISports.Service;
using AI_Sports.AISports.Util;
using AI_Sports.Entity;
using AI_Sports.Util;
using Com.Bdl.Proto;
using Dapper;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISports.HeartBeat
{

    public class TcpHeartBeatUtils
    {
        public static void WriteLogFile(string content)
        {

            string path = AppDomain.CurrentDomain.BaseDirectory;
            path = System.IO.Path.Combine(path
            , "ZLogs\\");

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            string fileFullName = System.IO.Path.Combine(path
            , string.Format("{0}.txt", DateTime.Now.ToString("yyyyMMdd-HHmm")));


            using (StreamWriter output = System.IO.File.AppendText(fileFullName))
            {
                output.WriteLine(content);
                output.Close();
            }

        }

        /// <summary>
        /// 获取当前心跳
        /// </summary>
        /// <returns></returns>
        public static HeartbeatRequest GetHeartBeatByCurrent()
        {
            HeartbeatRequest sendHeartBeat = new HeartbeatRequest();
            SystemSettingService systemSettingService = new SystemSettingService();
            var result = systemSettingService.GetSystemSetting();
            if (result == null) {
                return null;
            }
            //机器码mac地址从数据库取
            sendHeartBeat.UniqueId = result.Set_Unique_Id;
            //bdl_system_setting表装换成json，赋值
            sendHeartBeat.SettingJSON = JsonTools.Obj2JSONStrNew<SystemSettingEntity>(result);
            //项目名 智能健身赋值
            sendHeartBeat.ProductName = "智能健身";
            //使用期限
            sendHeartBeat.UseDeadTime = result.Auth_OfflineTime.ToString().Replace("/", "-");
            //冻结
            if (result.User_Status == SystemSettingEntity.USER_STATUS_FREEZE)
            {
                //是否为冻结状态的心跳,这里不能从数据库取，否则，云通知本地锁死，本地改状态后，会再次通知云锁死本机，陷入死循环
                //状态 正常0和锁定1
                sendHeartBeat.Status = 1.ToString();
            }
            //正常
            else if(result.User_Status == SystemSettingEntity.USER_STATUS_GENERAL)
            {
                //状态 正常0和锁定1
                //默认为正常心跳
                sendHeartBeat.Status = 0.ToString();
            }
            return sendHeartBeat;
        }

        //增加使用时间
        //根据用户名增加使用时间
        public static void AddUseTime(HeartbeatResponse heartbeatResponse)
        {
            int status;
            //将接受到的字符串(yyyy-mm-dd)转换成Datetime格式
            DateTime Offlinetime = Convert.ToDateTime(heartbeatResponse.Attachment);
            
            //如果返回的时间等于9999/12/31 就把状态设为永久离线 
            if (Offlinetime.ToShortDateString().ToString() == DateTime.MaxValue.ToString("yyyy/MM/dd"))
            {
                using (var conn = DbUtil.getConn())
                {
                    Console.WriteLine("________________________________________________________设为永久离线");
                    const string query = "UPDATE bdl_system_setting SET user_status = @User_Status,auth_offlinetime = @Auth_Offlinetime";

                    conn.Execute(query, new { User_Status = SystemSettingEntity.USER_STATUS_FREE, Auth_Offlinetime = Offlinetime });
                }
            }
            //如果不是9999/12/31就只更改时间，不改变状态
            else
            {
                using (var conn = DbUtil.getConn())
                {
                    Console.WriteLine("________________________________________________________增加使用时间"+Offlinetime);
                    const string query = "UPDATE bdl_system_setting SET auth_offlinetime = @Auth_Offlinetime";
                    conn.Execute(query, new { Auth_Offlinetime = Offlinetime });
                }
            }
            
        }
        //上锁
        //根据用户名改变状态设为冻结状态，时间未改动。
        public static void LockUse(HeartbeatResponse heartbeatResponse)
        {
            //将接受到的字符串(yyyy-mm-dd)转换成Datetime格式
            //DateTime Offlinetime = Convert.ToDateTime(heartbeatResponse.Attachment);
            //状态 正常0和锁定1
            //int status = 1;
            using (var conn = DbUtil.getConn())
            {
                Console.WriteLine("________________________________________________________上锁");
                const string query = "UPDATE bdl_system_setting SET user_status = @User_Status";
                conn.Execute(query, new {  User_Status = SystemSettingEntity.USER_STATUS_FREEZE });
            }
        }
        //解锁
        //根据用户名改变状态设为正常状态
        public static void UnLockUse(HeartbeatResponse heartbeatResponse)
        {
            //将接受到的字符串(yyyy-mm-dd)转换成Datetime格式
            //DateTime Offlinetime = Convert.ToDateTime(heartbeatResponse.Attachment);
            //状态 正常0和锁定1
            //int status = 0;
            using (var conn = DbUtil.getConn())
            {
                Console.WriteLine("________________________________________________________解锁");
                const string query = "UPDATE bdl_system_setting SET user_status = @User_Status";

                conn.Execute(query, new {User_Status = SystemSettingEntity.USER_STATUS_GENERAL });
            }
        }



    }
}