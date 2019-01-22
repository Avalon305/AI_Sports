using AI_Sports.Dto;
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
        public SettingInfoDTO GetSettingByMemberIdDeviceType(string member_id, DeviceType deviceType, ActivityType activityType)
        {
            using (var conn = DbUtil.getConn())
            {
                var para = new { Member_id = member_id, DeviceCode = deviceType, MyActivityType = activityType };
                const string query = @"select c.fk_training_course_id,a.is_open_fat_reduction,b.* from bdl_member a 
                    join bdl_personal_setting b on a.id = b.fk_member_id join bdl_activity c on c.id = b.fk_training_activity_id
                    where a.member_id = @Member_id and b.device_code = @DeviceCode and c.activity_type = @MyActivityType 
                ";
                //一对一关联查询
                return conn.Query<SettingInfoDTO, PersonalSettingEntity, SettingInfoDTO>(query, (dto, set) =>
                  {
                      dto.PersonalSettingEntity = set;
                      return dto;
                  }, para, splitOn: "Id").FirstOrDefault<SettingInfoDTO>();
            }
        }


    }
}
