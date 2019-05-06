using AI_Sports.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Http.Dto
{
    /// <summary>
    /// 用于转化ActivityEntity
    /// </summary>
    public class ActivityDTO
    {
        public string Id;
        /// 外键训练课程id
        public string FkTrainingCourseId;
        public string FkMemberId;
        public string MemberId;
        /// 训练活动编码：力量循环或者力量耐力循环
        public string ActivityType;
        /// 目标轮次数量，目标在这一圈训练几轮
        public string TargetTurn_number;
        /// 当前轮次计数
        public string currentTurnNumber;
        /// 是否完成 默认0:未完成。1:完成)
        public string IsComplete;
        /// 创建时间
        public string GmtCreate;
        public string GmtModified;
        public ActivityDTO()
        {

        }

        public ActivityDTO(ActivityEntity activityEntity)
        {
            this.Id = activityEntity.Id.ToString();
            this.FkTrainingCourseId = activityEntity.Fk_training_course_id.ToString();
            this.FkMemberId = activityEntity.Fk_member_id.ToString();
            this.MemberId = activityEntity.Member_id.ToString();
            this.ActivityType = activityEntity.Activity_type;
            this.TargetTurn_number = activityEntity.Target_turn_number.ToString();
            this.currentTurnNumber = activityEntity.current_turn_number.ToString();
            this.IsComplete = activityEntity.Is_complete.ToString();
            this.GmtCreate = activityEntity.Gmt_create.ToString().Replace("/", "-");
            this.GmtModified = activityEntity.Gmt_modified.ToString().Replace("/", "-");
        }
    }
}
