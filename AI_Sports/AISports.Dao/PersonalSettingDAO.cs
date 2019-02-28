﻿using AI_Sports.Dto;
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
                const string query = @"select d.current_course_count,c.fk_training_course_id,a.is_open_fat_reduction,b.* from bdl_member a 
                    join bdl_personal_setting b on a.id = b.fk_member_id join bdl_activity c on c.id = b.fk_training_activity_id join bdl_training_course d on d.id = c.fk_training_course_id 
                    where c.is_complete <> 1 and d.is_complete <> 1 and a.member_id = @Member_id and b.device_code = @DeviceCode and c.activity_type = @MyActivityType 
                ";
                //一对一关联查询
                return conn.Query<SettingInfoDTO, PersonalSettingEntity, SettingInfoDTO>(query, (dto, set) =>
                  {
                      dto.PersonalSettingEntity = set;
                      return dto;
                  }, para, splitOn: "Id").FirstOrDefault();
            }
        }

        /// <summary>
        /// 获取训练完的设备列表
        /// </summary>
        /// <param name="member_id"></param>
        /// <param name="activityType"></param>
        /// <returns></returns>
        public List<DeviceDoneDTO> ListDeviceDone(string member_id, ActivityType activityType)
        {
            List<DeviceDoneDTO> result = new List<DeviceDoneDTO>();
            const string query = @"select c.is_open_fat_reduction,b.device_code from    bdl_training_activity_record a join bdl_training_device_record b
                on a.id = b.fk_training_activity_record_id  join bdl_member c on c.member_id = b.member_id 
                where b.member_id=@Member_id and a.activity_type = @MyActivityType 
                ";
            var para = new { Member_id = member_id, MyActivityType = activityType };
            using (var conn = DbUtil.getConn())
            {
                result = conn.Query<DeviceDoneDTO>(query, para).ToList();
            }
            return result;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateSetting(PersonalSettingEntity entity)
        {
            string sql = @"update bdl_personal_setting set Seat_height=@Seat_height,Backrest_distance=@Backrest_distance
               ,Lever_length=@Lever_length,Lever_angle=@Lever_angle,Front_limit=@Front_limit,Back_limit=@Back_limit,Training_mode=@Training_mode 
                where member_id = @Member_id and Device_code=@Device_code 
            ";
            using (var conn = DbUtil.getConn())
            {
                conn.Execute(sql, entity);
            }

        }
        /// <summary>
        /// 根据会员卡号和活动类型查询个人设置 byCQZ
        /// </summary>
        /// <param name="member_id"></param>
        /// <param name="activityType"></param>
        /// <returns></returns>
        public List<PersonalSettingEntity> ListSettingByMemberIdActivityType(string member_id, string activityType)
        {
            List<PersonalSettingEntity> result = new List<PersonalSettingEntity>();
            const string query = @"SELECT * FROM bdl_personal_setting WHERE member_id = @Member_id AND activity_type = @MyActivityType";
            var para = new { Member_id = member_id, MyActivityType = activityType };
            using (var conn = DbUtil.getConn())
            {
                result = conn.Query<PersonalSettingEntity>(query, para).ToList();
            }
            return result;
        }
        /// <summary>
        /// 添加新的训练活动时跟新个人设置表中各个设备的记录对应的活动ID外键，这个活动id外键用于在EditActivity页面联查设置分组展示的条件
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateSettingActivityId(PersonalSettingEntity entity)
        {
            string sql = @"update bdl_personal_setting set fk_training_activity_id = @Fk_training_activity_id
                where member_id = @Member_id and activity_type = @Activity_type 
            ";
            using (var conn = DbUtil.getConn())
            {
                conn.Execute(sql, entity);
            }

        }
    }
}
