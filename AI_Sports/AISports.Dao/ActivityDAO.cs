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
        /// <summary>
        /// 查询训练活动id
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public List<ActivityEntity> ListActivitysByCourseId(long courseId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT * FROM bdl_activity  WHERE fk_training_course_id = @Fk_training_course_id AND is_complete = 0";
                return conn.Query<ActivityEntity>(query, new { Fk_training_course_id = courseId }).ToList();
            }
        }

        /// <summary>
        /// 根据id查出目标轮次数量
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int GetTargetTurnNumById(long Id)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT target_turn_number FROM bdl_activity  WHERE id = @Id";
                return conn.QueryFirstOrDefault<int>(query, new { Id });
            }
        }
    }
}
