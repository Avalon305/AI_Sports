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
        /// <summary>
        /// 根据会员id查出前一天的所有设备纪录
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<TrainingDeviceRecordEntity> GetRecordByIdAndTime(string memberId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "select * from bdl_training_device_record where gmt_create between date_sub(curdate(),interval 1 day) and now() and member_id = @memberId";
                return conn.Query<TrainingDeviceRecordEntity>(query, new { memberId }).ToList();

            }
        }
        /// <summary>
        /// 根据会员id和Device_code查出前一天的设备纪录条数
        /// </summary>
        /// <param name="memberId/Device_code"></param>
        /// <returns></returns>
        public int GetRecordCountByIdAndDeviceCode(string memberId,string Device_code)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "select count(*) from bdl_training_device_record where gmt_create between date_sub(curdate(),interval 1 day) and now() and member_id = @memberId and device_code=@Device_code";
                return conn.QueryFirstOrDefault<int>(query, new { memberId, Device_code });

            }
        }

        /// <summary>
        /// 根据id查出训练活动记录id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int GetTrainActivityRecordIdById(long Id)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT fk_training_activity_record_id FROM bdl_training_device_record  WHERE id = @Id";
                return conn.QueryFirstOrDefault<int>(query, new { Id });
            }
        }
    }
}
