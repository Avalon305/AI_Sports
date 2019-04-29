using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Entity
{
    //上传管理者，每个管理者有一个任务使命
    [Table("bdl_uploadmanagement")]
    class UploadManagement
    {
        
        [Key]//主键
        public long Pk_UM_Id { get; set; }
        //数据的ID
        public long UM_DataId { get; set; }
        //持有数据所在的表名
        public string UM_DataTable { get; set; }
        //操作的类型 add是0 update是1
        public int UM_Exec { get; set; }
        //ID构造器
        public UploadManagement(long keyID)
        {
            this.Pk_UM_Id = keyID;
        }
        public UploadManagement()
        {
        }

        public UploadManagement(long umDataId, string umDataTable, int umexec)
        {
            UM_DataId = umDataId;
            UM_DataTable = umDataTable;
            UM_Exec = umexec;
        }
    }

}
