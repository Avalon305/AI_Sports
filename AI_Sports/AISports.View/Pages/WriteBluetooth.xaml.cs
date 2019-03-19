using AI_Sports.AISports.Dao;
using AI_Sports.AISports.Entity;
using AI_Sports.Service;
using AI_Sports.Util;
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

        public WriteBluetooth()
        {
            InitializeComponent();

            //List<BluetoothReadEntity> bluetoothReadEntities = bluetoothReadDAO.ListCurrentLoginUser();
            List<BluetoothReadEntity> bluetoothReadEntities = SQLiteUtil.ListCurrentLoginUser();
            this.LB_BluetoothName.ItemsSource = bluetoothReadEntities;

            this.TB_Member_Id.Text = CommUtil.GetSettingString("memberId");

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
                    
                    //添加到集合
                    writeEntities.Add(writeEntity);

                }
            }
            
            //数组选中了一条就插入 然后轮询
            if (writeEntities.Count == 1)
            {
                BluetoothWriteEntity writeEntity = writeEntities[0];
                if (writeEntity.Member_id != null && writeEntity.Member_id != "")
                {
                    //long addResult = bluetoothWriteDAO.Insert(writeEntity);
                    SQLiteUtil.InsertBluetoothWrite(writeEntity);
                    Console.WriteLine("手环写入成功");
                    this.Lab_Tips.Foreground = Brushes.Green;

                    this.Lab_Tips.Content = "手环保存成功";
                }
                else
                {
                    this.Lab_Tips.Foreground = Brushes.OrangeRed;
                    this.Lab_Tips.Content = "用户ID不能为空 请重新添加用户";
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

    }
 
}

