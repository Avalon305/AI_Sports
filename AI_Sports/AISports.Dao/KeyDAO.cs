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
    class KeyDAO:BaseDAO<KeyEntity>
    {

        public void UpdateMaxValue(string keyId,long steps)
        {
            using (var conn = DbUtil.getConn())
            {
                
                const string sql = "update s_key set max_value = max_value + @Steps where key_id = @KeyId";
                conn.Execute(sql, new { Steps=steps,KeyId = keyId });

            }
        }
    }
}
