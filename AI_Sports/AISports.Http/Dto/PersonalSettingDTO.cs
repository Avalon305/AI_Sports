using AI_Sports.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Http.Dto
{
    public class PersonalSettingDTO
    {
        public string Id;
        public string FkMemberId;
        public string MemberId;
        /// 训练活动id
        public string FkTrainingActivityId;
        /// 训练活动类型编码
        public string ActivityType;
        /// 设备名
        public string DeviceCode;
        /// 设备序号
        public string DeviceOrderNumber;
        /// 训练模式
        public string TrainingMode;
        /// 座位高度cm
        public string SeatHeight;
        /// 靠背距离cm
        public string BackrestDistance;
        /// 踏板距离cm
        public string FootboardDistance;
        /// 前方限制cm
        public string FrontLimit;
        /// 后方限制cm
        public string BackLimit;
        /// 顺向力
        public string ConsequentForce;
        /// 反向力
        public string ReverseForce;
        /// 功率
        public string Power;
        /// <summary>
        /// 杠杆长度 cm
        /// </summary>
        public string LeverLength;
        /// <summary>
        /// 杠杆角度
        /// </summary>
        public string LeverAngle;
        /// <summary>
        /// 扩展字段
        /// </summary>
        public string ExtraSetting;
        /// 创建时间
        public string GmtCreate;
        public string GmtModified;
        public PersonalSettingDTO()
        {

        }
        public PersonalSettingDTO (PersonalSettingEntity personalSettingEntity)
        {
            this.Id = personalSettingEntity.Id.ToString();
            this.FkMemberId = personalSettingEntity.Fk_member_id.ToString();
            this.MemberId = personalSettingEntity.Member_id;
            this.FkTrainingActivityId = personalSettingEntity.Fk_training_activity_id.ToString();
            this.ActivityType = personalSettingEntity.Activity_type;
            this.DeviceCode = personalSettingEntity.Device_code;
            this.DeviceOrderNumber = personalSettingEntity.Device_order_number.ToString();
            this.TrainingMode = personalSettingEntity.Training_mode;
            this.SeatHeight = personalSettingEntity.Seat_height.ToString();
            this.BackrestDistance = personalSettingEntity.Backrest_distance.ToString();
            this.FootboardDistance = personalSettingEntity.Footboard_distance.ToString();
            this.FrontLimit = personalSettingEntity.Front_limit.ToString();
            this.BackLimit = personalSettingEntity.Back_limit.ToString();
            this.ConsequentForce = personalSettingEntity.Consequent_force.ToString();
            this.ReverseForce = personalSettingEntity.Reverse_force.ToString();
            this.Power = personalSettingEntity.Power.ToString();
            this.LeverLength = personalSettingEntity.Lever_length.ToString();
            this.LeverAngle = personalSettingEntity.Lever_angle.ToString();
            this.ExtraSetting = personalSettingEntity.Extra_setting;
            this.GmtCreate = personalSettingEntity.Gmt_create.ToString().Replace("/", "-");
            this.GmtModified = personalSettingEntity.Gmt_modified.ToString().Replace("/", "-");
        }
    }
}
