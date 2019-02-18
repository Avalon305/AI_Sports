using AI_Sports.Dao;
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
    public class TrainingActivityRecordDAO: BaseDAO<TrainingActivityRecordEntity>
    {
        /// <summary>
        /// 根据活动ID获取
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public TrainingActivityRecordEntity GetByActivityId(long activityId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT * from bdl_training_activity_record where fk_activity_id = @ActivityId";
                return conn.QueryFirstOrDefault<TrainingActivityRecordEntity>(query, new { ActivityId = activityId });
            }
        }

        /// <summary>
        /// 更新记录完成状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="complete"></param>
        public void UpdateCompleteState(long id,bool complete)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "update bdl_training_activity_record set is_complete = @Complete where id = @Id";
                conn.Execute(query, new { Id = id, Complete = complete });
            }
        }

        public List<TrainingActivityVO> ListActivityRecords (string courseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT dev_rec.id,dev_rec.member_id,dev_rec.fk_training_activity_record_id,dev_rec.device_order_number,dev_rec.device_code,dev_rec.training_mode,dev_rec.consequent_force,dev_rec.reverse_force,dev_rec.power,dev_rec.count,dev_rec.speed,dev_rec.distance,dev_rec.energy,dev_rec.training_time,dev_rec.avg_heart_rate,dev_rec.max_heart_rate,dev_rec.min_heart_rate,dev_rec.gmt_create,act_rec.id,act_rec.fk_training_course_id,act_rec.fk_activity_id,act_rec.activity_type,act_rec.course_count,act_rec.is_complete,bdl_datacode.code_s_value,bdl_datacode.code_d_value FROM bdl_training_activity_record AS act_rec LEFT JOIN bdl_training_device_record AS dev_rec ON act_rec.id = dev_rec.fk_training_activity_record_id JOIN bdl_datacode ON dev_rec.device_code = bdl_datacode.code_s_value WHERE bdl_datacode.code_type_id = 'DEVICE' AND bdl_datacode.code_state = 1 AND act_rec.course_count = @CourseCount ORDER BY act_gmt_create DESC, dev_rec.gmt_create DESC";
                return conn.Query<TrainingActivityVO>(query, new { @CourseCount = courseCount }).ToList();
            }
        }

    }
}
