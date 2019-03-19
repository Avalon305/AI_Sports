using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Entity
{
    [Serializable]
    [Table("bluetooth_write")]
    class BluetoothWriteEntity
    {
        /// 主键自增id
        [ExplicitKey]
        public long Id { get; set; } = 0;
        /// 会员id
        public string Member_id { get; set; }
        //写入状态 0：未写入。1：写入成功。2：写入失败默认为0
        public int Write_state { get; set; }
        //要写入的蓝牙手环名称
        public string Bluetooth_name { get; set; }
        /// 创建时间
        //public DateTime? Gmt_create { get; set; }
        //最近修改时间 1970至今的时间戳
        public long Gmt_modified { get; set; }
    }
}
