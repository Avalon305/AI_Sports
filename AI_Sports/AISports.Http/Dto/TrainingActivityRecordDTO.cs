using AI_Sports.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Http.Dto
{
    public class TrainingActivityRecordDTO
    {
        public string Id;
        /// 外键训练课程id
        public string FkTrainingCourseId;
        /// 外键，训练活动ID
        public string FkActivityId;
        ///  训练活动编码：力量循环或者力量耐力循环
        public string ActivityType;
        /// 课程轮次计数：等于插入时训练课程表的当前课程计数，标志这条训练活动记录属于第几次的课程
        public string CourseCount;
        /// 是否完成 默认0:未完成。1:完成)
        public string IsComplete;
        /// 创建时间
        public string GmtCreate;
        public string GmtModified;

        public TrainingActivityRecordDTO()
        {

        }
        public TrainingActivityRecordDTO (TrainingActivityRecordEntity trainingActivityRecordEntity)
        {
            this.Id = trainingActivityRecordEntity.Id.ToString();
            this.FkTrainingCourseId = trainingActivityRecordEntity.Fk_training_course_id.ToString();
            this.FkActivityId = trainingActivityRecordEntity.Fk_activity_id.ToString();
            this.ActivityType = trainingActivityRecordEntity.Activity_type;
            this.CourseCount = trainingActivityRecordEntity.Course_count.ToString();
            this.IsComplete = trainingActivityRecordEntity.Is_complete.ToString();
            this.GmtCreate = trainingActivityRecordEntity.Gmt_create.ToString().Replace("/", "-");
            this.GmtModified = trainingActivityRecordEntity.Gmt_modified.ToString().Replace("/", "-");
        }
    }
}
