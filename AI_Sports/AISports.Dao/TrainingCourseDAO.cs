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
        /// 根据当前课程ID完成/跳过训练课程 计数+1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdateCourseCount(int id)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "UPDATE bdl_training_course SET current_course_count = (current_course_count + 1) WHERE id = @id";

                return conn.Execute(query, new { id });

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
                const string query = "SELECT 	bdl_training_course.id,bdl_training_course.member_id,	bdl_training_course.fk_training_plan_id,	bdl_training_course.rest_days,	bdl_training_course.target_course_count,	bdl_training_course.current_course_count,	bdl_training_course.start_date,	bdl_training_course.end_date,	bdl_training_course.current_end_date,	bdl_training_course.is_complete,	bdl_training_course.gmt_create,	bdl_training_course.gmt_modified FROM bdl_training_course JOIN bdl_training_plan ON bdl_training_course.fk_training_plan_id = bdl_training_plan.id WHERE bdl_training_plan.is_deleted = 0 AND bdl_training_course.is_complete = 0 AND bdl_training_course.member_id = @Member_id";
                return conn.QueryFirstOrDefault<TrainingCourseEntity>(query, new { Member_id = memberId });
            }
        }


        /// <summary>
        /// 传入参数为app.config中当前进行的课程id，查询该课程记录list用于课程分析页面
        /// </summary>
        /// <param name="trainingCourseId"></param>
        /// <returns></returns>
        public List<TrainingCourseVO> listCourseRecord(string trainingCourseId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT act.course_count,act.gmt_create,SUM(dev.training_time)/60 AS Sum_time,SUM(dev.energy)/1000 AS Sum_energy,SUM(dev.count) AS Sum_count,ROUND(AVG(dev.consequent_force)) AS Avg_consequent_force,ROUND(AVG(dev.reverse_force)) AS Avg_reverse_force,count(*) AS Dev_count FROM bdl_training_activity_record AS act JOIN bdl_training_device_record AS dev ON act.id = dev.fk_training_activity_record_id WHERE act.fk_training_course_id = @TrainingCourseId GROUP BY act.course_count ORDER BY act.course_count";
                return conn.Query<TrainingCourseVO>(query, new { @TrainingCourseId = trainingCourseId }).ToList();
            }
        }
        /// <summary>
        /// 更新训练课程
        /// </summary>
        /// <param name="memberEntity"></param>
        /// <returns></returns>
        public int UpdateTrainingCourseById(int? restDays, DateTime? endDate, int? targetCourseCount,long? id)
        {
            using (var conn = DbUtil.getConn())
            {
        
                const string query = "UPDATE bdl_training_course SET rest_days =  @RestDays,end_date = @EndDate,target_course_count = @TargetCourseCount  WHERE id = @Id ";

                return conn.Execute(query, new { RestDays = restDays, EndDate = endDate , TargetCourseCount = targetCourseCount ,@Id = id});

            }
        }

        public int selectMAxCourseRecord()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT max(course_count) FROM bdl_training_plan LEFT JOIN bdl_training_course ON bdl_training_plan.id = fk_training_plan_id LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = bdl_training_activity_record.fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value AND code_type_id = 'DEVICE'";
                return conn.QueryFirstOrDefault<int>(query);

            }
        }

        
        public double selectAerobicEnduranceEnergy(string trainingPlanId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(bdl_training_device_record.energy) FROM bdl_training_plan LEFT JOIN bdl_training_course ON bdl_training_plan.id = fk_training_plan_id LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = bdl_training_activity_record.fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_plan.id = @trainingPlanId AND code_ext_value3 = 1 AND code_ext_value2 = 1 AND code_type_id = 'DEVICE' GROUP BY course_count,code_ext_value3,code_ext_value2 ORDER BY course_count ASC";
                return conn.QueryFirstOrDefault<double>(query);
            }
        }

        public double selectForceEnduranceEnergy(string trainingPlanId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(bdl_training_device_record.energy) FROM bdl_training_plan LEFT JOIN bdl_training_course ON bdl_training_plan.id = fk_training_plan_id LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = bdl_training_activity_record.fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_plan.id = @trainingPlanId AND code_ext_value3 = 0 AND code_ext_value2 = 1 AND code_type_id = 'DEVICE' GROUP BY course_count,code_ext_value3,code_ext_value2 ORDER BY course_count ASC";
                return conn.QueryFirstOrDefault<double>(query);
            }
        }

        public double selectForceEnergy(string trainingPlanId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(bdl_training_device_record.energy) FROM bdl_training_plan LEFT JOIN bdl_training_course ON bdl_training_plan.id = fk_training_plan_id LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = bdl_training_activity_record.fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_plan.id = @trainingPlanId  AND code_ext_value2 = 0 AND code_type_id = 'DEVICE' GROUP BY course_count,code_ext_value3,code_ext_value2 ORDER BY course_count ASC";
                return conn.QueryFirstOrDefault<double>(query);
            }
        }
    }
}
