
using System.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SQLite.Net;
using SQLite.Net.Attributes;
using SQLite.Net.Platform.WinRT;
using SQLite.Net.Interop;
using static System.Diagnostics.Debug;
using Windows.Storage;
using TestEntity;
using System.IO;
using BluetoothEntity;

namespace SDKTemplate
{
     class SQLiteUtil
    {

        //public static string dbname = "bdl_bluetooth.db";
        //static string fdlocal = "E:\\usr";
        //static string localFolder = "E:\\usr";
        static string localFolder = ApplicationData.Current.LocalFolder.Path;
        static string dbname = "bdl_bluetooth.db";
        private static string dbFullPath = Path.Combine(localFolder, dbname);
        //string dbFullPath = Path.Combine(localFolder, dbname);

        //private static SQLiteConnection connection = CreateDatabaseConnection("bdl_bluetooth.db");
       
        public  static void InitializeDatabase()
        {
            // 建立连接
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), dbFullPath))
            {

                WriteLine("db pathe: " + conn.DatabasePath);

                // 创建表
                int rn = conn.CreateTable<BluetoothReadEntity>(CreateFlags.None);
                rn = conn.CreateTable<BluetoothWriteEntity>(CreateFlags.None);
                WriteLine("create table res = {0}", rn);

                conn.Dispose();

            };
        }

        //批量插入数据
        public static void BatchInsertRead(List<BluetoothReadEntity> bluetoothReadEntities)
        {
            // 建立连接
            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), dbFullPath))
            {
               
                //BluetoothReadEntity[] stus =
                //{
                //    new BluetoothReadEntity{ Member_id = "UWPTest",Gmt_modified = 321231 }
                //};
                int n = conn.InsertAll(bluetoothReadEntities);
                WriteLine($"已插入 {n} 条数据。");

            };

        }


        //读取写入表数据 写入状态为0的
        public static List<BluetoothWriteEntity> OnReadWrite()
        {
            //string localFolderPath = ApplicationData.Current.LocalFolder.Path;
            List<BluetoothWriteEntity> bluetoothWriteEntities = new List<BluetoothWriteEntity>();

            using (SQLiteConnection conn = new SQLiteConnection(new SQLitePlatformWinRT(), dbFullPath))
            {
                // 获取列表
                TableQuery<BluetoothWriteEntity> t = conn.Table<BluetoothWriteEntity>();

                bluetoothWriteEntities = (from s in t.AsParallel<BluetoothWriteEntity>()
                                          where (s.Write_state == 0)
                                          orderby s.Gmt_modified descending
                                          select s).ToList();

                //bluetoothWriteEntities = (from s in conn.Table<BluetoothWriteEntity>()
                //                          where (s.Write_state == 0)
                //                          select s).ToList();


            }

            return bluetoothWriteEntities;
        }
    }

    






    //// 数据库文件夹
    ////static string DbPath = Path.Combine(YatesHelper.GetAppDefaultPath(), "Database");
    //static string DbPath = "E:\\usr";
    ////与指定的数据库(实际上就是一个文件)建立连接
    //private static SQLiteConnection CreateDatabaseConnection(string dbName = null)
    //{
    //    if (!string.IsNullOrEmpty(DbPath) && !Directory.Exists(DbPath))
    //        Directory.CreateDirectory(DbPath);
    //    dbName = dbName == null ? "database.db" : dbName;
    //    var dbFilePath = Path.Combine(DbPath, dbName);
    //    return new SQLiteConnection("DataSource = " + dbFilePath);
    //}

    //// 使用全局静态变量保存连接
    //private static SQLiteConnection connection = CreateDatabaseConnection("bdl_bluetooth.db");

    //// 判断连接是否处于打开状态
    //private static void Open(SQLiteConnection connection)
    //{
    //    if (connection.State != System.Data.ConnectionState.Open)
    //    {
    //        connection.Open();
    //    }
    //}


    ///// <summary>
    ///// 增删改
    ///// </summary>
    ///// <param name="sql"></param>
    //public static void ExecuteNonQuery(string sql)
    //{
    //    // 确保连接打开
    //    Open(connection);

    //    using (var tr = connection.BeginTransaction())
    //    {
    //        using (var command = connection.CreateCommand())
    //        {
    //            command.CommandText = sql;
    //            command.ExecuteNonQuery();
    //        }
    //        tr.Commit();
    //    }
    //}

    ///// <summary>
    ///// 查询
    ///// </summary>
    ///// <param name="sql"></param>
    //public static void ExecuteQuery(string sql)
    //{
    //    // 确保连接打开
    //    Open(connection);

    //    using (var tr = connection.BeginTransaction())
    //    {
    //        using (var command = connection.CreateCommand())
    //        {
    //            command.CommandText = sql;

    //            // 执行查询会返回一个SQLiteDataReader对象
    //            var reader = command.ExecuteReader();

    //            //reader.Read()方法会从读出一行匹配的数据到reader中。注意：是一行数据。
    //            while (reader.Read())
    //            {
    //                // 有一系列的Get方法，方法的参数是列数。意思是获取第n列的数据，转成Type返回。
    //                // 比如这里的语句，意思就是：获取第0列的数据，转成int值返回。
    //                var time = reader.GetInt64(0);
    //            }
    //        }

    //        tr.Commit();
    //    }
    //}

    ///// <summary>
    ///// 查询最近登录的用户
    ///// </summary>
    //public static List<BluetoothReadEntity> ListCurrentLoginUser()
    //{
    //    // 确保连接打开
    //    Open(connection);
    //    //实例化实体类集合
    //    List<BluetoothReadEntity> bluetoothReadEntities = new List<BluetoothReadEntity>();
    //    using (var tr = connection.BeginTransaction())
    //    {
    //        using (var command = connection.CreateCommand())
    //        {
    //            string sql = "select * from bluetooth_read";
    //            command.CommandText = sql;

    //            // 执行查询会返回一个SQLiteDataReader对象
    //            var reader = command.ExecuteReader();

    //            //reader.Read()方法会从读出一行匹配的数据到reader中。注意：是一行数据。
    //            while (reader.Read())
    //            {
    //                //实例化一个读取实体类
    //                BluetoothReadEntity bluetoothReadEntity = new BluetoothReadEntity();

    //                // 有一系列的Get方法，方法的参数是列数。意思是获取第n列的数据，转成Type返回。
    //                // 比如这里的语句，意思就是：获取第0列的数据，转成int值返回。
    //                bluetoothReadEntity.Id = reader.GetInt64(0);
    //                bluetoothReadEntity.Member_id = reader.GetString(1);
    //                bluetoothReadEntity.Scan_count = reader.GetInt32(2);
    //                bluetoothReadEntity.Gmt_modified = reader.GetInt64(3);
    //                //添加到集合
    //                bluetoothReadEntities.Add(bluetoothReadEntity);
    //            }

    //        }
    //        tr.Commit();
    //        return bluetoothReadEntities;

    //    }
    //}

    ///// <summary>
    ///// 往write表写入 传入实体类
    ///// </summary>
    ///// <param name="sql"></param>
    //public static void InsertBluetoothWrite(BluetoothWriteEntity bluetoothWriteEntity)
    //{
    //    // 确保连接打开
    //    Open(connection);

    //    using (var tr = connection.BeginTransaction())
    //    {
    //        using (var command = connection.CreateCommand())
    //        {
    //            StringBuilder sql = new StringBuilder();

    //            sql.Append("insert into bluetooth_write ( member_id,bluetooth_name,gmt_modified ) values (");
    //            sql.Append(bluetoothWriteEntity.Member_id);
    //            sql.Append(",");
    //            sql.Append(bluetoothWriteEntity.Bluetooth_name);
    //            sql.Append(",");
    //            sql.Append(bluetoothWriteEntity.Gmt_modified);
    //            sql.Append(")");

    //            command.CommandText = sql.ToString();
    //            command.ExecuteNonQuery();
    //        }
    //        tr.Commit();
    //    }
    //}


    ///// <summary>
    ///// 查询最近登录的用户
    ///// </summary>
    //public static BluetoothWriteEntity GetBluetoothWrite(string memberId)
    //{
    //    // 确保连接打开
    //    Open(connection);
    //    //实例化实体类
    //    BluetoothWriteEntity bluetoothReadEntity = new BluetoothWriteEntity();

    //    using (var tr = connection.BeginTransaction())
    //    {
    //        using (var command = connection.CreateCommand())
    //        {
    //            StringBuilder sql = new StringBuilder();
    //            sql.Append("select * from bluetooth_write where member_id = ");
    //            sql.Append(memberId);
    //            command.CommandText = sql.ToString();

    //            // 执行查询会返回一个SQLiteDataReader对象
    //            var reader = command.ExecuteReader();

    //            //reader.Read()方法会从读出一行匹配的数据到reader中。注意：是一行数据。
    //            while (reader.Read())
    //            {
    //                //实例化一个读取实体类

    //                // 有一系列的Get方法，方法的参数是列数。意思是获取第n列的数据，转成Type返回。
    //                // 比如这里的语句，意思就是：获取第0列的数据，转成int值返回。
    //                bluetoothReadEntity.Id = reader.GetInt64(0);
    //                bluetoothReadEntity.Member_id = reader.GetString(1);
    //                bluetoothReadEntity.Write_state = reader.GetInt32(2);
    //                bluetoothReadEntity.Bluetooth_name = reader.GetString(3);
    //                bluetoothReadEntity.Gmt_modified = reader.GetInt64(4);
    //            }

    //        }
    //        tr.Commit();
    //        return bluetoothReadEntity;

    //    }
    //}





}
    

