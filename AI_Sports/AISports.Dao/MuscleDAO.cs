using AI_Sports.Util;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Dao
{
    class MuscleDAO
    {
        public int? selectsittingChestPusher(string currentCourseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = bdl_training_device_record.fk_training_activity_record_id LEFT JOIN bdl_datacode ON bdl_training_device_record.device_code = code_s_value WHERE code_type_id = 'DEVICE'AND device_code = 10 AND bdl_training_activity_record.course_count = @currentCourseCount";
                var para = new { currentCourseCount};
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectSittingRower(string currentCourseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = bdl_training_device_record.fk_training_activity_record_id LEFT JOIN bdl_datacode ON bdl_training_device_record.device_code = code_s_value WHERE code_type_id = 'DEVICE'AND device_code = 11 AND bdl_training_activity_record.course_count = @currentCourseCount";
                var para = new { currentCourseCount };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectsittingBackStretcher(string currentCourseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = bdl_training_device_record.fk_training_activity_record_id LEFT JOIN bdl_datacode ON bdl_training_device_record.device_code = code_s_value WHERE code_type_id = 'DEVICE'AND device_code = 15 AND bdl_training_activity_record.course_count = @currentCourseCount";
                var para = new { currentCourseCount };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectAbdominalMuscleTraining(string currentCourseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = bdl_training_device_record.fk_training_activity_record_id LEFT JOIN bdl_datacode ON bdl_training_device_record.device_code = code_s_value WHERE code_type_id = 'DEVICE'AND device_code = 14 AND bdl_training_activity_record.course_count = @currentCourseCount";
                var para = new { currentCourseCount };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectSittingLegStretching(string currentCourseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = bdl_training_device_record.fk_training_activity_record_id LEFT JOIN bdl_datacode ON bdl_training_device_record.device_code = code_s_value WHERE code_type_id = 'DEVICE'AND device_code = 9 AND bdl_training_activity_record.course_count = @currentCourseCount";
                var para = new { currentCourseCount };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectSittingCurvingLeg(string currentCourseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = bdl_training_device_record.fk_training_activity_record_id LEFT JOIN bdl_datacode ON bdl_training_device_record.device_code = code_s_value WHERE code_type_id = 'DEVICE'AND device_code = 13 AND bdl_training_activity_record.course_count = @currentCourseCount";
                var para = new { currentCourseCount };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectExerciseBike(string currentCourseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = bdl_training_device_record.fk_training_activity_record_id LEFT JOIN bdl_datacode ON bdl_training_device_record.device_code = code_s_value WHERE code_type_id = 'DEVICE'AND device_code = 16 AND bdl_training_activity_record.course_count = @currentCourseCount";
                var para = new { currentCourseCount };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectEllipticalTreadmill(string currentCourseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = bdl_training_device_record.fk_training_activity_record_id LEFT JOIN bdl_datacode ON bdl_training_device_record.device_code = code_s_value WHERE code_type_id = 'DEVICE'AND device_code = 12 AND bdl_training_activity_record.course_count = @currentCourseCount";
                var para = new { currentCourseCount };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectSittinglatissimusDorsiElevator(string currentCourseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = bdl_training_device_record.fk_training_activity_record_id LEFT JOIN bdl_datacode ON bdl_training_device_record.device_code = code_s_value WHERE code_type_id = 'DEVICE'AND device_code = 1 AND bdl_training_activity_record.course_count = @currentCourseCount";
                var para = new { currentCourseCount };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectTricepsTrainingMachine(string currentCourseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = bdl_training_device_record.fk_training_activity_record_id LEFT JOIN bdl_datacode ON bdl_training_device_record.device_code = code_s_value WHERE code_type_id = 'DEVICE'AND device_code = 2 AND bdl_training_activity_record.course_count = @currentCourseCount";
                var para = new { currentCourseCount };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectLegBender(string currentCourseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = bdl_training_device_record.fk_training_activity_record_id LEFT JOIN bdl_datacode ON bdl_training_device_record.device_code = code_s_value WHERE code_type_id = 'DEVICE'AND device_code = 3 AND bdl_training_activity_record.course_count = @currentCourseCount";
                var para = new { currentCourseCount };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectLeg(string currentCourseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = bdl_training_device_record.fk_training_activity_record_id LEFT JOIN bdl_datacode ON bdl_training_device_record.device_code = code_s_value WHERE code_type_id = 'DEVICE'AND device_code = 4 AND bdl_training_activity_record.course_count = @currentCourseCount";
                var para = new { currentCourseCount };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectButterflyMachine(string currentCourseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = bdl_training_device_record.fk_training_activity_record_id LEFT JOIN bdl_datacode ON bdl_training_device_record.device_code = code_s_value WHERE code_type_id = 'DEVICE'AND device_code = 5 AND bdl_training_activity_record.course_count = @currentCourseCount";
                var para = new { currentCourseCount };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectReversebutterflyMachine(string currentCourseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = bdl_training_device_record.fk_training_activity_record_id LEFT JOIN bdl_datacode ON bdl_training_device_record.device_code = code_s_value WHERE code_type_id = 'DEVICE'AND device_code = 6 AND bdl_training_activity_record.course_count = @currentCourseCount";
                var para = new { currentCourseCount };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectSittingBack(string currentCourseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = bdl_training_device_record.fk_training_activity_record_id LEFT JOIN bdl_datacode ON bdl_training_device_record.device_code = code_s_value WHERE code_type_id = 'DEVICE'AND device_code = 7 AND bdl_training_activity_record.course_count = @currentCourseCount";
                var para = new { currentCourseCount };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectTrunkTorsionCombination(string currentCourseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = bdl_training_device_record.fk_training_activity_record_id LEFT JOIN bdl_datacode ON bdl_training_device_record.device_code = code_s_value WHERE code_type_id = 'DEVICE'AND device_code = 8 AND bdl_training_activity_record.course_count = @currentCourseCount";
                var para = new { currentCourseCount };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }

        public int? selectLegPusher(string currentCourseCount)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_training_activity_record LEFT JOIN bdl_training_device_record ON bdl_training_activity_record.id = bdl_training_device_record.fk_training_activity_record_id LEFT JOIN bdl_datacode ON bdl_training_device_record.device_code = code_s_value WHERE code_type_id = 'DEVICE'AND device_code = 0 AND bdl_training_activity_record.course_count = @currentCourseCount";
                var para = new { currentCourseCount };
                return conn.QueryFirstOrDefault<int?>(query, para);
            }
        }
    }
}
