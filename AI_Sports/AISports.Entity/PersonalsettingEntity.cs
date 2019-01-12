//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2019 , Qust
//--------------------------------------------------------------------

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
    public class PersonalSettingEntity
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
        /// 座位高度
        /// </summary>
        public Decimal? Seat_height { get; set; }

        /// <summary>
        /// 靠背距离
        /// </summary>
        public Decimal? Backrest_distance { get; set; }

        /// <summary>
        /// 前方限制
        /// </summary>
        public Decimal? Front_limit { get; set; }

        /// <summary>
        /// 后方限制
        /// </summary>
        public Decimal? Back_limit { get; set; }

        /// <summary>
        /// 训练模式
        /// </summary>
        public String Training_mode { get; set; }

        /// <summary>
        /// 顺向力
        /// </summary>
        public int? Consequent_force { get; set; }

        /// <summary>
        /// 反向力
        /// </summary>
        public int? Reverse_force { get; set; }

        /// <summary>
        /// 功率
        /// </summary>
        public int? Power { get; set; }

        /// <summary>
        /// 训练活动名
        /// </summary>
        public String Fk_training_activity_name { get; set; }

        /// <summary>
        /// 设备编码
        /// </summary>
        public String Device_code { get; set; }

        /// <summary>
        /// 设备序号
        /// </summary>
        public int? Device_order_number { get; set; }

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