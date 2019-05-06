using AI_Sports.Dao;
using AI_Sports.Entity;
using AI_Sports.Util;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.Dao
{
    /// <summary>
    /// 系统设置DAO
    /// </summary>
    class SystemSettingDAO : BaseDAO<SystemSettingEntity>
    {
        /// <summary>
        ///  获取系统设置，默认只有一条记录 
        /// </summary>
        /// <returns></returns>
        public SystemSettingEntity GetSystemSetting()
        {

            using (var conn = DbUtil.getConn())
            {
                const string query = "select  organization_name  ,organization_phone ,organization_address  ,system_version , user_status  ,auth_offlinetime  ,set_unique_id  from bdl_system_setting;";
                return conn.QueryFirstOrDefault<SystemSettingEntity>(query);
            }
        }

        public int InsertSystemSet(SystemSettingEntity systemSettingEntity)
        {
            using (var conn = DbUtil.getConn())
            {
                const string insert = "insert into bdl_system_setting (id,organization_name,organization_phone,organization_address,ip_address,system_version,user_status,auth_offlinetime,set_unique_id) VALUES" +
                    " (@Id,@Organization_name,@Organization_phone,@Organization_address,@Ip_address,@System_version,@User_Status,@Auth_OfflineTime,@Set_Unique_Id);";
                return conn.Execute(insert, systemSettingEntity);
            }
        }
    }
}
