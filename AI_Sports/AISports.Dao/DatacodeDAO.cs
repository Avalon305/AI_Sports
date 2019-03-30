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
    class DatacodeDAO :BaseDAO<DatacodeEntity>
    {

        public List<DatacodeEntity> ListByTypeId(string typeId)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "select * from bdl_datacode where code_type_id = @Code_type_id and code_state = 1 order by code_xh";

                return (List<DatacodeEntity>)conn.Query<DatacodeEntity>(query, new { Code_type_id = typeId });
            }
        }
        public int? GetMaxXh(string typeId)
        {
            using (var conn = DbUtil.getConn())
            {
               const string query = "select if(isnull(MAX(code_xh)),0,MAX(code_xh)) maxXh from bdl_datacode WHERE code_type_id = @TypeId ";
               return conn.QueryFirst<int>(query, new { TypeId = typeId });
            }
            
        }

        public string GetByTypeIdAndCodeS(string typeId,string codeS)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "select code_d_value from bdl_datacode where code_type_id = @Code_type_id and code_s_value = @codeS";
                return conn.QueryFirst<string>(query, new { Code_type_id = typeId ,codeS });
            }

        }

        public List<DatacodeEntity> ListByTypeIdAndExtValue(string typeId,string cycleType)
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "select * from bdl_datacode where code_type_id = @Code_type_id and code_state = 1 And Code_ext_value2 = @Cycle_type order by code_xh";

                return (List<DatacodeEntity>)conn.Query<DatacodeEntity>(query, new { Code_type_id = typeId, Cycle_type = cycleType });
            }
        }



    }
}
