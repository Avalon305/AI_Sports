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

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// BluetoothWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BluetoothWindow : Window
    {
        private BluetoothReadDAO bluetoothReadDAO = new BluetoothReadDAO();

        private MemberService memberService = new MemberService();
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //页面传参对象
        public delegate void PassValuesHandler(object sender);
        //传值事件
        public event PassValuesHandler PassValuesEvent;

        public BluetoothWindow()
        {
            InitializeComponent();

            //List<BluetoothReadEntity> bluetoothReadEntities = bluetoothReadDAO.ListCurrentLoginUser();
            List<BluetoothReadEntity> bluetoothReadEntities = SQLiteUtil.ListCurrentLoginUser();


            this.dataGrid.ItemsSource = bluetoothReadEntities;
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        /// <summary>
        /// 选中某行登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            BluetoothReadEntity bluetoothReadEntity = this.dataGrid.SelectedItem as BluetoothReadEntity;

            if (bluetoothReadEntity.Member_id != null && bluetoothReadEntity.Member_id != "")
            {
                //传递卡号参数给mainwindow
                PassValuesEvent(bluetoothReadEntity.Member_id);
                Console.WriteLine("已经传递卡号给主窗体 id："+ bluetoothReadEntity.Member_id);
                this.Close();

            }


        }
        /// <summary>
        /// 点击某一行选择登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {


           
        }
    }
}
