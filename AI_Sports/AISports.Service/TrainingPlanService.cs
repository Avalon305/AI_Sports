using System.Collections.Generic;
using System.Transactions;
using AI_Sports.Constant;
using AI_Sports.Dao;
using AI_Sports.Entity;
using AI_Sports.Util;

namespace AI_Sports.Service
{
    class TrainingPlanService
    {
        private TrainingPlanDAO trainingPlanDAO = new TrainingPlanDAO();
        private TrainingCourseDAO trainingCourseDAO = new TrainingCourseDAO();
        private ActivityDAO activityDAO = new ActivityDAO();
        private TrainingCourseService trainingCourseService = new TrainingCourseService();
        /// <summary>
        /// 添加新的训练计划，需要先删除旧的训练计划
        /// </summary>
        /// <param name="trainingPlan"></param>
        /// <returns></returns>
        public void SaveNewTrainingPlan(TrainingPlanEntity trainingPlan)
        {
            
            //使整个代码块成为事务性代码
            using (TransactionScope ts = new TransactionScope())
            {
                //会员卡号ID
                string memberId = CommUtil.GetSettingString("memberId");
                //1.删除旧的训练计划
                trainingPlanDAO.DeletePlanByMemberId(memberId);
                //2.完成旧的训练课程
                trainingCourseDAO.UpdateCompleteState(memberId, true);
                //3.完成旧的训练活动
                activityDAO.UpdateCompleteState(memberId, true);
                //4.新增训练计划
                trainingPlan.Id = KeyGenerator.GetNextKeyValueLong("bdl_training_plan");

                //判断登陆用户，是教练自己锻炼。还是教练为用户进行设置。决定传哪个主键设置
                string currentMemberPK = CommUtil.GetSettingString("memberPrimarykey");
                string currentCoachId = CommUtil.GetSettingString("coachId");
                if ((currentMemberPK == null || currentMemberPK == "") && (currentCoachId != null && currentCoachId != ""))
                {
                    //无用户登陆。教练单独登陆时
                    //  从app.config中取id,转成int赋值
                    trainingPlan.Fk_member_id = ParseIntegerUtil.ParseInt(currentCoachId);
                }
                else
                {
                    //只要用户登录，就是为用户进行设置
                    //  从app.config中取id,转成int赋值
                    trainingPlan.Fk_member_id = ParseIntegerUtil.ParseInt(currentMemberPK);

                }

                
                //  设置会员卡号
                trainingPlan.Member_id = CommUtil.GetSettingString("memberId");
                //  设置状态为未删除
                trainingPlan.Is_deleted = false;
                //  创建时间
                trainingPlan.Gmt_create = System.DateTime.Now;
                //  插入新训练计划
                trainingPlanDAO.Insert(trainingPlan);
                //5.更新App.config中训练计划id
                CommUtil.UpdateSettingString("trainingPlanId", (trainingPlan.Id).ToString());

                //插入默认训练课程 课程开始时间 = 训练计划开始时间
                trainingCourseService.SaveTrainingCourse(trainingPlan.Start_date);
                ts.Complete();
            }

        }


        /// <summary>
        /// 自动创建模板训练计划 2019.3.27
        /// </summary>
        /// <param name="memberId"></param>
        public void AutoSaveNewPlan(MemberEntity memberEntity , PlanTemplate planTemplate)
        {
            //使整个代码块成为事务性代码
            using (TransactionScope ts = new TransactionScope())
            {
                TrainingPlanEntity trainingPlan = new TrainingPlanEntity();

                //会员卡号ID
                string memberId = memberEntity.Member_id;

                //1.删除旧的训练计划
                trainingPlanDAO.DeletePlanByMemberId(memberId);
                //2.完成旧的训练课程
                trainingCourseDAO.UpdateCompleteState(memberId, true);
                //3.完成旧的训练活动
                activityDAO.UpdateCompleteState(memberId, true);
                //4.新增训练计划
                trainingPlan.Id = KeyGenerator.GetNextKeyValueLong("bdl_training_plan");
                //外键用户主键id
                trainingPlan.Fk_member_id = memberEntity.Id;
                //  设置会员卡号
                trainingPlan.Member_id = memberEntity.Member_id;
                // 开始时间
                trainingPlan.Start_date = System.DateTime.Now;
                //  设置状态为未删除
                trainingPlan.Is_deleted = false;
                //  创建时间
                trainingPlan.Gmt_create = System.DateTime.Now;
                //训练计划标题
                trainingPlan.Title = "力量循环与耐力循环";
                trainingPlan.Training_target = "塑形";
                //  插入新训练计划
                trainingPlanDAO.Insert(trainingPlan);

                //自动创建模板课程
                trainingCourseService.AutoSaveNewTemplateCourse(trainingPlan, planTemplate);
                ts.Complete();
            }
        }


        /// <summary>
        /// 根据当前登陆会员 获得其训练计划
        /// </summary>
        /// <returns></returns>
        public TrainingPlanEntity GetPlanByMumberId()
        {
            string memberId = CommUtil.GetSettingString("memberId");
            return trainingPlanDAO.GetTrainingPlanByMumberId(memberId);
        }
		/// <summary>
		/// 根据当前登录会员，获得所有的训练计划
		/// </summary>
		/// <returns></returns>
		public List<TrainingPlanEntity> GetAllPlan()
		{
			string memberId = CommUtil.GetSettingString("memberId");
			return trainingPlanDAO.GetAllPlan(memberId);
		}
        /// <summary>
        ///查询训练计划分析页面展示的信息，参数为AppConfig中的当前训练计划id，当前训练课程id
        /// </summary>
        /// <returns></returns>
        public TrainingPlanVO GetTrainingPlanVO()
        {
            string trainingPlanId = CommUtil.GetSettingString("trainingPlanId");
            string trainingCourseId = CommUtil.GetSettingString("trainingCourseId");
            return trainingPlanDAO.GetTrainingPlanVO(trainingPlanId, trainingCourseId);
        }

        



        public int selectRecordNumber()
        {
            return trainingPlanDAO.selectRecordNumber();
        }

        public List<double> selectAerobicEnergy(string trainingPlanId)
        {
            return trainingPlanDAO.selectAerobicEnergy(trainingPlanId);
        }

        public List<double> selectForceEnergy(string trainingPlanId)
        {
            return trainingPlanDAO.selectForceEnergy(trainingPlanId);
        }
    }
}
