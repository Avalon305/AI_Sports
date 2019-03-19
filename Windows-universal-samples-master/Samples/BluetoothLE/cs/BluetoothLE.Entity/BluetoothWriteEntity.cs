//坑！！：实体类一定要用这个引用 否则 实体类无法映射到对应表 而是用实体类的属性新建表。
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluetoothEntity
{
    [Table("bluetooth_write")]

    class BluetoothWriteEntity
    {
        [Column("id")]
        [PrimaryKey]
        [AutoIncrement()]
        /// 主键自增id
        public long Id { get; set; } = 0;
        [Column("member_id")]
        /// 会员id
        public string Member_id { get; set; }
        [Column("write_state")]
        //写入状态 0：未写入。1：写入成功。2：写入失败默认为0
        public int Write_state { get; set; }
        [Column("bluetooth_name")]
        //要写入的蓝牙手环名称
        public string Bluetooth_name { get; set; }
        [Column("gmt_modified")]
        /// 创建时间
        //public DateTime? Gmt_create { get; set; }
        //最近修改时间 1970至今的时间戳
        public long Gmt_modified { get; set; }
    }
}
