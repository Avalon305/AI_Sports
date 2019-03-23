using AI_Sports.AISports.Entity;
using AI_Sports.AISports.Service;
using AI_Sports.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// Process.xaml 的交互逻辑
    /// </summary>
    public partial class Process : Page
    {
        public Process()
        {
            InitializeComponent();
      
            //获取 currentCourseCount
            string currentCourseCount = CommUtil.GetSettingString("currentCourseCount");

            Strength.ObjectForScripting = new WebStrength();
            StrengthEndurance.ObjectForScripting = new StrengthEndurance();
            Aerobic.ObjectForScripting = new WebAerobic();
            //获取项目的根路径
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string rootpath = path.Substring(0, path.LastIndexOf("bin"));
            Strength.Navigate(new Uri(rootpath + "AISports.Echarts/dist/StrengthStacked.html"));
            StrengthEndurance.Navigate(new Uri(rootpath + "AISports.Echarts/dist/StrengthEnduranceStacked.html"));
            Aerobic.Navigate(new Uri(rootpath + "AISports.Echarts/dist/AerobicStacked.html"));

        }
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisible(true)]//给予权限并设置可见
    public class WebStrength
    {
        ProcessService processService = new ProcessService();
        //获取 trainingCourseId
        string trainingCourseId = CommUtil.GetSettingString("trainingCourseId");

        //力量循环X轴动态数据加载(查询系统时间前24小时的创建时间)
        public string selectCreateTime()
        {
            List<DateTime> CreateTime = processService.selectCreateTime();
            DataContractJsonSerializer json = new DataContractJsonSerializer(CreateTime.GetType());
            string szJson = "";
            //序列化
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, CreateTime);
                szJson = Encoding.UTF8.GetString(stream.ToArray());

            }

            Console.WriteLine("时间串" + szJson);
            return szJson;
        }

        //力量循环平均值
        public String avgValue()
        {
            List<double> avgValue = processService.selectAvgValue(trainingCourseId);
            DataContractJsonSerializer json = new DataContractJsonSerializer(avgValue.GetType());
            string szJson = "";
            //序列化
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, avgValue);
                szJson = Encoding.UTF8.GetString(stream.ToArray());

            }

            Console.WriteLine("成功" + szJson.ToString());
            return szJson;
        }

        //返回值行数
        public int count()
        {
            int count = processService.selectCount();
            return count;
        }


    }


    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisible(true)]//给予权限并设置可见
    public class StrengthEndurance
    {

        ProcessService processService = new ProcessService();
        //获取 trainingCourseId
        string trainingCourseId = CommUtil.GetSettingString("trainingCourseId");
        //力量耐力循环(力量)X轴动态数据加载(查询系统时间前24小时的创建时间)
        public string selectStrengthCreateTime()
        {
            List<DateTime> CreateTime = processService.selectStrengthCreateTime();
            DataContractJsonSerializer json = new DataContractJsonSerializer(CreateTime.GetType());
            string szJson = "";
            //序列化
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, CreateTime);
                szJson = Encoding.UTF8.GetString(stream.ToArray());

            }

            Console.WriteLine("时间串" + szJson);
            return szJson;
        }

        //力量耐力循环(力量)平均值
        public String avgStrengthValue()
        {
            List<double> avgValue = processService.selectavgStrengthValue(trainingCourseId);
            DataContractJsonSerializer json = new DataContractJsonSerializer(avgValue.GetType());
            string szJson = "";
            //序列化
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, avgValue);
                szJson = Encoding.UTF8.GetString(stream.ToArray());

            }

            Console.WriteLine("成功" + szJson.ToString());
            return szJson;
        }


    }


    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisible(true)]//给予权限并设置可见
    public class WebAerobic
    {
        ProcessService processService = new ProcessService();
        //获取 trainingCourseId
        string trainingCourseId = CommUtil.GetSettingString("trainingCourseId");
        //力量耐力循环(有氧)X轴动态数据加载(查询系统时间前24小时的创建时间)
        public string selectAerobicCreateTime()
        {
            List<DateTime> CreateTime = processService.selectAerobicCreateTime();
            DataContractJsonSerializer json = new DataContractJsonSerializer(CreateTime.GetType());
            string szJson = "";
            //序列化
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, CreateTime);
                szJson = Encoding.UTF8.GetString(stream.ToArray());

            }

            Console.WriteLine("时间串" + szJson);
            return szJson;
        }

        //力量耐力循环(有氧)平均值
        public String avgAerobicValue()
        {
            List<double> avgValue = processService.selectavgAerobicValue(trainingCourseId);
            DataContractJsonSerializer json = new DataContractJsonSerializer(avgValue.GetType());
            string szJson = "";
            //序列化
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, avgValue);
                szJson = Encoding.UTF8.GetString(stream.ToArray());

            }

            Console.WriteLine("成功" + szJson.ToString());
            return szJson;
        }

    }


}
