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
    class TrainingCourseDAO:BaseDAO<TrainingCourseEntity>
    {
        /// <summary>
        /// 根据会员卡号完成训练课程，把is_complete标志位置为1代表完成
        /// </summary>
        /// <param name="memberEntity"></param>
        /// <returns></returns>
        public int UpdateCompleteState(string memberId,bool complete)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "UPDATE bdl_training_course SET is_complete = @Complete WHERE member_id = @member_id";

                return conn.Execute(query, new { member_id = memberId , Complete = complete});

            }
        }
        /// <summary>
        /// 根据会员id联查训练计划表和课程表，查询出当前登录会员正在进行的课程
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public TrainingCourseEntity GetCourseByMemberId(string memberId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT * FROM bdl_training_course JOIN bdl_training_plan ON bdl_training_course.fk_training_plan_id = bdl_training_plan.id WHERE bdl_training_plan.is_deleted = 0 AND bdl_training_course.is_complete = 0 AND bdl_training_course.member_id = @Member_id";
                return conn.QueryFirstOrDefault(query, new { Member_id = memberId });
            }
        }
    }
}
