using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.Entity
{
    [Serializable]
    class TrainingActivityVO : TrainingDeviceRecordEntity
    {
        /// 外键训练课程id
        public long Fk_training_course_id { get; set; }
        /// 外键，训练活动ID
        public long Fk_activity_id { get; set; }
        ///  训练活动编码：力量循环或者力量耐力循环
        public string Activity_type { get; set; }
        /// 课程轮次计数：等于插入时训练课程表的当前课程计数，标志这条训练活动记录属于第几次的课程
        public int? Course_count { get; set; }
        /// 是否完成 默认0:未完成。1:完成)
        public Boolean? Is_complete { get; set; }
        /// 训练活动记录的创建时间
        public DateTime? Act_gmt_create { get; set; }
        /// <summary>
        /// 存储值
        /// </summary>
        public String Code_s_value { get; set; }

        /// <summary>
        /// 展示值
        /// </summary>
        public String Code_d_value { get; set; }
    }
}
