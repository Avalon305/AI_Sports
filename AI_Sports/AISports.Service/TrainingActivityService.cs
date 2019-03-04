using AI_Sports.Dao;
using AI_Sports.Entity;
using System.Collections.Generic;
using AI_Sports.Util;
using AI_Sports.AISports.Dto;
using System.Transactions;

namespace AI_Sports.Service
{
    /// <summary>
    /// 训练活动表和训练活动记录表的service
    /// </summary>
    class TrainingActivityService
    {
        private ActivityDAO activityDAO = new ActivityDAO();
        private TrainingActivityRecordDAO trainingActivityRecordDAO = new TrainingActivityRecordDAO();
        private PersonalSettingService personalSettingService = new PersonalSettingService();
        /// <summary>
        /// 批量插入训练活动
        /// </summary>
        /// <param name="activities"></param>
        /// <returns></returns>
        public long BatchSaveActivity(List<ActivityEntity> activities)
        {
            using (TransactionScope ts = new TransactionScope())
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
                //批量插入训练活动
                long result = activityDAO.BatchInsert(activities);
                //根据训练活动批量插入个人设置记录
                personalSettingService.SavePersonalSettings();

                

                ts.Complete();
                return result;
            }
               
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
        /// <summary>
        /// EditActivity页面分组头转换器用 根据课程id和活动类型查出目标伦次
        /// </summary>
        /// <param name="activityType"></param>
        /// <returns></returns>
        public int GetTargetTurnNumByType(string activityType)
        {
            string courseId = CommUtil.GetSettingString("trainingCourseId");
            return activityDAO.GetTargetTurnNumByTypeCourseId(activityType,courseId);
        }
        /// <summary>
        /// EditActity页活动分组Expnder中的个人设置查询 分组是前端根据活动类型分
        /// </summary>
        /// <returns></returns>
        public List<ActivityGroupDTO> ListActivitysGroupAndPersonalSetting()
        {
            //当前正在进行和训练课程ID
            long courseId = ParseIntegerUtil.ParseInt(CommUtil.GetSettingString("trainingCourseId"));
            return activityDAO.ListActivitysGroupAndPersonalSetting(courseId);
        }
        /// <summary>
        /// 根据课程id和活动类型更新活动目标轮次
        /// </summary>
        /// <param name="activityEntity"></param>
        /// <returns></returns>
        public int UpdateTargetTurnNumber(ActivityEntity activityEntity)
        {
            return activityDAO.UpdateTargetTurnNumber(activityEntity);
        }

    }
}
