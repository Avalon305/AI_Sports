//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2019 , Qust
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace AI_Sports.Entity
{

    /// <summary>
    /// bdltrainingcourserecordEntity
    /// bdl_training_course_record
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
    public class TrainingCourseRecordEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 外键训练课程id
        /// </summary>
        public int? Fk_training_course_id { get; set; }

        /// <summary>
        /// 当前课程轮次=插入时训练课程表的当前课程计数
        /// </summary>
        public int? Course_id { get; set; }

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