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
    /// bdlmemberEntity
    /// bdl_member
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
    [Table("bdl_member")]
    public class MemberEntity
    {   /// 主键自增id
        [ExplicitKey]
        public long Id { get; set; } = 0;
        /// 会员id
        public string Member_id { get; set; }
        /// 会员名
        public string Member_firstName { get; set; }
        /// 会员姓
        public string Member_familyName { get; set; }
        /// 出生日期
        public DateTime? Birth_date { get; set; }
        /// 住址
        public string Sex { get; set; }
        /// 住址
        public string Address { get; set; }
        /// 邮箱地址
        public string Email_address { get; set; }
        /// 工作电话
        public string Work_phone { get; set; }
        /// 私人电话
        public string Personal_phone { get; set; }
        /// 手机号码
        public string Mobile_phone { get; set; }
        /// 体重（KG）
        public double? Weight { get; set; }
        /// 身高 (cm)
        public double? Height { get; set; }
        /// 年龄
        public int? Age { get; set; }
        /// 最大心率=220-age
        public int? Max_heart_rate { get; set; }
        /// 最宜心率
        public int? Suitable_heart_rate { get; set; }
        /// 角色id，1：会员；0：教练
        public byte? Role_id { get; set; }
        /// 外键关联教练id
        public int? Fk_coach_id { get; set; }
        /// 标签名数组：标签名：增肌、减脂、塑形、康复，用符号分隔
        public string Label_name { get; set; }
        /// 是否开启减脂模式 默认0，0:未开启，1:开启
        public Boolean Is_open_fat_reduction { get; set; }
        /// 前端备注
        public string Remark { get; set; }
        /// 创建时间
        public DateTime? Gmt_create { get; set; }
        public DateTime? Gmt_modified { get; set; }
    }
}