using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.Entity
{
    class TrainingCourseVO
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Gmt_create { get; set; }

        /// 当前课程轮次计数
        public int? Course_count { get; set; }

        /// 训练计划总耗能 单位卡路里
        public double? Sum_energy { get; set; }
        /// 训练计划总时间 单位秒
        public double? Sum_time { get; set; }
        /// <summary>
        /// 总训练个数
        /// </summary>
        public int? Sum_count { get; set; }
        /// <summary>
        /// 在设备上总训练次数
        /// </summary>
        public int? Dev_count { get; set; }
        /// <summary>
        /// 平均顺向力 数据库保留整数
        /// </summary>
        public int? Avg_consequent_force { get; set; }
        /// <summary>
        /// 平均反向力 数据库保留整数
        /// </summary>
        public int? Avg_reverse_force { get; set; }


    }
}
