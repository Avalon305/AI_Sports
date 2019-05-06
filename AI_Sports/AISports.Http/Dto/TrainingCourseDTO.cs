using AI_Sports.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Http.Dto
{
    public class TrainingCourseDTO
    {
        public string Id;
        public string MemberId;
        /// 外键训练计划id
        public string FkTrainingPlanId;
        /// 休息天数（间隔）
        public string RestDays;
        /// 目标课程轮次计数=前端课程天
        public string TargetCourseCount;
        /// 当前课程轮次计数
        public string CurrentCourseCount;
        /// 起始日期
        public string StartDate;
        /// 预计结束日期=起始日期+休息天数*课程天数
        public string EndDate;
        /// 当前进度预计结束日期.更新完成状态时，根据计数和间隔更新此日期
        public string CurrentEndDate;
        /// 是否完成 默认0:未完成。1:完成)
        public string IsComplete;
        /// 创建时间
        public string GmtCreate;
        public string GmtModified;
        public TrainingCourseDTO ()
        {

        }
        public TrainingCourseDTO (TrainingCourseEntity trainingCourseEntity)
        {
            this.Id = trainingCourseEntity.Id.ToString();
            this.MemberId = trainingCourseEntity.Member_id;
            this.FkTrainingPlanId = trainingCourseEntity.Fk_training_plan_id.ToString();
            this.RestDays = trainingCourseEntity.Rest_days.ToString();
            this.TargetCourseCount = trainingCourseEntity.Target_course_count.ToString();
            this.CurrentCourseCount = trainingCourseEntity.Current_course_count.ToString();
            this.StartDate = trainingCourseEntity.Start_date.ToString().Replace("/", "-");
            this.EndDate = trainingCourseEntity.End_date.ToString().Replace("/", "-");
            this.CurrentEndDate = trainingCourseEntity.Current_end_date.ToString().Replace("/", "-");
            this.IsComplete = trainingCourseEntity.Is_complete.ToString();
            this.GmtCreate = trainingCourseEntity.Gmt_create.ToString().Replace("/", "-");
            this.GmtModified = trainingCourseEntity.Gmt_modified.ToString().Replace("/", "-");
        }
    }
}
