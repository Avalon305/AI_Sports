using AI_Sports.AISports.Dto;
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
    class ActivityDAO:BaseDAO<ActivityEntity>
    {
        /// <summary>
        /// 根据会员卡号完成训练活动，把is_complete标志位置为1代表完成
        /// </summary>
        /// <param name="memberEntity"></param>
        /// <returns></returns>
        public int UpdateCompleteState(string memberId, bool complete)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "UPDATE bdl_activity SET is_complete = @Complete WHERE member_id = @member_id";

                return conn.Execute(query, new { member_id = memberId, Complete = complete });

            }
        }
		///zfc
		/// <summary>
		/// 根据外键训练课程id完成训练活动，把is_complete标志位置为0，current_turn_number置为0
		/// </summary>
		/// <param name="trainingcourseid"></param>
		/// <param name="complete"></param>
		/// <returns></returns>
		public int UpdateCompleteFinish(int trainingcourseid, int complete)
		{
			using (var conn = DbUtil.getConn())
			{
				const string query = "UPDATE bdl_activity SET is_complete = @Complete ,current_turn_number = @Complete WHERE fk_training_course_id  = @fk_training_course_id ";

				return conn.Execute(query, new { fk_training_course_id = trainingcourseid, Complete = complete });

			}
		}


		/// <summary>
		/// 查询训练活动id 不需要根据完成状态查询。一个课程至多对应两条活动记录
		/// </summary>
		/// <param name="courseId"></param>
		/// <returns></returns>
		public List<ActivityEntity> ListActivitysByCourseId(long courseId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT * FROM bdl_activity  WHERE fk_training_course_id = @Fk_training_course_id";
                return conn.Query<ActivityEntity>(query, new { Fk_training_course_id = courseId }).ToList();
            }
        }

        /// <summary>
        /// 根据id查出目标轮次数量
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int GetTargetTurnNumById(long Id)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT target_turn_number FROM bdl_activity  WHERE id = @Id";
                return conn.QueryFirstOrDefault<int>(query, new { Id });
            }
        }
        /// <summary>
        /// EditActivity页面分组头转换器用 根据课程id和活动类型查出目标伦次
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="CouseId"></param>
        /// <returns></returns>
        public int GetTargetTurnNumByTypeCourseId(string Type,string CouseId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT target_turn_number FROM bdl_activity  WHERE activity_type = @Type And fk_training_course_id = @CouseId";
                return conn.QueryFirstOrDefault<int>(query, new { Type, CouseId });
            }
        }

        /// <summary>
        /// 训练活动页面Expander 查询出每个设备的个人设置根据活动类型分组展示并可以更新
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public List<ActivityGroupDTO> ListActivitysGroupAndPersonalSetting(long courseId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT per_set.device_code,per_set.consequent_force,per_set.reverse_force,per_set.power,act.fk_training_course_id,act.target_turn_number,act.current_turn_number,act.is_complete,act.gmt_create,bdl_datacode.code_d_value ,cycleDate.code_d_value AS activity_type,modeType.code_d_value AS training_mode FROM bdl_activity AS act LEFT JOIN bdl_personal_setting AS per_set ON act. id = per_set.fk_training_activity_id JOIN bdl_datacode ON per_set.device_code = bdl_datacode.code_s_value  JOIN bdl_datacode AS cycleDate ON act.activity_type = cycleDate.code_s_value JOIN bdl_datacode AS modeType ON per_set.training_mode = modeType.code_s_value WHERE act.fk_training_course_id = @Fk_training_course_id AND bdl_datacode.code_type_id = 'DEVICE' AND bdl_datacode.code_state = 1 AND cycleDate.code_type_id = 'CYCLE_TYPE' AND cycleDate.code_state = 1 AND modeType.code_type_id = 'TRAIN_MODE' AND modeType.code_state = 1 ORDER BY per_set.activity_type,bdl_datacode.code_xh ";
                return conn.Query<ActivityGroupDTO>(query, new { Fk_training_course_id = courseId }).ToList();
            }
        }
        /// <summary>
        /// 根据课程id和活动类型更新活动目标轮次
        /// </summary>
        /// <param name="activityEntity"></param>
        /// <returns></returns>
        public int UpdateTargetTurnNumber(ActivityEntity activityEntity)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "UPDATE bdl_activity SET target_turn_number = @Target_turn_number WHERE fk_training_course_id = @Fk_training_course_id AND activity_type = @Activity_type";

                return conn.Execute(query, activityEntity);

            }
        }

        /// <summary>
        /// 获取当前课程当前完成状态的活动数量
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="complete"></param>
        /// <returns></returns>
        public int CountByCourseId(long courseId,bool complete)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT count(*) FROM bdl_activity  WHERE  fk_training_course_id = @CouseId AND  is_complete = @Complete";
                return conn.QueryFirstOrDefault<int>(query, new { CouseId = courseId, Complete = complete });
            }
        }

        /// <summary>
        /// 同时把该训练课程id对应的bdl_activity(训练活动表）的记录重置了，就是把current_turn_number（当前活动轮次计数）置为0，is_complete置为0。
        /// </summary>
        /// <param name="courseId"></param>
        public void ResetCourseByCourseId(long courseId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "UPDATE bdl_activity SET current_turn_number = 0,is_complete = 0 WHERE fk_training_course_id = @Fk_training_course_id ";

                conn.Execute(query, new { Fk_training_course_id = courseId });

            }
        }
    }
}
