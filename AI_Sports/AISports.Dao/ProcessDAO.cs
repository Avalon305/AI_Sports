using AI_Sports.AISports.Entity;
using AI_Sports.Util;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Dao
{
    class ProcessDAO
    {
        public List<DateTime> selectCreateTime()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT bdl_training_activity_record.gmt_create FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON fk_training_activity_record_id = bdl_training_activity_record.id WHERE bdl_training_activity_record.gmt_create > DATE_ADD(NOW(), INTERVAL - 1440 MINUTE) AND bdl_training_activity_record.activity_type = 0 GROUP BY course_count";
                return (List<DateTime>)conn.Query<DateTime>(query);
            }
        }

        internal List<ProcessVO> selectStrength()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT avg(((bdl_training_device_record.consequent_force) + (bdl_training_device_record.reverse_force)) / 2) AS AvgValue, bdl_training_activity_record.gmt_create AS ProcessTime FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON fk_training_activity_record_id = bdl_training_activity_record.id WHERE bdl_training_activity_record.gmt_create > DATE_ADD(NOW(), INTERVAL - 1440 MINUTE) AND bdl_training_activity_record.activity_type = 0 GROUP BY course_count";
                return (List<ProcessVO>)conn.Query<ProcessVO>(query);
            }
        }


        public int selectCount()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM (SELECT avg(( (bdl_training_device_record.consequent_force ) + ( bdl_training_device_record.reverse_force ) ) / 2),bdl_training_activity_record.gmt_create FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON fk_training_activity_record_id = bdl_training_activity_record.id WHERE bdl_training_activity_record.gmt_create > DATE_ADD(NOW(), INTERVAL - 1440 MINUTE) AND bdl_training_activity_record.activity_type = 0 GROUP BY course_count) AS p";
                return conn.QueryFirstOrDefault<int>(query);

            }
        }

        public List<double> selectAvgValue()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT avg(((bdl_training_device_record.consequent_force) + (bdl_training_device_record.reverse_force)) / 2) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON fk_training_activity_record_id = bdl_training_activity_record.id WHERE bdl_training_activity_record.gmt_create > DATE_ADD(NOW(), INTERVAL - 1440 MINUTE) AND bdl_training_activity_record.activity_type = 0 GROUP BY course_count";
                return (List<double>)conn.Query<double>(query);
            }
        }

        public List<DateTime> selectStrengthCreateTime()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT bdl_training_activity_record.gmt_create FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON fk_training_activity_record_id = bdl_training_activity_record.id LEFT JOIN bdl_datacode ON device_code = code_s_value AND code_type_id = 'DEVICE' WHERE bdl_training_activity_record.gmt_create > DATE_ADD(NOW(), INTERVAL - 1440 MINUTE) AND bdl_training_activity_record.activity_type = 1 AND code_ext_value3 = 0 GROUP BY course_count";
                return (List<DateTime>)conn.Query<DateTime>(query);
            }
        }

        public List<double> selectavgStrengthValue()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT avg(((bdl_training_device_record.consequent_force) + (bdl_training_device_record.reverse_force)) / 2) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON fk_training_activity_record_id = bdl_training_activity_record.id LEFT JOIN bdl_datacode ON device_code = code_s_value AND code_type_id = 'DEVICE' WHERE bdl_training_activity_record.gmt_create > DATE_ADD(NOW(), INTERVAL - 1440 MINUTE) AND bdl_training_activity_record.activity_type = 1 AND code_ext_value3 = 0 GROUP BY course_count";
                return (List<double>)conn.Query<double>(query);
            }
        }

        public List<DateTime> selectAerobicCreateTime()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT bdl_training_activity_record.gmt_create FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON fk_training_activity_record_id = bdl_training_activity_record.id LEFT JOIN bdl_datacode ON device_code = code_s_value AND code_type_id = 'DEVICE' WHERE bdl_training_activity_record.gmt_create > DATE_ADD(NOW(), INTERVAL - 1440 MINUTE) AND bdl_training_activity_record.activity_type = 1 AND code_ext_value3 = 1 GROUP BY course_count";
                return (List<DateTime>)conn.Query<DateTime>(query);
            }
        }


        public List<double> selectavgAerobicValue()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT avg(((bdl_training_device_record.consequent_force) + (bdl_training_device_record.reverse_force)) / 2) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON fk_training_activity_record_id = bdl_training_activity_record.id LEFT JOIN bdl_datacode ON device_code = code_s_value AND code_type_id = 'DEVICE' WHERE bdl_training_activity_record.gmt_create > DATE_ADD(NOW(), INTERVAL - 1440 MINUTE) AND bdl_training_activity_record.activity_type = 1 AND code_ext_value3 = 1 GROUP BY course_count";
                return (List<double>)conn.Query<double>(query);
            }
        }
    }
}
