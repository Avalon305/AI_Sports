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
    public class TrainingDeviceRecordDAO:BaseDAO<TrainingDeviceRecordEntity>
    {
        public List<TrainingDeviceRecordEntity> GetRecordByIdAndTime(string memberId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "select * from bdl_training_device_record where gmt_create between date_sub(curdate(),interval 1 day) and now() and member_id = @memberId";
                return conn.Query<TrainingDeviceRecordEntity>(query, new { memberId }).ToList();

            }
        }
    }
}
