using AI_Sports.Util;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Dao
{
    class MusclePieChartDAO
    {
        public int selectAbdomenTraining()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = 1 AND course_count = 1 AND code_ext_value2 = 0 AND code_type_id = 'DEVICE' AND code_ext_value = '腹部'GROUP BY code_ext_value";
                return conn.QueryFirstOrDefault<int>(query);
            }
        }


        public int selectchestTraining()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = 1 AND course_count = 1 AND code_ext_value2 = 0 AND code_type_id = 'DEVICE' AND code_ext_value = '胸部'GROUP BY code_ext_value";
                return conn.QueryFirstOrDefault<int>(query);
            }
        }


        public int selectLegTraining()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = 1 AND course_count = 1 AND code_ext_value2 = 0 AND code_type_id = 'DEVICE' AND code_ext_value = '腿部'GROUP BY code_ext_value";
                return conn.QueryFirstOrDefault<int>(query);
            }
        }

        public int selectArmTraining()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = 1 AND course_count = 1 AND code_ext_value2 = 0 AND code_type_id = 'DEVICE' AND code_ext_value = '手臂'GROUP BY code_ext_value";
                return conn.QueryFirstOrDefault<int>(query);
            }
        }

        public int selectTrunkTraining()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = 1 AND course_count = 1 AND code_ext_value2 = 0 AND code_type_id = 'DEVICE' AND code_ext_value = '躯干'GROUP BY code_ext_value";
                return conn.QueryFirstOrDefault<int>(query);
            }
        }

        public int selectchestEnduranceTraining()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = 1 AND course_count = 1 AND code_ext_value2 = 1 AND code_type_id = 'DEVICE' AND code_ext_value = '胸部'GROUP BY code_ext_value";
                return conn.QueryFirstOrDefault<int>(query);
            }
        }

        public int selectLegEnduranceTraining()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = 1 AND course_count = 1 AND code_ext_value2 = 1 AND code_type_id = 'DEVICE' AND code_ext_value = '腿部'GROUP BY code_ext_value";
                return conn.QueryFirstOrDefault<int>(query);
            }
        }


        public int selectEnduranceArmTraining()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = 1 AND course_count = 1 AND code_ext_value2 = 1 AND code_type_id = 'DEVICE' AND code_ext_value = '手臂'GROUP BY code_ext_value";
                return conn.QueryFirstOrDefault<int>(query);
            }
        }

        public int selectTrunkEnduranceTraining()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = 1 AND course_count = 1 AND code_ext_value2 = 1 AND code_type_id = 'DEVICE' AND code_ext_value = '躯干'GROUP BY code_ext_value";
                return conn.QueryFirstOrDefault<int>(query);
            }
        }


    }
}
