using AI_Sports.Dao;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Entity
{
    [Serializable]
    [Table("bluetooth_read")]
    class BluetoothReadEntity
    {
        /// 主键自增id
        [ExplicitKey]
        public long Id { get; set; } = 0;
        /// 会员id
        public string Member_id { get; set; }
        //扫描计数 默认：0，蓝牙每扫描到一次该字段加1 这样就修改了Gmt_modified字段，根据Gmt_modified查询最近3分钟的登陆
        public int Scan_count { get; set; }
        /// 创建时间
        //public DateTime? Gmt_create { get; set; }
        //最近修改时间 1970至今的时间戳
        public long Gmt_modified { get; set; }
    }
}
