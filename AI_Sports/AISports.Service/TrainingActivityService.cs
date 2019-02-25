using AI_Sports.Dao;
using AI_Sports.Entity;
using System.Collections.Generic;
using AI_Sports.Util;
namespace AI_Sports.Service
{
    class TrainingActivityService
    {
        private ActivityDAO activityDAO = new ActivityDAO();
        private TrainingActivityRecordDAO trainingActivityRecordDAO = new TrainingActivityRecordDAO();
        /// <summary>
        /// 批量插入训练活动
        /// </summary>
        /// <param name="activities"></param>
        /// <returns></returns>
        public long BatchSaveActivity(List<ActivityEntity> activities)
        {
            foreach (var activity in activities)
            {
                activity.Id = KeyGenerator.GetNextKeyValueLong("bdl_activity");
                activity.Member_id = CommUtil.GetSettingString("memberId");
                activity.Fk_member_id = ParseIntegerUtil.ParseInt(CommUtil.GetSettingString("memberPrimarykey"));
                activity.Fk_training_course_id = ParseIntegerUtil.ParseInt(CommUtil.GetSettingString("trainingCourseId"));
                activity.Gmt_create = System.DateTime.Now;
                activity.Is_complete = false;
                activity.current_turn_number = 0;
            }
            return activityDAO.BatchInsert(activities);
        }
        /// <summary>
        /// 根据训练课程ID查询出对应的训练活动
        /// </summary>
        /// <returns></returns>
        public List<ActivityEntity> ListActivitysByCourseId()
        {
            return activityDAO.ListActivitysByCourseId(ParseIntegerUtil.ParseInt(CommUtil.GetSettingString("trainingCourseId")));
        }
        /// <summary>
        /// 训练活动分页页面的list查询
        /// </summary>
        /// <returns></returns>
        public List<TrainingActivityVO> ListActivityRecords(int? currentCourseCount)
        {
            //string currentCourseCount = CommUtil.GetSettingString("currentCourseCount");
            return trainingActivityRecordDAO.ListActivityRecords(currentCourseCount);
        }
        /// <summary>
        /// 用于转换器，根据活动记录id查询活动名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetActivityType(string id)
        {
            return trainingActivityRecordDAO.GetActivityType(id);
        }
    }
}
