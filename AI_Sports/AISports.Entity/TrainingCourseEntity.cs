//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2019 , Qust
//--------------------------------------------------------------------

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
    public class TrainingCourseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 外键训练计划id
        /// </summary>
        public int? Fk_training_plan_id { get; set; }

        /// <summary>
        /// 休息天数（间隔）
        /// </summary>
        public int? Rest_days { get; set; }

        /// <summary>
        /// 目标课程轮次计数=前端课程天
        /// </summary>
        public int? Target_course_count { get; set; }

        /// <summary>
        /// 当前课程轮次计数
        /// </summary>
        public int? Current_course_count { get; set; }

        /// <summary>
        /// 起始日期
        /// </summary>
        public DateTime? Start_date { get; set; }

        /// <summary>
        /// 预计结束日期=起始日期+休息天数*课程天数
        /// </summary>
        public DateTime? End_date { get; set; }

        /// <summary>
        /// 当前进度预计结束日期.更新完成状态时，根据计数和间隔更新此日期
        /// </summary>
        public DateTime? Current_end_date { get; set; }

        /// <summary>
        /// 是否完成 默认0:未完成。1:完成)
        /// </summary>
        public Boolean? Is_complete { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Gmt_create { get; set; }

        /// <summary>
        /// gmt_modified
        /// </summary>
        public DateTime? Gmt_modified { get; set; }
    }
}