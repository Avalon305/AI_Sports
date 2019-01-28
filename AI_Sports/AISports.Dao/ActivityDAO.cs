using AI_Sports.Entity;
using AI_Sports.Util;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.Dao
{
    class ActivityDAO:BaseDAO<ActivityEntity>
    {
        /// <summary>
        /// 根据会员卡号完成训练活动，把is_complete标志位置为1代表完成
        /// </summary>
        /// <param name="memberEntity"></param>
        /// <returns></returns>
        public int UpdateCompleteState(string memberId, bool complete)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "UPDATE bdl_activity SET is_complete = @Complete WHERE member_id = @member_id";

                return conn.Execute(query, new { member_id = memberId, Complete = complete });

            }
        }
    }
}
