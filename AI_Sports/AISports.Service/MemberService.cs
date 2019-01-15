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

        /// <summary>
        /// 新增保存会员信息
        /// </summary>
        /// <param name="memberEntity"></param>
        /// <returns></returns>
        public int InsertMember(MemberEntity memberEntity)
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
            //
            return memberDAO.InsertMember(memberEntity);
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
        public List<MemberEntity> listMemberByCoachId(MemberEntity memberEntity)
        {
            return memberDAO.listMemberByCoachId(memberEntity);
        }

       

      
        
    }
}
