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
    class TrainingPlanDAO:BaseDAO<TrainingPlanEntity>
    {
        /// <summary>
        /// 删除旧的训练计划，把is_deleted标志位置为1代表删除
        /// </summary>
        /// <param name="memberEntity"></param>
        /// <returns></returns>
        public int DeletePlanByMemberId(string memberId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "UPDATE bdl_training_plan SET is_deleted = 1 WHERE member_id = @member_id";

                return conn.Execute(query, new { member_id = memberId });

            }
        }
        /// <summary>
        /// 插入训练计划
        /// </summary>
        /// <param name="trainingPlanEntity"></param>
        /// <returns></returns>
        public int SaveTrainingPlan(TrainingPlanEntity trainingPlanEntity)
        {
            using (var conn = DbUtil.getConn())
            {
                const string insert = "INSERT INTO `ai_sports`.`bdl_training_plan` (`fk_member_id`, `title`, `start_date`, `training_target`) VALUES (@Fk_member_id ,@Title , @Start_date , @Training_target)";
                return conn.Execute(insert, trainingPlanEntity);

            }
        }
        /// <summary>
        /// 根据会员ID查询其正在进行的训练计划
        /// </summary>
        /// <param name="member_Id"></param>
        /// <returns></returns>
        public TrainingPlanEntity GetTrainingPlanByMumberId(string memberId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT bdl_training_plan.id,bdl_training_plan.fk_member_id,bdl_training_plan.member_id,bdl_training_plan.title,bdl_training_plan.start_date,bdl_training_plan.training_target,bdl_training_plan.is_deleted,bdl_training_plan.gmt_create,bdl_training_plan.gmt_modified FROM bdl_training_plan WHERE is_deleted = 0 AND member_id = @Member_id";
                return conn.QueryFirstOrDefault(query, new { Member_id = memberId });
            }
        }
    }
}
