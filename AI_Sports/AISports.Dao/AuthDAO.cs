
using AI_Sports.Dao;
using AI_Sports.Entity;
using AI_Sports.Util;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.Entity
{
    class AuthDAO : BaseDAO<AuthEntity>
    {
 
        /// <summary>
        /// 获取用户数量
        /// </summary>
        /// <returns></returns>        
        public int? GetAuthCount()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "select count(*) from bdl_auth";

                return conn.QueryFirstOrDefault<int>(query);
            }
        }
       
    }
}
