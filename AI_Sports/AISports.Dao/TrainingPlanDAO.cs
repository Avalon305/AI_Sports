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
    /// <summary>
    /// 训练计划DAO
    /// </summary>
    class TrainingPlanDAO
    {
        /// <summary>
        /// 删除旧的训练计划，把is_deleted标志位置为1代表删除
        /// </summary>
        /// <param name="memberEntity"></param>
        /// <returns></returns>
        public int DeletePlanByMemberId(MemberEntity memberEntity)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "UPDATE bdl_training_plan SET is_deleted = 1 WHERE fk_member_id = @Fk_member_id";

                return conn.Execute(query, new { Fk_member_id = memberEntity.Member_id });
                
            }
        }
    }
}
