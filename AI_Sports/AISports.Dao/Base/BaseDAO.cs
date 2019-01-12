using AI_Sports.Util;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace AI_Sports.Dao
{
    public class BaseDAO<T> where T : class
    {
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public List<T> ListAll()
        {
        
            using (var conn = DbUtil.getConn())
            {
                conn.Open();
                var r = conn.GetAll<T>();
                return r == null ? new List<T>() : r.ToList();
            }
        }

        /// <summary>
        /// 根据主键载入
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        public T Load(Object primaryKey)
        {
            using (var conn = DbUtil.getConn())
            {
                Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
                conn.Open();

                var result = conn.Get<T>(primaryKey);
                return result;
            }

        }

        /// <summary>
        /// 插入单条 
        /// </summary>
        /// <param name="t"></param>
        /// <returns>主键</returns>
        public long Insert(T t)
        {
            using (var conn = DbUtil.getConn())
            {
                conn.Open();

                var result = conn.Insert<T>(t);
                return result;
            }
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="list"></param>
        /// <returns>插入的数量</returns>
        public long BatchInsert(List<T> list)
        {
            using (var conn = DbUtil.getConn())
            {
                conn.Open();

                var result = conn.Insert(list);
                    return result;
            }
        }

        /// <summary>
        /// 根据主键更新
        /// </summary>
        /// <param name="t"></param>
        /// <returns>true,false成功失败</returns>
        public Boolean UpdateByPrimaryKey(T t)
        {
            using (var conn = DbUtil.getConn())
            {
                conn.Open();
                var result = conn.Update<T>(t);
                return result;
            }
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns>true,false成功失败</returns>
        public Boolean DeleteByPrimaryKey(T t)
        {
            using (var conn = DbUtil.getConn())
            {
                conn.Open();

                var result = conn.Delete<T>(t);
                return result;
            }
        }

        /// <summary>
        /// 删除所有
        /// </summary>
        /// <returns>true,false成功失败</returns>
        public Boolean DeleteAll()
        {
            using (var conn = DbUtil.getConn())
            {
                conn.Open();

                var result = conn.DeleteAll<T>();
                return result;
            }
        }
    }
}
