//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2019 , Qust
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace AI_Sports.Entity
{


    /// <summary>
    /// bdltrainingdevicerecordEntity
    /// bdl_training_device_record
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
    public class TrainingDeviceRecordEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 外键训练活动记录id
        /// </summary>
        public int? Fk_training_activity_record_id { get; set; }

        /// <summary>
        /// 设备在循环中的序号
        /// </summary>
        public int? Device_order_number { get; set; }

        /// <summary>
        /// 设备编码
        /// </summary>
        public String Device_code { get; set; }

        /// <summary>
        /// 训练活动名
        /// </summary>
        public String Activity_name { get; set; }

        /// <summary>
        /// 外键会员id
        /// </summary>
        public String Fk_member_id { get; set; }

        /// <summary>
        /// 训练模式
        /// </summary>
        public String Training_mode { get; set; }

        /// <summary>
        /// 最终顺向力
        /// </summary>
        public int? Consequent_force { get; set; }

        /// <summary>
        /// 最终反向力
        /// </summary>
        public int? Reverse_force { get; set; }

        /// <summary>
        /// 功率
        /// </summary>
        public int? Power { get; set; }

        /// <summary>
        /// 训练个数
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// 速度 1位小数 千米每时
        /// </summary>
        public Decimal? Speed { get; set; }

        /// <summary>
        /// 距离 千米，两位小数
        /// </summary>
        public Decimal? Distance { get; set; }

        /// <summary>
        /// 训练总耗能 单位卡路里
        /// </summary>
        public Decimal? Energy { get; set; }

        /// <summary>
        /// 训练时间 单位秒
        /// </summary>
        public int? Training_time { get; set; }

        /// <summary>
        /// 平均心率
        /// </summary>
        public int? Avg_heart_rate { get; set; }

        /// <summary>
        /// 最大心率
        /// </summary>
        public int? Max_heart_rate { get; set; }

        /// <summary>
        /// 最小心率
        /// </summary>
        public int? Min_heart_rate { get; set; }

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