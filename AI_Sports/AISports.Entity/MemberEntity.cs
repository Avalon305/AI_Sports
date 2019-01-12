//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2019 , Qust
//--------------------------------------------------------------------

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
    public class MemberEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 会员id
        /// </summary>
        public String Member_id { get; set; }

        /// <summary>
        /// 会员名
        /// </summary>
        public String Member_firstName { get; set; }

        /// <summary>
        /// 会员姓
        /// </summary>
        public String Member_familyName { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birth_date { get; set; }

        /// <summary>
        /// 0：女士；1：先生
        /// </summary>
        public int? Sex { get; set; }

        /// <summary>
        /// 住址
        /// </summary>
        public String Address { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        public String Email_address { get; set; }

        /// <summary>
        /// 工作电话
        /// </summary>
        public String Work_phone { get; set; }

        /// <summary>
        /// 私人电话
        /// </summary>
        public String Personal_phone { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public String Mobile_phone { get; set; }

        /// <summary>
        /// 体重（KG）
        /// </summary>
        public int? Weight { get; set; }

        /// <summary>
        /// 身高 (cm)
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// 最大心率=220-age
        /// </summary>
        public int? Max_heart_rate { get; set; }

        /// <summary>
        /// 最宜心率
        /// </summary>
        public int? Suitable_heart_rate { get; set; }

        /// <summary>
        /// 角色id，1：会员；0：教练
        /// </summary>
        public int? Role_id { get; set; }

        /// <summary>
        /// 外键关联教练id
        /// </summary>
        public int? Fk_coach_id { get; set; }

        /// <summary>
        /// 标签名数组：标签名：增肌、减脂、塑形、康复，用符号分隔
        /// </summary>
        public String Label_name { get; set; }

        /// <summary>
        /// 是否开启减脂模式 默认0，0:未开启，1:开启
        /// </summary>
        public Boolean? Is_open_fat_reduction { get; set; }

        /// <summary>
        /// 前端备注
        /// </summary>
        public String Remark { get; set; }

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