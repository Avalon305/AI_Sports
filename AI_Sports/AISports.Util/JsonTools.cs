using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Util
{
    //使用Newtonsoft.Json.Linq需要在nuget中安装dll，命令为Install-Package Newtonsoft.Json  
    //json转化工具类
    public static class JsonTools
    {
        //Dictionary转化为json对象的工具类
        public static string DictionaryToJSONStr(Dictionary<String, String> param)
        {
            string jsonstring = "";
            JObject json = new JObject();
            if (param.Count != 0) //将参数添加到json对象中
            {
                foreach (var item in param)
                {
                    json.Add(item.Key, item.Value);
                }
            }
            jsonstring = json.ToString();//获得参数的json字符串
            return jsonstring;
        }
        //对象转化为Dictionary
        public static Dictionary<String, String> ObjToDictionary<T>(T obj)
        {
            Dictionary<String, String> param = new Dictionary<string, string>();
            //FieldInfo[] fieldInfos = obj.GetType().GetFields();
            //foreach (FieldInfo fieldInfo in fieldInfos ) {
            //获得属性的值
            //string propertyname = fieldInfo.Name.ToString();
            //Type type = typeof(T);
            //PropertyInfo property = type.GetProperty(propertyname);
            //string propertyValue = (string)property.GetValue(obj);

            //}
            Type type = typeof(T);
            foreach (PropertyInfo pi in type.GetProperties())
            {
                string propertyValue = pi.GetValue(obj, null).ToString();//用pi.GetValue获得值
                string propertyname = pi.Name;//获得属性的名字,后面就可以根据名字判断来进行些自己想要的操作
                param.Add(propertyname, propertyValue);
            }


            return param;



        }
        //obj转化为string of json
        private static string Obj2JSONStr<T>(T obj)
        {
            return DictionaryToJSONStr(ObjToDictionary<T>(obj));
        }
        //list<obj>转化为string of json
        private static string List2JSONStr<T>(List<T> list)
        {
            StringBuilder stringBuilder = new StringBuilder("[");
            //第一次为0  之后不为0
            int flag = 0;
            foreach (var obj in list)
            {
                if (flag != 0)
                {
                    stringBuilder.AppendLine(",");
                }
                flag++;
                stringBuilder.AppendLine(DictionaryToJSONStr(ObjToDictionary<T>(obj)));
            }
            stringBuilder.AppendLine("]");
            return stringBuilder.ToString().Trim(' ');
        }
        /// <summary>
        /// obj转化为string of json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>

        public static string Obj2JSONStrNew<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
        }
        //list<obj>转化为string of json
        public static string List2JSONStrNew<T>(List<T> list)
        {
            return JsonConvert.SerializeObject(list);
        }
        /// <summary>
        /// 解析JSON字符串生成对象实体
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串(eg.{"ID":"112","Name":"石子儿"})</param>
        /// <returns>对象实体</returns>
        public static T DeserializeJsonToObject<T>(string json) where T : class
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                StringReader sr = new StringReader(json);
                object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
                T t = o as T;
                return t;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
    }
}
