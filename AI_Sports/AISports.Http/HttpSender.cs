using AI_Sports.AISports.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AI_Sports.AISports.Http
{
    //负责发送http请求的发送者对象
    public class HttpSender
    {
        //前缀http://192.168.1.112:8080
        public static readonly string URLBASE = "http://192.168.1.112:8080/bigDataRecivedHandler/";
        //public static readonly string URLBASE = "http://172.20.10.5:8080/cloud/";
        public static readonly string URL_UPDATE = "http://49.4.67.157:8080/bdl_update/AutoUpdate";

        //私有化空构造
        private HttpSender()
        {
        }
        /*
        /// <summary>
        /// 测试网络是否通畅
        /// </summary>
        private static bool Ping()
        {
            string pingResult = POSTByJsonStr("communicationController/analysisJson",
            JsonTools.Obj2JSONStrNew(new HttpHeartBeat("ping")));

            HttpHeartBeat httpHeartBeat = JsonTools.DeserializeJsonToObject<HttpHeartBeat>(pingResult);
            if (httpHeartBeat != null && httpHeartBeat.username.Equals("pong"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */

        //post方式，参数为json串
        public static string POSTByJsonStr(string url, string jsonStr)
        {
            try
            {
                Console.WriteLine("====================================发数据啦" + jsonStr);
                HttpWebRequest request = WebRequest.Create(URLBASE + url) as HttpWebRequest; //创建请求
                CookieContainer cookieContainer = new CookieContainer();
                request.Timeout = 10 * 1000; //10s超时
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                //request.AllowReadStreamBuffering = true;
                request.MaximumResponseHeadersLength = 1024;
                request.Method = "POST"; //请求方式为post
                request.AllowAutoRedirect = true;
                request.MaximumResponseHeadersLength = 1024;
                request.ContentType = "application/json";

                // string jsonstring = json.ToString();//获得参数的json字符串
                byte[] jsonbyte = Encoding.UTF8.GetBytes(jsonStr);
                Stream postStream = request.GetRequestStream();
                postStream.Write(jsonbyte, 0, jsonbyte.Length);
                postStream.Close();
                //发送请求并获取相应回应数据       
                HttpWebResponse res;
                try
                {
                    //获取回应
                    res = (HttpWebResponse)request.GetResponse();
                }
                catch (WebException ex)
                {
                    res = (HttpWebResponse)ex.Response;
                }
                //返回的数据流
                StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
                string content = sr.ReadToEnd(); //获得响应字符串
                Console.WriteLine("====================================response:" + content);
                return content;
            }
            catch (WebException we)
            {
                return "";
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
                return "";
            }


        }


        //url为请求的网址，param参数为需要查询的条件（服务端接收的参数，没有则为null）
        //返回该次请求的响应
        public static string GET(string url, Dictionary<String, String> param)
        {
            if (param != null) //有参数的情况下，拼接url
            {
                url = url + "?";
                foreach (var item in param)
                {
                    url = url + item.Key + "=" + item.Value + "&";
                }

                url = url.Substring(0, url.Length - 1);
            }

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest; //创建请求
            request.Method = "GET"; //请求方法为GET
            HttpWebResponse res; //定义返回的response
            try
            {
                res = (HttpWebResponse)request.GetResponse(); //此处发送了请求并获得响应
            }
            catch (WebException ex)
            {
                res = (HttpWebResponse)ex.Response;
                Console.WriteLine(ex.ToString());
            }
            if (res == null)
            {
                return "";
            }
            StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
            string content = sr.ReadToEnd(); //响应转化为String字符串
            return content;
        }


        //url为请求的网址，param为需要传递的参数
        //返回服务端的响应
        public static string POST(string url, Dictionary<String, String> param)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest; //创建请求
            CookieContainer cookieContainer = new CookieContainer();
            request.CookieContainer = cookieContainer;
            request.Timeout = 10 * 1000; //10s超时
            request.AllowAutoRedirect = true;
            //request.AllowReadStreamBuffering = true;
            request.MaximumResponseHeadersLength = 1024;
            request.Method = "POST"; //请求方式为post
            request.AllowAutoRedirect = true;
            request.MaximumResponseHeadersLength = 1024;
            request.ContentType = "application/json";
            JObject json = new JObject();
            if (param.Count != 0) //将参数添加到json对象中
            {
                foreach (var item in param)
                {
                    json.Add(item.Key, item.Value);
                }
            }

            string jsonstring = json.ToString(); //获得参数的json字符串
            byte[] jsonbyte = Encoding.UTF8.GetBytes(jsonstring);
            Stream postStream = request.GetRequestStream();
            postStream.Write(jsonbyte, 0, jsonbyte.Length);
            postStream.Close();
            //发送请求并获取相应回应数据       
            HttpWebResponse res;
            try
            {
                res = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                res = (HttpWebResponse)ex.Response;
            }
            if (res == null)
            {
                return "";
            }
            StreamReader sr = new StreamReader(res.GetResponseStream(), Encoding.UTF8);
            string content = sr.ReadToEnd(); //获得响应字符串
            return content;
        }
    }
}
