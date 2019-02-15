using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.Entity
{
    class TrainingPlanVO
    {
        /// <summary>
        /// 训练标题
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Gmt_create { get; set; }

        /// 当前课程轮次计数
        public int? Current_course_count { get; set; }

        /// 训练计划总耗能 单位卡路里
        public double? SumEnergy { get; set; }
        /// 训练计划总时间 单位秒
        public double? SumTime { get; set; }
    }
}
