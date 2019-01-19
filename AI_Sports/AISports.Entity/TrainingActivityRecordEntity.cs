//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2019 , Qust
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace AI_Sports.Entity
{

    /// <summary>
    /// bdltrainingactivityrecordEntity
    /// bdl_training_activity_record
    /// 
    /// 修改纪录
    /// 
    /// 2019-01-12 版本：1.0  创建。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name></name>
    /// <date>2019-01-12</date>
    /// </author>
    /// </summary>
    [Serializable]
    public class TrainingActivityRecordEntity
    {
        /// 主键自增id
        public long Id { get; set; }
        /// 外键训练课程id
        public int Fk_training_course_id { get; set; }
        /// 外键，训练活动ID
        public int Fk_activity_id { get; set; }
        ///  训练活动编码：力量循环或者力量耐力循环
        public string Activity_type { get; set; }
        /// 课程轮次计数：等于插入时训练课程表的当前课程计数，标志这条训练活动记录属于第几次的课程
        public int? Course_count { get; set; }
        /// 是否完成 默认0:未完成。1:完成)
        public Boolean? Is_complete { get; set; }
        /// 创建时间
        public DateTime? Gmt_create { get; set; }
        public DateTime? Gmt_modified { get; set; }
    }
}