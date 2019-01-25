//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2019 , Qust
//--------------------------------------------------------------------

using System;

using System.Linq;
using System.Collections.Generic;
using System.Data;
using Dapper.Contrib.Extensions;

namespace AI_Sports.Entity
{


    /// <summary>
    /// tauthEntity
    /// t_auth
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
    [Table("bdl_traininfo")]
    public class AuthEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [ExplicitKey]
        public long Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public String Username { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public String Password { get; set; }

        /// <summary>
        /// 手环或卡的openID
        /// </summary>
        public String Authid { get; set; }
    }
}