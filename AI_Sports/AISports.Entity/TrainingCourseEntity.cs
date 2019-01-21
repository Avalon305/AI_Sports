//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2019 , Qust
//--------------------------------------------------------------------

using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;

namespace AI_Sports.Entity
{


    /// <summary>
    /// bdltrainingcourseEntity
    /// bdl_training_course
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
    [Table("bdl_training_course")]
    public class TrainingCourseEntity
    {
        /// 主键自增id
        public long Id { get; set; }
        public string Member_id { get; set; }
        /// 外键训练计划id
        public long Fk_training_plan_id { get; set; }
        /// 休息天数（间隔）
        public int? Rest_days { get; set; }
        /// 目标课程轮次计数=前端课程天
        public int? Target_course_count { get; set; }
        /// 当前课程轮次计数
        public int? Current_course_count { get; set; }
        /// 起始日期
        public DateTime? Start_date { get; set; }
        /// 预计结束日期=起始日期+休息天数*课程天数
        public DateTime? End_date { get; set; }
        /// 当前进度预计结束日期.更新完成状态时，根据计数和间隔更新此日期
        public DateTime? Current_end_date { get; set; }
        /// 是否完成 默认0:未完成。1:完成)
        public Boolean? Is_complete { get; set; }
        /// 创建时间
        public DateTime? Gmt_create { get; set; }
        public DateTime? Gmt_modified { get; set; }
    }
}