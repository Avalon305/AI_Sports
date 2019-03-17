using AI_Sports.AISports.Entity;
using AI_Sports.AISports.Util;
using AI_Sports.Dao;
using AI_Sports.Util;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Dao
{
    class BluetoothReadDAO : BaseDAO<BluetoothReadEntity>
    {


        /// <summary>
        /// 查询最近修改时间在3分钟内的用户为当前扫描到的登陆用户列表
        /// </summary>
        /// <param name="memberEntity"></param>
        /// <returns></returns>
        public List<BluetoothReadEntity> ListCurrentLoginUser()
        {
            using (var conn = DbUtil.getConn())
            {
                const string query = "SELECT * FROM bluetooth_read WHERE gmt_modified >= DATE_SUB(NOW(), INTERVAL 5 MINUTE)";
                return conn.Query<BluetoothReadEntity>(query).ToList();
            }



        }

        
    }
}
