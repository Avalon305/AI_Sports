//坑！！：实体类一定要用这个引用 否则 实体类无法映射到对应表 而是用实体类的属性新建表。
using SQLite.Net.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluetoothEntity
{
    [Table("bluetooth_read")]

    class BluetoothReadEntity
    {
        [Column("id")]
        [PrimaryKey]
        [AutoIncrement()]
        /// 主键自增id
        public long Id { get; set; } = 0;
        [Column("member_id")]
        /// 会员id
        public string Member_id { get; set; }
        [Column("scan_count")]
        //扫描计数 默认：0，蓝牙每扫描到一次该字段加1 这样就修改了Gmt_modified字段，根据Gmt_modified查询最近3分钟的登陆
        public int Scan_count { get; set; }
        /// 创建时间
        //public DateTime? Gmt_create { get; set; }
        //最近修改时间 1970至今的时间戳
        [Column("gmt_modified")]
        public long Gmt_modified { get; set; }
    }
}
