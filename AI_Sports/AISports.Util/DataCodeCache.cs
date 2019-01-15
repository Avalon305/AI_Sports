
using AI_Sports.Constant;
using AI_Sports.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.Dao
{
    /// <summary>
    /// 数据编码缓存工具类
    /// </summary>
    class DataCodeCache
    {
        private static DataCodeCache instance = new DataCodeCache();
        //键是SValue的缓存
        private static Dictionary<string, Dictionary<string, string>> codeMapSValue = new Dictionary<string, Dictionary<string, string>>();
        //键是DValue的缓存
        private static Dictionary<string, Dictionary<string, string>> codeMapDValue = new Dictionary<string, Dictionary<string, string>>();

 
        private DatacodeDAO codeDAO = new DatacodeDAO();
        private DataCodeCache()
        {

        }
        public static DataCodeCache GetInstance()
        {
            return instance;
        }
        /// <summary>
        /// 根据typeID返回列表，可直接绑定到下拉框
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public List<DatacodeEntity> GetDateCodeList(DatacodeTypeEnum typeId)
        {
           return codeDAO.ListByTypeId(typeId.ToString());
        }
        /// <summary>
        /// 返回"SValue","DValue"
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        private Dictionary<string, string> LoadCodeMap(DatacodeTypeEnum typeId)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            List<DatacodeEntity> dataCodes = codeDAO.ListByTypeId(typeId.ToString());
            foreach (var d in dataCodes)
            {
                result.Add(d.Code_s_value, d.Code_d_value);
            }
            return result;
        }
        /// <summary>
        /// 返回"DValue","SValue"
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        private Dictionary<string, string> LoadDValueCodeMap(DatacodeTypeEnum typeId)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            List<DatacodeEntity> dataCodes = codeDAO.ListByTypeId(typeId.ToString());
            foreach (var d in dataCodes)
            {
                result.Add(d.Code_d_value, d.Code_s_value);
            }
            return result;
        }
        /// <summary>
        /// 根据显示值获取存储值，用到了缓存
        /// </summary>
        /// <param name="typeId">大类名称</param>
        /// <param name="key">键</param>
        /// <returns>空字符串或者值</returns>
        public string GetCodeSValue(DatacodeTypeEnum typeId, string key)
        {
            string result = null;
            Dictionary<string, string> codeMap = null;
            codeMapDValue.TryGetValue(typeId.ToString(), out codeMap);
            if (codeMap == null)
            {
                codeMap = LoadDValueCodeMap(typeId);
                if (codeMap != null)
                {
                    codeMapDValue.Add(typeId.ToString(), codeMap);
                    codeMap.TryGetValue(key,out result);
                }
            }
            else
            {
                codeMap.TryGetValue(key, out result);
            }
            if (result == null)
            {
                result = "";
            }
            return result;
        }
        /// <summary>
        /// 获取显示值，用到了缓存
        /// </summary>
        /// <param name="typeId">大类名称</param>
        /// <param name="key">键</param>
        /// <returns>空字符串或者值</returns>
        public string GetCodeDValue(DatacodeTypeEnum typeId, string key)
        {
            string result = null;

            Dictionary<string, string> codeMap = null;
            codeMapSValue.TryGetValue(typeId.ToString(), out codeMap);
            if (codeMap == null)
            {
                codeMap = LoadCodeMap(typeId);
                if (codeMap != null)
                {
                    codeMapSValue.Add(typeId.ToString(), codeMap);
                    codeMap.TryGetValue(key, out result);
                }
            }
            else
            {
                codeMap.TryGetValue(key, out result);
            }
            if (result == null)
            {
                result = "";
            }
            return result;
        }
        /// <summary>
        /// 用于切换语言后清空缓存
        /// </summary>
        public void ClearCache()
        {
            codeMapSValue.Clear();
            codeMapDValue.Clear();
        }

    }
}
