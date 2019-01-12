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
    /// bdlactivityEntity
    /// bdl_activity
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
    [Table("bdl_activity")]
    public  class ActivityEntity 
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 外键训练课程id
        /// </summary>
        public int? Fk_training_course_id{ get; set; }

        /// <summary>
        /// 训练活动名：力量循环或者力量耐力循环
        /// </summary>
        public String Activity_name{ get; set; }

        /// <summary>
        /// 目标轮次数量，目标在这一圈训练几轮
        /// </summary>
        public int? Target_turn_number{ get; set; }

        /// <summary>
        /// 当前轮次计数
        /// </summary>
        public int? Current_turn_number{ get; set; }

        /// <summary>
        /// 是否完成 默认0:未完成。1:完成)
        /// </summary>
        public Boolean? Is_complete{ get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Gmt_create{ get; set; }

        /// <summary>
        /// gmt_modified
        /// </summary>
        public DateTime? Gmt_modified{ get; set; }




        
    }
}
