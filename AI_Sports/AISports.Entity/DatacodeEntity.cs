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
    /// bdldatacodeEntity
    /// bdl_datacode
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
    [Table("bdl_datacode")]
    public class DatacodeEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [ExplicitKey]
        public long Id { get; set; }

        /// <summary>
        /// 排序号，下拉列表按这个排序
        /// </summary>
        public int? Code_xh { get; set; }

        /// <summary>
        /// 类型ID，dList是数据项
        /// </summary>
        public String Code_type_id { get; set; }

        /// <summary>
        /// 存储值
        /// </summary>
        public String Code_s_value { get; set; }

        /// <summary>
        /// 展示值
        /// </summary>
        public String Code_d_value { get; set; }

        /// <summary>
        /// 扩展值
        /// </summary>
        public String Code_ext_value { get; set; }
        /// <summary>
        /// 扩展值2 用作存储设备的活动类型，与编码表中的循环类型相对应：0力量循环，1力量耐力，需要用作分组查询依据
        /// </summary>
        public String Code_ext_value2 { get; set; }
        /// <summary>
        /// 扩展值3 用作存储有氧力量类型：0：力量训练设备；1：有氧训练设备
        /// </summary>
        public String Code_ext_value3 { get; set; }


        /// <summary>
        /// 是否启用 0 不启用 1启用
        /// </summary>
        public Boolean? Code_state { get; set; }
    }
}