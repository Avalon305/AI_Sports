using AI_Sports.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Http.Dto
{
    public class SystemSettingDTO
    {
        public string Id;
        /// <summary>
        /// 机构名称
        /// </summary>
        public string OrganizationName;

        /// <summary>
        /// 机构电话
        /// </summary>
        public string OrganizationPhone;

        /// <summary>
        /// 机构地址
        /// </summary>
        public string OrganizationAddress;

        /// <summary>
        /// ip地址
        /// </summary>
        public string IpAddress;

        /// <summary>
        /// 创建时间
        /// </summary>
        public string GmtCreate;

        /// <summary>
        /// gmt_modified
        /// </summary>
        public string GmtModified;
        /// <summary>
        /// 系统版本 0：普通版 1：豪华版 豪华版多三种训练模式
        /// </summary>
        public string SystemVersion;

        public SystemSettingDTO ()
        {

        }
        public SystemSettingDTO (SystemSettingEntity systemSettingEntity)
        {
            this.Id = systemSettingEntity.Id.ToString();
            this.OrganizationName = systemSettingEntity.Organization_name;
            this.OrganizationPhone = systemSettingEntity.Organization_phone;
            this.OrganizationAddress = systemSettingEntity.Organization_address;
            this.IpAddress = systemSettingEntity.Ip_address;
            this.GmtCreate = systemSettingEntity.Gmt_create.ToString().Replace("/", "-");
            this.GmtModified = systemSettingEntity.Gmt_modified.ToString().Replace("/", "-");
            this.SystemVersion = systemSettingEntity.System_version.ToString();
        }
    }
}
