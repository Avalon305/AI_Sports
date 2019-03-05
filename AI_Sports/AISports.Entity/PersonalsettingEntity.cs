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
    /// bdlpersonalsettingEntity
    /// bdl_personal_setting
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
    [Table("bdl_personal_setting")]
    public class PersonalSettingEntity
    {
        /// 主键自增id
        [ExplicitKey]
        public long Id { get; set; }
        public long Fk_member_id { get; set; }
        public string Member_id { get; set; }
        /// 训练活动id
        public long Fk_training_activity_id { get; set; }
        /// 训练活动类型编码
        public string Activity_type { get; set; }
        /// 设备名
        public string Device_code { get; set; }
        /// 设备序号
        public int? Device_order_number { get; set; }
        /// 训练模式
        public string Training_mode { get; set; }
        /// 座位高度cm
        public int? Seat_height { get; set; }
        /// 靠背距离cm
        public int? Backrest_distance { get; set; }
        /// 踏板距离cm
        public int? Footboard_distance { get; set; }
        /// 前方限制cm
        public int? Front_limit { get; set; }
        /// 后方限制cm
        public int? Back_limit { get; set; }
        /// 顺向力
        public double? Consequent_force { get; set; }
        /// 反向力
        public double? Reverse_force { get; set; }
        /// 功率
        public double? Power { get; set; }
        /// <summary>
        /// 杠杆长度 cm
        /// </summary>
        public int? Lever_length { get; set; }
        /// <summary>
        /// 杠杆角度
        /// </summary>
        public double? Lever_angle { get; set; }
        /// <summary>
        /// 扩展字段
        /// </summary>
        public string Extra_setting { get; set; }
        /// 创建时间
        public DateTime? Gmt_create { get; set; }
        public DateTime? Gmt_modified { get; set; }
    }
}