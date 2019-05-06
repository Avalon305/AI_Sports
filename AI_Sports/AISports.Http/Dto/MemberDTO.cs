using AI_Sports.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Http.Dto
{
    public class MemberDTO
    {
        public string Id;
        /// 会员id
        public string MemberId;
        /// 会员名
        public string MemberFirstName;
        /// 会员姓
        public string MemberFamilyName;
        /// 出生日期
        public string BirthDate;
        /// 住址
        public string Sex;
        /// 住址
        public string Address;
        /// 邮箱地址
        public string EmailAddress;
        /// 工作电话
        public string WorkPhone;
        /// 私人电话
        public string PersonalPhone;
        /// 手机号码
        public string MobilePhone;
        /// 体重（KG）
        public string Weight;
        /// 身高 (cm)
        public string Height;
        /// 年龄
        public string Age;
        /// 最大心率=220-age
        public string MaxHeartRate;
        /// 最宜心率
        public string SuitableHeartRate;
        /// 角色id，1：会员；0：教练
        public string RoleId;
        /// 外键关联教练id
        public string FkCoachId;
        /// 标签名数组：标签名：增肌、减脂、塑形、康复，用符号分隔
        public string LabelName;
        /// 是否开启减脂模式 默认0，0:未开启，1:开启
        public string IsOpenFatReduction;
        /// 前端备注
        public string Remark;
        /// 创建时间
        public string GmtCreate;
        public string GmtModified;
        /// <summary>
        /// 最近登陆时间
        /// </summary>
        public string LastLoginDate;
        public MemberDTO()
        {

        }
        public MemberDTO(MemberEntity memberEntity)
        {
            this.Id = memberEntity.Id.ToString();
            this.MemberId = memberEntity.Member_id;
            this.MemberFirstName = memberEntity.Member_firstName;
            this.MemberFamilyName = memberEntity.Member_familyName;
            this.BirthDate = memberEntity.Birth_date.ToString().Replace("/", "-");
            this.Sex = memberEntity.Sex;
            this.Address = memberEntity.Address;
            this.EmailAddress = memberEntity.Email_address;
        }
    }
}
