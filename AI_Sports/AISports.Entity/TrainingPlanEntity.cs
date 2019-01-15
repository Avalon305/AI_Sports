﻿//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2019 , Qust
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace AI_Sports.Entity
{


    /// <summary>
    /// bdltrainingplanEntity
    /// bdl_training_plan
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
    public class TrainingPlanEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 外键会员id
        /// </summary>
        public int? Fk_member_id { get; set; }

        /// <summary>
        /// 训练标题
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// 起始日期
        /// </summary>
        public DateTime? Start_date { get; set; }

        /// <summary>
        /// 训练目标
        /// </summary>
        public String Training_target { get; set; }

        /// <summary>
        /// 是否删除 1:删除;0:未删除
        /// </summary>
        public Boolean? Is_deleted { get; set; }

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