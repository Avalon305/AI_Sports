using AI_Sports.AISports.Dao;
using AI_Sports.AISports.Entity;
using AI_Sports.Service;
using AI_Sports.Util;
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
using System.Windows.Threading;

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// WriteBluetooth.xaml 的交互逻辑
    /// </summary>
    public partial class WriteBluetooth : Window
    {
        private BluetoothReadDAO bluetoothReadDAO = new BluetoothReadDAO();
        private BluetoothWriteDAO bluetoothWriteDAO = new BluetoothWriteDAO();
        private MemberService memberService = new MemberService();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //声明定时任务 WPF与界面交互专用定时任务
        private static DispatcherTimer readDataTimer = new DispatcherTimer();

        public WriteBluetooth()
        {
            InitializeComponent();
            //加载手环列表
            LoadBluetoothList();
            //加载用户ID
            this.TB_Member_Id.Text = CommUtil.GetSettingString("memberId");

        }


        //定时任务调用方法 每2秒查询一次扫描手环写入表 并根据结果在页面提示
        private void timeCycle(object sender, EventArgs e)
        {
            Console.WriteLine("定时任务：查询写入数据状态");
            //根据当前会员ID获得最新的写入的数据
            BluetoothWriteEntity bluetoothWriteEntity = SQLiteUtil.GetBluetoothWrite(CommUtil.GetSettingString("memberId"));

            if (bluetoothWriteEntity != null)
            {
                //write_state字段的值代表的意义：0：待读取；1：写入成功；2：写入失败; 3：已读取数据。
                switch (bluetoothWriteEntity.Write_state)
                {
                    case 0:
                        Console.WriteLine("数据待读取");
                        logger.Debug("数据待读取");
                        this.Lab_Tips.Foreground = Brushes.DarkOrange;

                        this.Lab_Tips.Content = "正在扫描手环，请稍等......";
                        break;
                    case 1:
                        Console.WriteLine("写入手环成功");
                        logger.Debug("写入手环成功");

                        this.Lab_Tips.Foreground = Brushes.Green;

                        this.Lab_Tips.Content = "手环保存成功";
                        break;
                    case 2:
                        Console.WriteLine("写入手环失败");
                        logger.Debug("写入手环失败");

                        this.Lab_Tips.Foreground = Brushes.OrangeRed;

                        this.Lab_Tips.Content = "手环保存失败";
                        break;
                    case 3:
                        Console.WriteLine("UWP已经读取待写入数据");
                        logger.Debug("UWP已经读取待写入数据");

                        this.Lab_Tips.Foreground = Brushes.Orange;

                        this.Lab_Tips.Content = "正在保存手环，请稍等......";
                        break;
                    default:
                        break;
                }
            }
           

        }
        /// <summary>
        /// 加载手环列表
        /// </summary>
        public void LoadBluetoothList()
        {
            //生成修改时间时间戳
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var currentTime = Convert.ToInt64(ts.TotalSeconds);
            //当前时间减2分钟 查询最近2分钟被扫描到的手环
            currentTime = currentTime - (2 * 60);

            List<BluetoothReadEntity> bluetoothReadEntities = SQLiteUtil.ListCurrentLoginUser(currentTime.ToString());

            this.LB_BluetoothName.ItemsSource = bluetoothReadEntities;

        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<BluetoothWriteEntity> writeEntities = new List<BluetoothWriteEntity>();

            for (int i = 0; i < this.LB_BluetoothName.Items.Count; i++)
            {
                ListBoxItem item = this.LB_BluetoothName.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem;
                //调用方法通过VisualTreeHelper去找到TextBlock|Checkbox控件
                if (item != null)
                {
                    CheckBox chkBox = FindFirstElementInVisualTree<CheckBox>(item);

                    //如果是被选中的就添加
                    if (chkBox.IsChecked == true)
                    {
                        //MessageBox.Show(chkBox.Content.ToString());
                        BluetoothWriteEntity writeEntity = new BluetoothWriteEntity();
                        writeEntity.Member_id = TB_Member_Id.Text;
                        writeEntity.Write_state = 0;
                        //writeEntity.Gmt_create = System.DateTime.Now;
                        writeEntity.Bluetooth_name = chkBox.Content.ToString();
                        //生成修改时间时间戳
                        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                        writeEntity.Gmt_modified = Convert.ToInt64(ts.TotalSeconds);

                        //添加到写入集合
                        writeEntities.Add(writeEntity);

                    }
                }
                
            }
            
            //数组选中了一条就插入 然后轮询
            if (writeEntities.Count == 1)
            {
                BluetoothWriteEntity writeEntity = writeEntities[0];
                if (writeEntity.Member_id != null && writeEntity.Member_id != "")
                {
                    //插入SQLite write表
                    //long addResult = bluetoothWriteDAO.Insert(writeEntity);
                    int result = SQLiteUtil.InsertBluetoothWrite(writeEntity);
                    if (result > 0)
                    {
                        Console.WriteLine("手环数据插入write表成功");

                    }


                    //然后执行定时任务开始查询写入状态
                    //初始化注册定时器
                    //readDataTimer.Tick += new EventHandler(timeCycle);
                    ////2秒一次查询，更新登陆列表
                    //readDataTimer.Interval = new TimeSpan(0, 0, 0, 5);
                    //readDataTimer.Start();

                }
                else
                {
                    this.Lab_Tips.Foreground = Brushes.OrangeRed;
                    this.Lab_Tips.Content = "用户ID 请重新添加用户";
                }
            }
            else
            {
                this.Lab_Tips.Foreground = Brushes.OrangeRed;
                this.Lab_Tips.Content = "请选择一个手环";

                Console.WriteLine("请选择一个手环");
            }




        }
        //从头开始遍历容器

        private T FindFirstElementInVisualTree<T>(DependencyObject parentElement) where T : DependencyObject
        {
            var count = VisualTreeHelper.GetChildrenCount(parentElement);
            if (count == 0)
                return null;
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parentElement, i);
                if (child != null && child is T)
                {
                    return (T)child;
                }
                else
                {
                    var result = FindFirstElementInVisualTree<T>(child);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }
        /// <summary>
        /// 重新扫描按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LoadBluetoothList();
        }
    }
 
}

