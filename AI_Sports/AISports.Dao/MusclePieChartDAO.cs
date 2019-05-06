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
        public int? selectAbdomenTraining(string trainingCourseId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = @trainingCourseId AND code_ext_value2 = 0 AND code_type_id = 'DEVICE' AND code_ext_value = '躯干'";
                var para = new { trainingCourseId };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }


        public int? selectchestTraining(string trainingCourseId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = @trainingCourseId AND code_ext_value2 = 0 AND code_type_id = 'DEVICE' AND code_ext_value = '胸'";
                var para = new { trainingCourseId };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }


        public int? selectLegTraining(string trainingCourseId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = @trainingCourseId AND code_ext_value2 = 0 AND code_type_id = 'DEVICE' AND code_ext_value = '腿部'";
                var para = new { trainingCourseId };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectArmTraining(string trainingCourseId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = @trainingCourseId AND code_ext_value2 = 0 AND code_type_id = 'DEVICE' AND code_ext_value = '手臂'";
                var para = new { trainingCourseId };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectTrunkTraining(string trainingCourseId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = @trainingCourseId AND code_ext_value2 = 0 AND code_type_id = 'DEVICE' AND code_ext_value = '躯干'";
                var para = new { trainingCourseId };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectchestEnduranceTraining(string trainingCourseId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = @trainingCourseId AND code_ext_value2 = 1 AND code_type_id = 'DEVICE' AND code_ext_value = '胸'";
                var para = new { trainingCourseId };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectLegEnduranceTraining(string trainingCourseId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = @trainingCourseId AND code_ext_value2 = 1 AND code_type_id = 'DEVICE' AND code_ext_value = '腿部'";
                var para = new { trainingCourseId };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        /// <summary>
        /// 耐力循环背部 bYcqz
        /// </summary>
        /// <param name="trainingCourseId"></param>
        /// <returns></returns>
        public int? selectEnduranceBackTraining(string trainingCourseId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = @trainingCourseId AND code_ext_value2 = 1 AND code_type_id = 'DEVICE' AND code_ext_value = '背部'";
                var para = new { trainingCourseId };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectTrunkEnduranceTraining(string trainingCourseId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT sum(count) FROM bdl_training_course LEFT JOIN bdl_training_activity_record ON bdl_training_course.id = fk_training_course_id LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = fk_training_activity_record_id LEFT JOIN bdl_datacode ON device_code = code_s_value WHERE bdl_training_course.id = @trainingCourseId AND code_ext_value2 = 1 AND code_type_id = 'DEVICE' AND code_ext_value = '躯干'";
                var para = new { trainingCourseId };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }


    }
}
