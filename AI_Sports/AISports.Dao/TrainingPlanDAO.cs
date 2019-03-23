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
                return conn.QueryFirstOrDefault<TrainingPlanEntity>(query, new { Member_id = memberId });
            }
        }

        /// <summary>
        /// 查询训练计划分析页面展示的信息
        /// </summary>
        /// <param name="trainingPlanId"></param>
        /// <returns></returns>
        public TrainingPlanVO GetTrainingPlanVO(string trainingPlanId , string trainingCourseId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT course.current_course_count,course.target_course_count,plan.gmt_create,Sum(dev.training_time) AS SumTime,Sum(dev.energy) AS SumEnergy,plan.title FROM bdl_training_plan AS plan JOIN bdl_training_course AS course ON plan.id = course.fk_training_plan_id JOIN bdl_training_activity_record as act ON act.fk_training_course_id = course.id JOIN bdl_training_device_record as dev ON act.id = dev.fk_training_activity_record_id WHERE plan.id = @TrainingPlanId AND course.id = @TrainingCourseId"; 
                return conn.QueryFirstOrDefault<TrainingPlanVO>(query, new { @TrainingPlanId = trainingPlanId , @TrainingCourseId = trainingCourseId });
            }
        }


        public int selectRecordNumber()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT max(course_count) FROM bdl_training_plan LEFT JOIN bdl_training_course ON bdl_training_plan.id = fk_training_plan_id LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = bdl_training_activity_record.fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value AND code_type_id = 'DEVICE'";
                return conn.QueryFirstOrDefault<int>(query);

            }
        }

        public List<double> selectAerobicEnergy(string trainingPlanId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(bdl_training_device_record.energy) AS energ FROM bdl_training_plan LEFT JOIN bdl_training_course ON bdl_training_plan.id = fk_training_plan_id LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = bdl_training_activity_record.fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_plan.id = @trainingPlanId AND code_ext_value3 =1 AND code_type_id = 'DEVICE' GROUP BY course_count,code_ext_value3";
                var para = new { trainingPlanId };
                return (List<double>)conn.Query<double>(query,para);
            }
        }


        public List<double> selectForceEnergy(string trainingPlanId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(bdl_training_device_record.energy) AS energ FROM bdl_training_plan LEFT JOIN bdl_training_course ON bdl_training_plan.id = fk_training_plan_id LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = bdl_training_activity_record.fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_plan.id = @trainingPlanId AND code_ext_value3 =0 AND code_type_id = 'DEVICE' GROUP BY course_count,code_ext_value3";
                var para = new { trainingPlanId };
                return (List<double>)conn.Query<double>(query,para);
            }
        }

    }
}
