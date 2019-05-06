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
    /// bdlsystemsettingEntity
    /// bdl_system_setting
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
    [Table("bdl_system_setting")]
    public class SystemSettingEntity
    {

        //用户状态常量，0代表正常、解冻，1代表冻结，2代表完全离线
        /// <summary>
        /// 正常/解冻
        /// </summary>
        public static byte? USER_STATUS_GENERAL = 0;
        /// <summary>
        /// 冻结
        /// </summary>
        public static byte? USER_STATUS_FREEZE = 1;
        /// <summary>
        /// 完全离线
        /// </summary>
        public static byte? USER_STATUS_FREE = 2;
        //截止时间常量，完全离线至N年
        public static DateTime? Auth_OFFLINETIMEFREE = DateTime.MaxValue;

        /// <summary>
        /// 主键
        /// </summary>
        [ExplicitKey]
        public long Id { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>
        public String Organization_name { get; set; }

        /// <summary>
        /// 机构电话
        /// </summary>
        public String Organization_phone { get; set; }

        /// <summary>
        /// 机构地址
        /// </summary>
        public String Organization_address { get; set; }

        /// <summary>
        /// ip地址
        /// </summary>
        public String Ip_address { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Gmt_create { get; set; }

        /// <summary>
        /// gmt_modified
        /// </summary>
        public DateTime? Gmt_modified { get; set; }
        /// <summary>
        /// 系统版本 0：普通版 1：豪华版 豪华版多三种训练模式
        /// </summary>
        public int? System_version { get; set; }

        //用户状态
        public byte? User_Status { get; set; }
        //使用截止时间
        public DateTime? Auth_OfflineTime { get; set; }
        //主机唯一标识 MAC地址
        public String Set_Unique_Id { get; set; }
    }
}