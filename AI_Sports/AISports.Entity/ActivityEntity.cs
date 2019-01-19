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
    public class ActivityEntity
    {
        /// 主键自增id
        public long Id { get; set; }
        /// 外键训练课程id
        public long Fk_training_course_id { get; set; }
        public long Fk_member_id { get; set; }
        public string Member_id { get; set; }
        /// 训练活动编码：力量循环或者力量耐力循环
        public string Activity_type { get; set; }
        /// 目标轮次数量，目标在这一圈训练几轮
        public int? Target_turn_number { get; set; }
        /// 当前轮次计数
        public int? current_turn_number { get; set; }
        /// 是否完成 默认0:未完成。1:完成)
        public Boolean? Is_complete { get; set; }
        /// 创建时间
        public DateTime? Gmt_create { get; set; }
        public DateTime? Gmt_modified { get; set; }


    }
}
