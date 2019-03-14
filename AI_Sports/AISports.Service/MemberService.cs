﻿using AI_Sports.Constant;
using AI_Sports.Dao;
using AI_Sports.Entity;
using AI_Sports.Util;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AI_Sports.Service
{
    /// <summary>
    /// 会员业务类
    /// </summary>
    class MemberService
    {
        private MemberDAO memberDAO = new MemberDAO();
        private TrainingPlanDAO trainingPlanDAO = new TrainingPlanDAO();
        private TrainingCourseDAO trainingCourseDAO = new TrainingCourseDAO();
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 新增保存会员信息
        /// </summary>
        /// <param name="memberEntity"></param>
        /// <returns></returns>
        public long InsertMember(MemberEntity memberEntity)
        {
           
            //计算最大心率 = 220 - 年龄
            memberEntity.Max_heart_rate = 220 - memberEntity.Age;
            //计算最宜心率 = （最大心率 * 76.5%）然后四舍五入为整数
            memberEntity.Suitable_heart_rate = (int?)Math.Round(memberEntity.Max_heart_rate.Value * 0.765);
            //设置主键id
            memberEntity.Id = KeyGenerator.GetNextKeyValueLong("bdl_member");
            //设置创建时间
            memberEntity.Gmt_create = System.DateTime.Now;
            if (memberEntity.Role_id == 1)//只有添加的角色是用户才设置教练外键
            {
                //当前登陆的教练Id
                memberEntity.Fk_coach_id = ParseIntegerUtil.ParseInt(CommUtil.GetSettingString("coachId"));
            }
            
            //使用基类插入新会员
            long resultCode =  memberDAO.Insert(memberEntity);
            //更新APP中会员id
            CommUtil.UpdateSettingString("memberPrimarykey",memberEntity.Id.ToString());
            //使用基类插入新会员
            return resultCode;
        }

        /// <summary>
        /// 根据会员卡号查询会员基本信息
        /// </summary>
        /// <param name="memberEntity"></param>
        /// <returns></returns>
        public MemberEntity GetMember(string Member_id)
        {
            return memberDAO.GetMember(Member_id);
        }

        /// <summary>
        /// 根据主键查询会员，可用于查询教练
        /// </summary>
        /// <param name="Member_id"></param>
        /// <returns></returns>
        public MemberEntity GetMemberByPk(int? Member_id)
        {
            return memberDAO.Load(Member_id);
        }

        /// <summary>
        /// 根据APP中的主键memberPrimarykey，查询用户，可以用于写卡前的查询、加载用户信息页面
        /// </summary>
        /// <returns></returns>
        public MemberEntity InitMemberInfo()
        {
            //判断登陆用户，是教练自己锻炼。还是教练为用户进行设置。决定传哪个参数
            string currentMemberPK = CommUtil.GetSettingString("memberPrimarykey");
            string currentCoachId = CommUtil.GetSettingString("coachId");
            if ((currentMemberPK == null || currentMemberPK == "") && (currentCoachId != null && currentCoachId != ""))
            {
                //无用户登陆。教练单独登陆时显示教练的信息。
                return memberDAO.Load(currentCoachId);
            }
            else
            {
                //只要用户登录，教练不管是否登录 都显示用户信息
                return memberDAO.Load(currentMemberPK);

            }


        }

        /// <summary>
        /// 根据教练ID查出其对应的会员集合
        /// </summary>
        /// <param name="memberEntity"></param>
        /// <returns></returns>
         List<MemberEntity> ListMemberByCoachId(MemberEntity memberEntity)
        {
            return memberDAO.listMemberByCoachId(memberEntity);
        }

        /// <summary>
        /// 刷完卡后，调用的登陆方法。读取App.config里的会员ID,根据角色跳转不同的页面。根据返回的枚举类，跳转到对应的页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public Enum Login(string memberId)
        {
            //1.获得登录会员的会员id与权限
            Console.WriteLine("登陆会员的memberId:{0}", memberId);
            //2.根据卡号查询用户详细信息
            MemberEntity member = memberDAO.GetMember(memberId);
            //如果能查到用户信息，不为null。则登陆
            if (member != null)
            {
                //把卡号和角色传递给该方法 判断四种登陆情况下该返回哪个主页面。 
                Enum resultCode =  UpdateSetting(memberId, member.Role_id.ToString());
                return resultCode;
            }
            else
            {
                Console.WriteLine("无效卡！");
                logger.Warn("未识别的登陆ID:" + memberId);
                return LoginPageStatus.UnknownID;
            }
        }


        /// <summary>
        /// 1.该方法可用于登陆后，根据传入卡号更新App.config。
        /// 2.允许教练单独登陆，那么这些设置都是教练的，可以和普通用户一样查看图表。教练、用户同时登陆则保留用户的信息，两个主键位都有值
        /// 3.参roleId 1代表用户 0代表教练
        /// 4.登陆成功的情况更新数据库最近登陆时间
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="roleId"></param>
        private Enum UpdateSetting(string memberId, string roleId)
        {
            try
            {
                //系统允许至多一位教练和一位用户同时登录，存一个用户主键和一系列ID，存一个教练id
                string currentMemberPK = CommUtil.GetSettingString("memberPrimarykey");
                string currentCoachId = CommUtil.GetSettingString("coachId");
                if ((currentMemberPK == null || currentMemberPK == "") && (currentCoachId == null || currentCoachId == ""))
                {
                    //同时为空 无人登陆
                    //判断登陆者角色 
                    if ("1".Equals(roleId))//用户
                    {
                        //1.更新会员卡号ID
                        CommUtil.UpdateSettingString("memberId", memberId);
                        //3.更新当前登陆用户的训练计划id
                        TrainingPlanEntity trainingPlanEntity = trainingPlanDAO.GetTrainingPlanByMumberId(memberId);
                        if (trainingPlanEntity != null)
                        {
                            CommUtil.UpdateSettingString("trainingPlanId", (trainingPlanEntity.Id).ToString());

                        }
                        //4.更新当前登陆用户的训练课程id
                        TrainingCourseEntity trainingCourseEntity = trainingCourseDAO.GetCourseByMemberId(memberId);
                        if (trainingCourseEntity != null)
                        {
                            CommUtil.UpdateSettingString("trainingCourseId", (trainingCourseEntity.Id).ToString());
                            //5.更新当前登陆用户的当前课程记录id current_course_count 
                            CommUtil.UpdateSettingString("currentCourseCount", (trainingCourseEntity.Current_course_count).ToString());
                            //5.更新当前登陆用户的目标课程记录id 
                            CommUtil.UpdateSettingString("targetCourseCount", (trainingCourseEntity.Target_course_count).ToString());
                        }
                        
                        //6.更新当前登陆会员的主键
                        //根据卡号查询会员
                        MemberEntity member = memberDAO.GetMember(memberId);
                        if (member != null)
                        {
                            CommUtil.UpdateSettingString("memberPrimarykey", (member.Id).ToString());
                            //7.更新会员最近登录时间
                            member.Last_login_date = System.DateTime.Now;
                            UpdateLastLoginDate(member);
                        }
                        
                        logger.Debug("状态：无教练无用户登录。用户登录，返回用户页 ID：" + memberId);
                        //需要返回的页面类型
                        return LoginPageStatus.UserPage;
                    }
                    else if ("0".Equals(roleId))//教练登陆
                    {
                        //1.更新会员卡号ID
                        CommUtil.UpdateSettingString("memberId", memberId);
                        //3.更新当前登陆用户的训练计划id
                        TrainingPlanEntity trainingPlanEntity = trainingPlanDAO.GetTrainingPlanByMumberId(memberId);
                        if (trainingPlanEntity != null)
                        {
                            CommUtil.UpdateSettingString("trainingPlanId", (trainingPlanEntity.Id).ToString());

                        }
                        //4.更新当前登陆用户的训练课程id
                        TrainingCourseEntity trainingCourseEntity = trainingCourseDAO.GetCourseByMemberId(memberId);
                        if (trainingCourseEntity != null)
                        {
                            CommUtil.UpdateSettingString("trainingCourseId", (trainingCourseEntity.Id).ToString());
                            //5.更新当前登陆用户的当前课程记录id current_course_count 
                            CommUtil.UpdateSettingString("currentCourseCount", (trainingCourseEntity.Current_course_count).ToString());
                            //5.更新当前登陆用户的目标课程记录id 
                            CommUtil.UpdateSettingString("targetCourseCount", (trainingCourseEntity.Target_course_count).ToString());
                        }
                        //6.更新当前登陆用户的主键
                        //根据卡号查询用户
                        MemberEntity member = memberDAO.GetMember(memberId);
                        if (member != null)
                        {
                           
                            //7.更新教练最近登录时间
                            member.Last_login_date = System.DateTime.Now;
                            UpdateLastLoginDate(member);
                            //8.更新教练ID
                            CommUtil.UpdateSettingString("coachId", (member.Id).ToString());
                        }
                       
                        
                        logger.Debug("状态：无教练无用户登录。教练登录，返回教练页面。ID：" + memberId);
                        //需要返回的页面类型
                        return LoginPageStatus.CoachPage;
                    }
                }
                else if ((currentMemberPK == null || currentMemberPK == "") && (currentCoachId != null && currentCoachId != ""))
                {
                    //教练已经登陆 会员未登陆 
                    //判断登陆者角色 
                    if ("1".Equals(roleId))//此时用户登陆还是在教练页面
                    {
                        //1.更新会员卡号ID
                        CommUtil.UpdateSettingString("memberId", memberId);
                        //3.更新当前登陆用户的训练计划id
                        TrainingPlanEntity trainingPlanEntity = trainingPlanDAO.GetTrainingPlanByMumberId(memberId);
                        if (trainingPlanEntity != null)
                        {
                            CommUtil.UpdateSettingString("trainingPlanId", (trainingPlanEntity.Id).ToString());

                        }
                        //4.更新当前登陆用户的训练课程id
                        TrainingCourseEntity trainingCourseEntity = trainingCourseDAO.GetCourseByMemberId(memberId);
                        if (trainingCourseEntity != null)
                        {
                            CommUtil.UpdateSettingString("trainingCourseId", (trainingCourseEntity.Id).ToString());
                            //5.更新当前登陆用户的当前课程记录id current_course_count 
                            CommUtil.UpdateSettingString("currentCourseCount", (trainingCourseEntity.Current_course_count).ToString());
                            //5.更新当前登陆用户的目标课程记录id 
                            CommUtil.UpdateSettingString("targetCourseCount", (trainingCourseEntity.Target_course_count).ToString());
                        }

                        //6.更新当前登陆会员的主键
                        //根据卡号查询会员
                        MemberEntity member = memberDAO.GetMember(memberId);
                        if (member != null)
                        {
                            CommUtil.UpdateSettingString("memberPrimarykey", (member.Id).ToString());
                            //7.更新会员最近登录时间
                            member.Last_login_date = System.DateTime.Now;
                            UpdateLastLoginDate(member);
                        }
                        
                        logger.Debug("状态：教练已经登陆 会员未登陆。用户登录，返回教练页面。ID：" + memberId);
                        return LoginPageStatus.CoachPage;
                    }
                    else if ("0".Equals(roleId))//教练重复登陆
                    {
                        logger.Debug("状态：教练已经登陆 会员未登陆。其他教练重复登录，已拦截，ID：" + memberId);
                        return LoginPageStatus.RepeatLogins;
                    }

                }
                else if ((currentMemberPK != null && currentMemberPK != "") && (currentCoachId == null || currentCoachId == ""))
                {
                    //会员已登陆 教练未登录
                    //判断登陆者角色 
                    if ("1".Equals(roleId))//用户
                    {
                        logger.Debug("状态：会员已登陆 教练未登录。其他用户重复登录，已拦截，ID：" + memberId);
                        return LoginPageStatus.RepeatLogins;
                    }
                    else if ("0".Equals(roleId))//教练登陆 原用户的设置不动 只增加教练ID
                    {
                        //8.更新教练ID
                        MemberEntity member = memberDAO.GetMember(memberId);
                        if (member != null)
                        {
                            CommUtil.UpdateSettingString("coachId", (member.Id).ToString());
                            //更新教练最近登录时间
                            member.Last_login_date = System.DateTime.Now;
                            UpdateLastLoginDate(member);
                        }
                        
                        logger.Debug("状态：会员已登陆 教练未登录。教练登录，ID：" + memberId);
                        //需要返回的页面类型
                        return LoginPageStatus.CoachPage;
                    }

                }
                else if ((currentMemberPK != null && currentMemberPK != "") && (currentCoachId != null && currentCoachId != ""))
                {
                    //会员已登录 教练已登录
                    logger.Debug("状态：会员已登录 教练已登录。已有登陆会员和教练。重复登录，ID：" + memberId);

                    return LoginPageStatus.RepeatLogins;
                }
                else
                {
                    return LoginPageStatus.UnknownID;
                }

            }
            catch (Exception ex)
            {
                logger.Warn("用户登录更新配置类出现异常");
                throw new Exception("用户登录更新配置类出现异常", ex);
            }
            
                return LoginPageStatus.UnknownID;


        }
        /// <summary>
        /// 所有配置清空
        /// </summary>
        public void Logout()
        {
            //1.更新会员卡号ID
            CommUtil.UpdateSettingString("memberId", "");
            //3.更新当前登陆用户的训练计划id
            CommUtil.UpdateSettingString("trainingPlanId", "");
            //4.更新当前登陆用户的训练课程id
            CommUtil.UpdateSettingString("trainingCourseId", "");
            //5.更新当前登陆用户的当前课程记录id current_course_count 
            CommUtil.UpdateSettingString("currentCourseCount", "");
            //5.更新当前登陆用户的目标课程记录id 
            CommUtil.UpdateSettingString("targetCourseCount", "");
            //6.更新当前登陆会员的主键
            CommUtil.UpdateSettingString("memberPrimarykey", "");
            //8.更新教练ID
            CommUtil.UpdateSettingString("coachId", "");
        }

        /// <summary>
        /// 查询7天内登陆的活跃会员
        /// </summary>
        /// <returns></returns>
        public List<MemberEntity> ListActiveMember()
        {
            return memberDAO.ListActiveMember();
        }
        /// <summary>
        /// 查询大于7天未登录的不活跃会员
        /// </summary>
        /// <returns></returns>
        public List<MemberEntity> ListInactiveMember()
        {
            return memberDAO.ListInactiveMember();
        }
        /// <summary>
        /// 更新会员的登陆时间
        /// </summary>
        public void UpdateLastLoginDate(MemberEntity memberEntity)
        {
            memberDAO.UpdateByPrimaryKey(memberEntity);
        }
          /// <summary>
        /// 查询所有会员信息
        /// </summary>
        /// <returns></returns>
        public List<MemberEntity> ListAllMember()
        {
            return memberDAO.ListAllMember();
        }


        /// <summary>
        /// 模糊查询名字手机号
        /// </summary>
        /// <returns></returns>
        public List<MemberEntity> ListNameMember(String firstName,String phone_Number)
        {
            return memberDAO.ListNameMember(firstName,phone_Number);
        }


        

    }
}
