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
    [Table("bdl_training_device_record")]
    public class TrainingDeviceRecordEntity
    {
        /// 主键自增id
        [ExplicitKey]
        public long Id { get; set; }
        /// 会员id
        public string Member_id { get; set; }
        /// 外键训练活动记录id
        public long Fk_training_activity_record_id { get; set; }
        /// 训练活动类型编码
        public string Activity_type { get; set; }
        /// 设备在循环中的序号
        public int? Device_order_number { get; set; }
        /// 设备名
        public string Device_code { get; set; }
        /// 训练模式
        public string Training_mode { get; set; }
        public double? Consequent_force { get; set; }
        public double? Reverse_force { get; set; }
        /// 功率
        public double? Power { get; set; }
        /// 训练个数
        public int? Count { get; set; }
        /// 速度 1位小数 千米每时,暂不上报
        public double? Speed { get; set; }
        /// 距离 千米，两位小数
        public double? Distance { get; set; }
        /// 训练总耗能 单位卡路里
        public double? Energy { get; set; }
        /// 训练时间 单位秒
        public int? Training_time { get; set; }
        /// 平均心率
        public int? Avg_heart_rate { get; set; }
        /// 最大心率
        public int? Max_heart_rate { get; set; }
        /// 最小心率
        public int? Min_heart_rate { get; set; }
        /// 创建时间
        public DateTime? Gmt_create { get; set; }
        public DateTime? Gmt_modified { get; set; }
    }
}