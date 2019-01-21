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
    public class PersonalSettingDAO : BaseDAO<PersonalSettingEntity>
    {
        /// <summary>
        /// 根据会员ID和设置获取个人设置
        /// </summary>
        /// <param name="member_id"></param>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        public PersonalSettingEntity GetSettingByMemberIdDeviceType(string member_id,DeviceType deviceType)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "select * from bdl_personal_setting where memeber_id = @Member_id and device_code = @DeviceCode";

                return conn.QueryFirstOrDefault<PersonalSettingEntity>(query, new { Member_id = member_id, DeviceCode=deviceType });
            }
        }
    }
}
