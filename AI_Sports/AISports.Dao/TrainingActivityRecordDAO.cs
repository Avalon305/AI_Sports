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
    }
}
