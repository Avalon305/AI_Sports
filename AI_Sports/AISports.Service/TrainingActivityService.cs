using AI_Sports.Dao;
using AI_Sports.Entity;
using System.Collections.Generic;
using AI_Sports.Util;
using AI_Sports.AISports.Dto;
using System.Transactions;
using AI_Sports.Constant;
using AI_Sports.AISports.Entity;

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
                UploadManagementDAO uploadManagementDao2 = new UploadManagementDAO();
                long result = 0;
                //判断登陆用户，是教练自己锻炼。还是教练为用户进行设置。决定传哪个参数
                string currentMemberPK = CommUtil.GetSettingString("memberPrimarykey");
                string currentCoachId = CommUtil.GetSettingString("coachId");
                if ((currentMemberPK == null || currentMemberPK == "") && (currentCoachId != null && currentCoachId != ""))
                {
                    //无用户登陆。教练单独登陆时对教练进行设置
                    foreach (var activity in activities)
                    {
                        activity.Id = KeyGenerator.GetNextKeyValueLong("bdl_activity");
                        activity.Member_id = CommUtil.GetSettingString("memberId");
                        activity.Fk_member_id = ParseIntegerUtil.ParseInt(CommUtil.GetSettingString("coachId"));
                        activity.Fk_training_course_id = ParseIntegerUtil.ParseInt(CommUtil.GetSettingString("trainingCourseId"));
                        activity.Gmt_create = System.DateTime.Now;
                        activity.Is_complete = false;
                        activity.current_turn_number = 0;
                        //插入至上传表
                        uploadManagementDao2.Insert(new UploadManagement(activity.Id, "bdl_activity", 0));
                    }
                    //批量插入训练活动
                    result = activityDAO.BatchInsert(activities);
                    //根据训练活动批量插入个人设置记录 传入教练的主键id
                    personalSettingService.SavePersonalSettings(ParseIntegerUtil.ParseInt(CommUtil.GetSettingString("coachId")));
                }
                else
                {
                    //只要用户登录，为用户进行设置
                    foreach (var activity in activities)
                    {
                        activity.Id = KeyGenerator.GetNextKeyValueLong("bdl_activity");
                        activity.Member_id = CommUtil.GetSettingString("memberId");
                        activity.Fk_member_id = ParseIntegerUtil.ParseInt(CommUtil.GetSettingString("memberPrimarykey"));
                        activity.Fk_training_course_id = ParseIntegerUtil.ParseInt(CommUtil.GetSettingString("trainingCourseId"));
                        activity.Gmt_create = System.DateTime.Now;
                        activity.Is_complete = false;
                        activity.current_turn_number = 0;
                        //插入至上传表

                        uploadManagementDao2.Insert(new UploadManagement(activity.Id, "bdl_activity", 0));
                    }
                
                    //批量插入训练活动
                    result = activityDAO.BatchInsert(activities);
                    //根据训练活动批量插入个人设置记录 传入会员的主键id
                    personalSettingService.SavePersonalSettings(ParseIntegerUtil.ParseInt(CommUtil.GetSettingString("memberPrimarykey")));
                }                

                ts.Complete();
                return result;
            }
               
        }


        /// <summary>
        /// 根据模板自动创建训练活动 传入的是用户的数据库主键id
        /// </summary>
        /// <param name="trainingCourseEntity"></param>
        /// <param name="memberPkId"></param>
        /// <param name="planTemplate"></param>
        /// <returns></returns>
        public long AutoSaveActivityTemplate(TrainingCourseEntity trainingCourseEntity, long memberPkId , PlanTemplate planTemplate)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                long result = 0;

                List<ActivityEntity> activities = new List<ActivityEntity>();
                //力量循环活动
                ActivityEntity strengthActivity = new ActivityEntity();
                //耐力循环活动
                ActivityEntity enduranceActivity = new ActivityEntity();
                //上传表
                UploadManagementDAO uploadManagementDao = new UploadManagementDAO();

                //根据不同模板创建不同的活动
                switch (planTemplate)
                {
                    case PlanTemplate.StrengthCycle://力量循环
                        strengthActivity.Id = KeyGenerator.GetNextKeyValueLong("bdl_activity");
                        strengthActivity.Member_id = trainingCourseEntity.Member_id;
                        strengthActivity.Fk_member_id = memberPkId;
                        strengthActivity.Fk_training_course_id = trainingCourseEntity.Id;
                        strengthActivity.Gmt_create = System.DateTime.Now;
                        strengthActivity.Is_complete = false;
                        //模板创建默认两轮
                        strengthActivity.Target_turn_number = 2;
                        strengthActivity.current_turn_number = 0;
                        //0:力量循环
                        strengthActivity.Activity_type = "0";

                        activities.Add(strengthActivity);
                        // 插入至上传表
                        uploadManagementDao.Insert(new UploadManagement(strengthActivity.Id, "bdl_activity", 0));
                        break;
                    case PlanTemplate.EnduranceCycle://耐力循环
                        enduranceActivity.Id = KeyGenerator.GetNextKeyValueLong("bdl_activity");
                        enduranceActivity.Member_id = trainingCourseEntity.Member_id;
                        enduranceActivity.Fk_member_id = memberPkId;
                        enduranceActivity.Fk_training_course_id = trainingCourseEntity.Id;
                        enduranceActivity.Gmt_create = System.DateTime.Now;
                        enduranceActivity.Is_complete = false;
                        //模板创建默认两轮
                        enduranceActivity.Target_turn_number = 2;
                        enduranceActivity.current_turn_number = 0;
                        //1:耐力循环
                        enduranceActivity.Activity_type = "1";

                        activities.Add(enduranceActivity);
                        //插入至上传表
                        uploadManagementDao.Insert(new UploadManagement(enduranceActivity.Id, "bdl_activity", 0));
                        break;
                    case PlanTemplate.StrengthEnduranceCycle:
                        //创建力量循环活动
                        strengthActivity.Id = KeyGenerator.GetNextKeyValueLong("bdl_activity");
                        strengthActivity.Member_id = trainingCourseEntity.Member_id;
                        strengthActivity.Fk_member_id = memberPkId;
                        strengthActivity.Fk_training_course_id = trainingCourseEntity.Id;
                        strengthActivity.Gmt_create = System.DateTime.Now;
                        strengthActivity.Is_complete = false;
                        //模板创建默认两轮
                        strengthActivity.Target_turn_number = 2;
                        strengthActivity.current_turn_number = 0;
                        //0:力量循环
                        strengthActivity.Activity_type = "0";

                        activities.Add(strengthActivity);
                        //插入至上传表
                        uploadManagementDao.Insert(new UploadManagement(strengthActivity.Id, "bdl_activity", 0));
                        //创建耐力循环活动
                        enduranceActivity.Id = KeyGenerator.GetNextKeyValueLong("bdl_activity");
                        enduranceActivity.Member_id = trainingCourseEntity.Member_id;
                        enduranceActivity.Fk_member_id = memberPkId;
                        enduranceActivity.Fk_training_course_id = trainingCourseEntity.Id;
                        enduranceActivity.Gmt_create = System.DateTime.Now;
                        enduranceActivity.Is_complete = false;
                        //模板创建默认两轮
                        enduranceActivity.Target_turn_number = 2;
                        enduranceActivity.current_turn_number = 0;
                        //1:耐力循环
                        enduranceActivity.Activity_type = "1";

                        activities.Add(enduranceActivity);
                        //插入至上传表
                        uploadManagementDao.Insert(new UploadManagement(enduranceActivity.Id, "bdl_activity", 0));
                        break;
                    default:
                        break;
                }

                //批量插入训练活动
                result = activityDAO.BatchInsert(activities);
                //根据训练活动批量插入个人设置记录 传入用户主键id
                personalSettingService.AutoSavePersonalSettings(memberPkId, trainingCourseEntity.Id , trainingCourseEntity.Member_id);


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
            string memberId = CommUtil.GetSettingString("memberId");
            return trainingActivityRecordDAO.ListActivityRecords(currentCourseCount , memberId);
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
        public int? GetTargetTurnNumByType(string activityType)
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

		///zfc
		/// <summary>
		/// 根据外键训练课程id完成训练活动，把is_complete标志位置为0，current_turn_number置为0
		/// </summary>
		/// <param name="trainingcourseid"></param>
		/// <param name="complete"></param>
		/// <returns></returns>
		public int UpdateCompleteFinish(int trainingcourseid, int complete)
		{
            UploadManagementDAO uploadManagementDao = new UploadManagementDAO();
            List<long> listId = new List<long>();
            //通过memberId获取主键id
            listId = activityDAO.ListIdByfkTrainingCourseId(trainingcourseid);
            foreach (var id in listId)
            {
                //数据上传
                uploadManagementDao.Insert(new UploadManagement(id, "bdl_activity", 1));
            }
            return activityDAO.UpdateCompleteFinish(trainingcourseid, complete);
		}

		///zfc
		/// <summary>
		/// 根据训练课程id更新训练活动记录 完成状态
		/// </summary>
		/// <param name="fk_training_course_id"></param>
		/// <param name="complete"></param>
		public void UpdateRecordCompleteFinish(int trainingcourseid, int complete)
		{
            UploadManagementDAO uploadManagementDao = new UploadManagementDAO();
            trainingActivityRecordDAO.UpdateCompleteFinish(trainingcourseid, complete);
            //数据上传
            uploadManagementDao.Insert(new UploadManagement(trainingcourseid, "bdl_training_activity_record", 1));
            

		}

	}
}
