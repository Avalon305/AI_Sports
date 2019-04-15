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
        /// 查询个人设置
        /// </summary>
        /// <param name="member_id"></param>
        /// <param name="deviceType"></param>
        /// <param name="activityType"></param>
        /// <returns></returns>
        public PersonalSettingEntity GetSettingByMemberId(string member_id, DeviceType deviceType, ActivityType activityType)
        {
            const string query = @"SELECT * FROM bdl_personal_setting WHERE member_id = @Member_id AND activity_type = @MyActivityType and 
                             device_code = @DeviceCode 
";
            var para = new { Member_id = member_id, MyActivityType = activityType , DeviceCode  = deviceType};
            using (var conn = DbUtil.getConn())
            {
                return conn.Query<PersonalSettingEntity>(query, para).FirstOrDefault();
            }
           
        }

        /// <summary>
        /// 根据会员ID和设置获取个人设置
        /// </summary>
        /// <param name="member_id"></param>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        public SettingInfoDTO GetSettingCourseInfoByMemberId(string member_id,  ActivityType activityType)
        {
            using (var conn = DbUtil.getConn())
            {
                var para = new { Member_id = member_id,  MyActivityType = activityType };
                const string query = @"select a.is_open_fat_reduction,c.target_course_count,c.current_course_count,a.member_id,a.id user_id,c.id course_id,d.id activity_id from bdl_member a join bdl_training_plan b on a.id = b.fk_member_id 
                    join bdl_training_course c on c.fk_training_plan_id = b.id 
                    join bdl_activity d on d.fk_training_course_id = c.id 
                    where b.is_deleted = 0 and a.member_id = @Member_id and d.activity_type = @MyActivityType ";
                //一对一关联查询
                return conn.Query< SettingInfoDTO>(query, para).FirstOrDefault();
            }
        }

        /// <summary>
        /// 获取训练完的设备列表 修改传入的fk_activity_id和course_count参数为活动记录表主键activityRecordId  --ByCQZ 4.7
        /// </summary>
        /// <param name="member_id"></param>
        /// <param name="activityType"></param>
        /// <returns></returns>
        public List<DeviceDoneDTO> ListDeviceDone(string member_id, ActivityType activityType, long activityRecordId)
        {
            List<DeviceDoneDTO> result = new List<DeviceDoneDTO>();
            const string query = @"select c.is_open_fat_reduction,b.device_code from    bdl_training_activity_record a join bdl_training_device_record b
                on a.id = b.fk_training_activity_record_id  join bdl_member c on c.member_id = b.member_id 
                where b.member_id=@Member_id and a.id = @ActivityRecordId
                ";
            var para = new { Member_id = member_id, MyActivityType = activityType, ActivityRecordId = activityRecordId};
            using (var conn = DbUtil.getConn())
            {
                result = conn.Query<DeviceDoneDTO>(query, para).ToList();
            }
            return result;
        }

        /// <summary>
        /// 更新顺向力反向力和功率
        /// </summary>
        /// <param name="consequent_force"></param>
        /// <param name="reverse_force"></param>
        /// <param name="power"></param>
        /// <param name="uid"></param>
        /// <param name="deviceType"></param>
        public void UpdateSettingByUid(double consequent_force,double reverse_force,double power,String uid,DeviceType deviceType)
        {
            string sql = @"update bdl_personal_setting set consequent_force = @Consequent_force, reverse_force = @Reverse_force,power = @Power 
                where member_id = @Uid and device_code = @Devicecode
";
            using (var conn = DbUtil.getConn())
            {
                conn.Execute(sql, new { Consequent_force = consequent_force, Reverse_force = reverse_force, Power = power, Uid = uid, Devicecode = deviceType });
            }
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
        /// <summary>
        /// 更新力量设备 除去12号和16号单车、跑步机 更新训练模式 顺向反向力
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateStrengthDeviceSettingByType(PersonalSettingEntity entity)
        {
            string sql = @"update bdl_personal_setting set training_mode = @Training_mode,consequent_force = @Consequent_force,
                    reverse_force = @Reverse_force
                where member_id = @Member_id and activity_type = @Activity_type and device_code != '12' and device_code != '16'
            ";
            using (var conn = DbUtil.getConn())
            {
                conn.Execute(sql, entity);
            }

        }
        /// <summary>
        /// 更新耐力训练设备 单车和跑步机 更新功率,不更新训练模式 单车跑步机就一种标准模式
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateEnduranceDeviceSettingByType(PersonalSettingEntity entity)
        {
            string sql = @"update bdl_personal_setting set power = @Power
                where member_id = @Member_id and activity_type = @Activity_type and device_code = '12' or device_code = '16'
            ";
            using (var conn = DbUtil.getConn())
            {
                conn.Execute(sql, entity);
            }

        }
    }
}
