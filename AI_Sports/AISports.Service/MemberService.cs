using AI_Sports.Dao;
using AI_Sports.Entity;
using AI_Sports.Util;
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

        /// <summary>
        /// 新增保存会员信息
        /// </summary>
        /// <param name="memberEntity"></param>
        /// <returns></returns>
        public long InsertMember(MemberEntity memberEntity)
        {
            //通过出生日期获得出生年份字符串
            string birthYear = memberEntity.Birth_date.Value.ToString("yyyy");
            //安全得将出生年份字符串转换为整型
            int? parseInt = ParseIntegerUtil.ParseInt(birthYear);
            //当前年份转为整型
            int? currentYear = ParseIntegerUtil.ParseInt(DateTime.Now.Year.ToString());
            //当前年份与出生年份相减计算年龄    
            memberEntity.Age = (currentYear - parseInt);
            //计算最大心率 = 220 - 年龄
            memberEntity.Max_heart_rate = 220 - memberEntity.Age;
            //计算最宜心率 = （最大心率 * 76.5%）然后四舍五入为整数
            memberEntity.Suitable_heart_rate = (int?)Math.Round(memberEntity.Max_heart_rate.Value * 0.765);
            //设置主键id
            memberEntity.Id = KeyGenerator.GetNextKeyValueLong("bdl_member");
            //设置创建时间
            memberEntity.Gmt_create = new DateTime();
            //使用基类插入新会员
            return memberDAO.Insert(memberEntity);
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
        /// 查询出刚添加的会员信息，准备写卡
        /// </summary>
        /// <returns></returns>
        public MemberEntity GetMemberToWriteCard()
        {
            return memberDAO.GetMemberToWriteCard();
        }

        /// <summary>
        /// 根据教练ID查出其对应的会员集合
        /// </summary>
        /// <param name="memberEntity"></param>
        /// <returns></returns>
        public List<MemberEntity> ListMemberByCoachId(MemberEntity memberEntity)
        {
            return memberDAO.listMemberByCoachId(memberEntity);
        }


        /// <summary>
        /// 1.该方法可用于刷卡后，根据传入卡号更新App.config。然后调用登陆读取App.config的appSettings
        /// 2.可用于退出时，传入两个空字符串更新缓存设置
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="roleId"></param>
        private void UpdateSetting(string memberId, string roleId)
        {
            //1.更新会员卡ID
            CommUtil.UpdateSettingString("memberId", memberId);
            //2.更新角色ID
            CommUtil.UpdateSettingString("roleId", roleId);
            //3.更新当前登陆用户的训练计划id
            TrainingPlanEntity trainingPlanEntity = trainingPlanDAO.GetTrainingPlanByMumberId(memberId);
            CommUtil.UpdateSettingString("trainingPlanId", (trainingPlanEntity.Id).ToString());
            //4.更新当前登陆用户的训练课程id
            TrainingCourseEntity trainingCourseEntity = trainingCourseDAO.GetCourseByMemberId(memberId);
            CommUtil.UpdateSettingString("trainingCourseId", (trainingCourseEntity.Id).ToString());
            //5.更新当前登陆用户的当前课程记录id current_course_count 
            CommUtil.UpdateSettingString("currentCourseCount", (trainingCourseEntity.Current_course_count).ToString());
            //5.更新当前登陆用户的目标课程记录id 
            CommUtil.UpdateSettingString("targetCourseCount", (trainingCourseEntity.Target_course_count).ToString());
            //6.更新当前登陆会员的主键
            //根据卡号查询会员
            MemberEntity member = memberDAO.GetMember(memberId);
            CommUtil.UpdateSettingString("memberPrimarykey", (member.Id).ToString());
        }


    }
}
