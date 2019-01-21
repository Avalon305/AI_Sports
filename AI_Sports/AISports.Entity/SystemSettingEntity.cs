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
    }
}