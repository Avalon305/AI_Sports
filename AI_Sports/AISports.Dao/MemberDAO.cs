using AI_Sports.Dao;
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
    /// <summary>
    /// 会员DAO-CQZ
    /// </summary>
    class MemberDAO : BaseDAO<MemberEntity>
    {
        /// <summary>
        /// 新增会员插入基本信息，不包括卡号
        /// </summary>
        /// <param name="memberEntity"></param>
        /// <returns></returns>
        public int InsertMember(MemberEntity memberEntity)
        {
            using (var conn = DbUtil.getConn())
            {
                const string insert = "INSERT INTO bdl_member (`member_firstName`, `member_familyName`, `birth_date`, `sex`, `address`, `email_address`, `work_phone`, `personal_phone`, `mobile_phone`, `weight`, `height`, `age`, `max_heart_rate`, `suitable_heart_rate`, `role_id`, `fk_coach_id`, `label_name`, `remark`) VALUES (@Member_firstName, @Member_familyName, @Birth_date, @Sex, @Address, @Email_address, @Work_phone, @Personal_phone, @Mobile_phone, @Weight, @Height, @Age, @Max_heart_rate, @Suitable_heart_rate, @Role_id, @Fk_coach_id, @Label_name, @Remark)";

                return conn.Execute(insert, memberEntity);

            }
        }
        /// <summary>
        /// 根据会员卡号查询会员基本信息
        /// </summary>
        /// <param name="memberEntity"></param>
        /// <returns></returns>
        public MemberEntity GetMember(string Member_id)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT bdl_member.id,bdl_member.member_id,bdl_member.member_firstName,bdl_member.member_familyName,bdl_member.birth_date,bdl_member.sex,bdl_member.address,bdl_member.email_address,bdl_member.work_phone,bdl_member.personal_phone,bdl_member.mobile_phone,bdl_member.weight,bdl_member.height,bdl_member.age,bdl_member.max_heart_rate,bdl_member.suitable_heart_rate,bdl_member.role_id,bdl_member.fk_coach_id,bdl_member.label_name,bdl_member.is_open_fat_reduction,bdl_member.remark,bdl_member.gmt_create,bdl_member.gmt_modified FROM bdl_member WHERE member_id = @Member_id";
                return conn.QueryFirstOrDefault<MemberEntity>(query, new { Member_id = Member_id });
            }
        }
        /// <summary>
        /// /查询新增用户时只保存了基本信息还没有写卡的会员，查询条件是memeber_id为NULL
        /// </summary>
        /// <returns></returns>
        public MemberEntity GetMemberToWriteCard()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT bdl_member.id,bdl_member.member_id,bdl_member.member_firstName,bdl_member.member_familyName,bdl_member.birth_date,bdl_member.sex,bdl_member.address,bdl_member.email_address,bdl_member.work_phone,bdl_member.personal_phone,bdl_member.mobile_phone,bdl_member.weight,bdl_member.height,bdl_member.age,bdl_member.max_heart_rate,bdl_member.suitable_heart_rate,bdl_member.role_id,bdl_member.fk_coach_id,bdl_member.label_name,bdl_member.is_open_fat_reduction,bdl_member.remark,bdl_member.gmt_create,bdl_member.gmt_modified FROM bdl_member WHERE ISNULL(member_id)";
                return conn.QueryFirstOrDefault<MemberEntity>(query);
            }
        }

        /// <summary>
        /// 根据教练ID查出其对应的会员集合
        /// </summary>
        /// <param name="memberEntity"></param>
        /// <returns></returns>
        public List<MemberEntity> listMemberByCoachId(MemberEntity memberEntity)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT * FROM bdl_member WHERE fk_coach_id = @Fk_coach_id";
                return conn.Query<MemberEntity>(query, new { Fk_coach_id = memberEntity.Fk_coach_id }).ToList();
            }
        }

      
    }


}
