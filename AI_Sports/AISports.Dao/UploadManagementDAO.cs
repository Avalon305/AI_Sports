using AI_Sports.AISports.Entity;
using AI_Sports.Util;
using Dapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.Dao
{
    class UploadManagementDAO : BaseDAO<UploadManagement>
    {
        /// <summary>
        /// 查询20条数据上传
        /// </summary>
        /// <returns></returns>
        public List<UploadManagement> ListLimit20()
        {
            using (var conn = DbUtil.getConn())
            {
                conn.Open();
                const string query = "select * from bdl_uploadmanagement limit 0,20";

                return (List<UploadManagement>)conn.Query<UploadManagement>(query);

            }

        }

    }
}
