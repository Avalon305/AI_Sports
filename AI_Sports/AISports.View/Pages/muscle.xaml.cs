using AI_Sports.AISports.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
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

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// muscle.xaml 的交互逻辑
    /// </summary>
    public partial class muscle : Page
    {
        public muscle()
        {
            InitializeComponent();
            Web.ObjectForScripting = new WebPie();
            Endurance.ObjectForScripting = new WebEndurancePie();
            //获取项目的根路径
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string rootpath = path.Substring(0, path.LastIndexOf("bin"));

            Endurance.Navigate(new Uri(rootpath + "AISports.Echarts/dist/EndurancePie.html"));
            Web.Navigate(new Uri(rootpath + "AISports.Echarts/dist/Pie.html"));

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {


        }
    }


    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisible(true)]//给予权限并设置可见
    public class WebPie
    {
        public String Show()
        {
            return "60";
        }
        MusclePieChartService musclePieChartService = new MusclePieChartService();
        //力量循环腹部训练个数
        public int abdomenTraining()
        {
            Console.WriteLine("成功:" + musclePieChartService.selectAbdomenTraining());
            return musclePieChartService.selectAbdomenTraining();
        }

        //力量循环胸部训练个数
        public int chestTraining()
        {
            return musclePieChartService.selectchestTraining();
        }

        //力量循环腿部训练个数
        public int legTraining()
        {
            return musclePieChartService.selectLegTraining();
        }

        //力量循环手臂训练个数
        public int armTraining()
        {
            return musclePieChartService.selectArmTraining();
        }

        //力量循环躯干训练个数
        public int trunkTraining()
        {
            return musclePieChartService.selectTrunkTraining();
        }




    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisible(true)]//给予权限并设置可见
    public class WebEndurancePie
    {
        public String Show()
        {
            return "60";
        }
        MusclePieChartService musclePieChartService = new MusclePieChartService();

        //力量耐力循环胸部训练个数
        public int chestEnduranceTraining()
        {
            return musclePieChartService.selectchestEnduranceTraining();
        }

        //力量耐力循环腿部训练个数
        public int legEnduranceTraining()
        {
            return musclePieChartService.selectLegEnduranceTraining();
        }

        //力量耐力循环手臂训练个数
        public int armEnduranceTraining()
        {
            return musclePieChartService.selectEnduranceArmTraining();
        }

        //力量耐力循环躯干训练个数
        public int trunkEnduranceTraining()
        {
            return musclePieChartService.selectTrunkEnduranceTraining();
        }
    }


}
