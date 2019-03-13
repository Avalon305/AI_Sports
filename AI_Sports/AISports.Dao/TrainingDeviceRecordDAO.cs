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
        /// <summary>
        /// 根据会员卡号查出所有训练记录日期,填充前端出勤页面日历 前端只需要创建时间，训练记录后期会后很多，需要去重同一天的记录，否则肯定前端循环加载很慢，根据天分组查询即可
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<TrainingDeviceRecordEntity> ListRecordById(string memberId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT gmt_create FROM bdl_training_device_record WHERE member_id = @memberId GROUP BY DATE_FORMAT(gmt_create, '%Y%c%e')";
                return conn.Query<TrainingDeviceRecordEntity>(query, new { memberId }).ToList();

            }
        }

        /// <summary>
        /// 查询会员的初次训练日期
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public DateTime? GetMinTrainingDate(string memberId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT Min(gmt_create) FROM bdl_training_device_record WHERE member_id = @memberId";
                return conn.QueryFirstOrDefault<DateTime?>(query, new { memberId });
            }
        }
        /// <summary>
        /// 查询最近训练日期
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public DateTime? GetMaxTrainingDate(string memberId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT Max(gmt_create) FROM bdl_training_device_record WHERE member_id = @memberId";
                return conn.QueryFirstOrDefault<DateTime?>(query, new { memberId });
            }
        }
        /// <summary>
        /// 查询用户的总训练天数
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public int? GetAllTrainCountDay(string memberId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT Max(gmt_create) FROM bdl_training_device_record WHERE member_id = @memberId";
                return conn.QueryFirstOrDefault<int?>(query, new { memberId });
            }
        }
        /// <summary>
        /// 查询用户当前月份的训练记录（用于出勤页面本月训练天数），查询结果为每天的记录条数（每天进行了多少次训练），和日期。用于出勤页面语音分析
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<TrainingDeviceRecordEntity> ListCurrentMonthRecordById(string memberId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT COUNT(*) as count,gmt_create FROM bdl_training_device_record   WHERE member_id = @memberId AND DATE_FORMAT(gmt_create,'%Y%c') = DATE_FORMAT(NOW(),'%Y%c')  GROUP BY DATE_FORMAT(gmt_create,'%Y%c%e')";
                return conn.Query<TrainingDeviceRecordEntity>(query, new { memberId }).ToList();

            }
        }

    }
}
