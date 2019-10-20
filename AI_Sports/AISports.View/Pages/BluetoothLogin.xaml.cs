using AI_Sports.AISports.Dao;
using AI_Sports.AISports.Entity;
using AI_Sports.Constant;
using AI_Sports.Service;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using AI_Sports.Util;
using System.Windows.Threading;
using System.Text.RegularExpressions;

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// BluetoothWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BluetoothLogin : Window
    {
        private BluetoothReadDAO bluetoothReadDAO = new BluetoothReadDAO();

        private MemberService memberService = new MemberService();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //页面传参对象
        public delegate void PassValuesHandler(object sender);
        //传值事件
        public event PassValuesHandler PassValuesEvent;

        //声明定时任务 WPF与界面交互专用定时任务
        private static DispatcherTimer readDataTimer = new DispatcherTimer();
        

        public BluetoothLogin()
        {
            InitializeComponent();
            //加载手环列表
            LoadBluetoothList();
			TB_MemberId.Focus();
			//初始化注册定时器
			//readDataTimer.Tick += new EventHandler(timeCycle);
			////五秒一次查询，更新登陆列表
			//readDataTimer.Interval = new TimeSpan(0, 0, 0, 5);
			//readDataTimer.Start();



		}

        //定时任务调用方法 每五秒查询一次扫描手环表
        //private void timeCycle(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //生成修改时间时间戳
        //        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        //        var currentTime = Convert.ToInt64(ts.TotalSeconds);
        //        //当前时间减2分钟 查询最近2分钟被扫描到的手环
        //        currentTime = currentTime - (2 * 60);
        //        //查询最近读取表中扫描到的用户
        //        List<BluetoothReadEntity> bluetoothReadEntities = SQLiteUtil.ListCurrentLoginUser(currentTime.ToString());

        //        this.dataGrid.ItemsSource = bluetoothReadEntities;
        //        Console.WriteLine("查询扫描手环，更新登陆列表成功");
        //        foreach (var item in bluetoothReadEntities)
        //        {
        //            Console.WriteLine("更新的蓝牙：" + item.Member_id);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("蓝牙登陆查询read表异常" + ex.Message);
        //        logger.Warn("蓝牙登陆查询read表异常" + ex.Message);
        //    }
           
        //}

        /// <summary>
        /// 加载手环列表
        /// </summary>
        public void LoadBluetoothList()
        {
            //try
            //{
                //生成修改时间时间戳
            //    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            //    var currentTime = Convert.ToInt64(ts.TotalSeconds);
            //    //当前时间减2分钟 查询最近2分钟被扫描到的手环
            //    currentTime = currentTime - (2 * 60);

            //    List<BluetoothReadEntity> bluetoothReadEntities = SQLiteUtil.ListCurrentLoginUser(currentTime.ToString());

            //    this.dataGrid.ItemsSource = bluetoothReadEntities;
            //    Console.WriteLine("查询扫描手环，更新登陆列表成功");
            //    foreach (var item in bluetoothReadEntities)
            //    {
            //        Console.WriteLine("更新的蓝牙：" + item.Member_id);

            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("蓝牙登陆查询read表异常"+ex.Message);
            //    logger.Warn("蓝牙登陆查询read表异常"+ex.Message);
            //}
            

        }

        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 重新扫描按钮/登陆按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //输入用户ID登录
            string memberId = this.TB_MemberId.Text;

            if (memberId != null && memberId != "")
            {
                //传递卡号参数给mainwindow
                PassValuesEvent(memberId);
                Console.WriteLine("已经传递卡号给主窗体 id：" + memberId);
                this.Close();
            }

            //选择蓝牙登陆
            //LoadBluetoothList();
            //MessageBoxX messageBoxX = new MessageBoxX();
            //messageBoxX.ShowLoading("温馨提示","加载成功",1);
        }
        /// <summary>
        /// 选中某行登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //BluetoothReadEntity bluetoothReadEntity = this.dataGrid.SelectedItem as BluetoothReadEntity;

            //if (bluetoothReadEntity != null)
            //{
            //    if (bluetoothReadEntity.Member_id != null)
            //    {
            //        //传递卡号参数给mainwindow
            //        PassValuesEvent(bluetoothReadEntity.Member_id);
            //        Console.WriteLine("已经传递卡号给主窗体 id：" + bluetoothReadEntity.Member_id);
            //        this.Close();
            //    }
                

            //}


        }
        /// <summary>
        /// 点击某一行选择登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {



        }

		/// <summary>
		/// 刷手环登录，不需要点击登录按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TB_MemberId_TextChanged(object sender, TextChangedEventArgs e)
		{
			var reg = new Regex("[\u4e00-\u9fa5]");
			string memberId = TB_MemberId.Text;
            if (reg.IsMatch(memberId))
            {
                MessageBoxX.Show("提示", "请切换英文输入法");

            }
            if (memberId.Length == 16)
			{
				if (memberId != null && memberId != "")
				{
					//传递卡号参数给mainwindow
					PassValuesEvent(memberId);
					Console.WriteLine("已经传递卡号给主窗体 id：" + memberId);
                    this.Close();
				}
                //TB_MemberId.Clear();
            }
        }
    }
}
