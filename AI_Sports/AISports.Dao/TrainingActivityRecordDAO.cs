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
        public TrainingActivityRecordEntity GetByActivityId(long activityId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT * from bdl_training_activity_record where fk_activity_id = @ActivityId";
                return conn.QueryFirstOrDefault<TrainingActivityRecordEntity>(query, new { ActivityId = activityId });
            }
        }
    }
}
