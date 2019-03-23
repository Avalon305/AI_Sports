using AI_Sports.AISports.Entity;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.Util
{
    class SQLiteUtil
    {
        // 数据库文件夹
        //static string DbPath = Path.Combine(YatesHelper.GetAppDefaultPath(), "Database");
        //static string DbPath = "E:\\usr";
        static string DbPath = "C:\\Users\\Saber\\AppData\\Local\\Packages\\Microsoft.SDKSamples.BluetoothLE.CS_8wekyb3d8bbwe\\LocalState";
        //与指定的数据库(实际上就是一个文件)建立连接
        private static SQLiteConnection CreateDatabaseConnection(string dbName = null)
        {
            if (!string.IsNullOrEmpty(DbPath) && !Directory.Exists(DbPath))
                Directory.CreateDirectory(DbPath);
            dbName = dbName == null ? "database.db" : dbName;
            var dbFilePath = Path.Combine(DbPath, dbName);
            return new SQLiteConnection("DataSource = " + dbFilePath);
        }

        // 使用全局静态变量保存连接
        private static SQLiteConnection connection = CreateDatabaseConnection("bdl_bluetooth.db");

        // 判断连接是否处于打开状态
        private static void Open(SQLiteConnection connection)
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }


        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        public static void ExecuteNonQuery(string sql)
        {
            // 确保连接打开
            Open(connection);

            using (var tr = connection.BeginTransaction())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
                tr.Commit();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sql"></param>
        public static void ExecuteQuery(string sql)
        {
            // 确保连接打开
            Open(connection);

            using (var tr = connection.BeginTransaction())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sql;

                    // 执行查询会返回一个SQLiteDataReader对象
                    var reader = command.ExecuteReader();

                    //reader.Read()方法会从读出一行匹配的数据到reader中。注意：是一行数据。
                    while (reader.Read())
                    {
                        // 有一系列的Get方法，方法的参数是列数。意思是获取第n列的数据，转成Type返回。
                        // 比如这里的语句，意思就是：获取第0列的数据，转成int值返回。
                        var time = reader.GetInt64(0);
                    }
                }
                
                tr.Commit();
            }
        }

        /// <summary>
        /// 查询最近登录的用户 传入时间戳 查询最近几分钟扫描到的手环
        /// </summary>
        public static List<BluetoothReadEntity> ListCurrentLoginUser(string timeStamp)
        {
            // 确保连接打开
            Open(connection);
            //实例化实体类集合
            List<BluetoothReadEntity> bluetoothReadEntities = new List<BluetoothReadEntity>();
            using (var tr = connection.BeginTransaction())
            {
                using (var command = connection.CreateCommand())
                {
                    string sql = "select * from bluetooth_read where gmt_modified >= ";
                    sql += timeStamp;

                    command.CommandText = sql;

                    // 执行查询会返回一个SQLiteDataReader对象
                    var reader = command.ExecuteReader();
                   
                    //reader.Read()方法会从读出一行匹配的数据到reader中。注意：是一行数据。
                    while (reader.Read())
                    {
                        //实例化一个读取实体类
                        BluetoothReadEntity bluetoothReadEntity = new BluetoothReadEntity();

                        // 有一系列的Get方法，方法的参数是列数。意思是获取第n列的数据，转成Type返回。
                        // 比如这里的语句，意思就是：获取第0列的数据，转成int值返回。
                        bluetoothReadEntity.Id = reader.GetInt64(0);
                        bluetoothReadEntity.Member_id = reader.GetString(1);
                        bluetoothReadEntity.Scan_count = reader.GetInt32(2);
                        bluetoothReadEntity.Gmt_modified = reader.GetInt64(3);
                        //添加到集合
                        bluetoothReadEntities.Add(bluetoothReadEntity);
                    }

                }
                tr.Commit();
                return bluetoothReadEntities;

            }
        }

        /// <summary>
        /// 往write表写入 传入实体类
        /// </summary>
        /// <param name="sql"></param>
        public static int InsertBluetoothWrite(BluetoothWriteEntity bluetoothWriteEntity)
        {
            // 确保连接打开
            Open(connection);
            int result = 0;
            using (var tr = connection.BeginTransaction())
            {
                using (var command = connection.CreateCommand())
                {
                    StringBuilder sql = new StringBuilder();

                    sql.Append("insert into bluetooth_write ( member_id,bluetooth_name,gmt_modified ,write_state) values ('");
                    sql.Append(bluetoothWriteEntity.Member_id);
                    sql.Append("','");
                    sql.Append(bluetoothWriteEntity.Bluetooth_name);
                    sql.Append("',");
                    sql.Append(bluetoothWriteEntity.Gmt_modified);
                    sql.Append(",");
                    sql.Append(bluetoothWriteEntity.Write_state);
                    sql.Append(")");

                    command.CommandText = sql.ToString();
                    result = command.ExecuteNonQuery();
                }
                tr.Commit();
            }
            return result;
        }



        /// <summary>
        /// 根据传入的用户id查询最新一条写入的记录
        /// </summary>
        public static BluetoothWriteEntity GetBluetoothWrite(string memberId)
        {
            // 确保连接打开
            Open(connection);
            //实例化实体类
            BluetoothWriteEntity bluetoothWriteEntity = new BluetoothWriteEntity();

            using (var tr = connection.BeginTransaction())
            {
                using (var command = connection.CreateCommand())
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("select * from bluetooth_write where member_id = ");
                    sql.Append(memberId);
                    sql.Append(" AND gmt_modified = (select MAX(gmt_modified) from bluetooth_write)");
                    command.CommandText = sql.ToString();

                    // 执行查询会返回一个SQLiteDataReader对象
                    var reader = command.ExecuteReader();

                    //reader.Read()方法会从读出一行匹配的数据到reader中。注意：是一行数据。
                    while (reader.Read())
                    {
                        //实例化一个读取实体类

                        // 有一系列的Get方法，方法的参数是列数。意思是获取第n列的数据，转成Type返回。
                        // 比如这里的语句，意思就是：获取第0列的数据，转成int值返回。
                        bluetoothWriteEntity.Id = reader.GetInt64(0);
                        bluetoothWriteEntity.Member_id = reader.GetString(1);
                        bluetoothWriteEntity.Write_state = reader.GetInt32(2);
                        bluetoothWriteEntity.Bluetooth_name = reader.GetString(3);
                        bluetoothWriteEntity.Gmt_modified = reader.GetInt64(4);
                    }

                }
                tr.Commit();
                return bluetoothWriteEntity;

            }
        }


        



    }
}
