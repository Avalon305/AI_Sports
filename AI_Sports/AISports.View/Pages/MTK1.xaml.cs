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
using System.Collections.ObjectModel;
using System.Windows.Threading;

using System.Threading;


namespace AI_Sports
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>


    public partial class Window1 : Window
    {



        //需要定义成静态变量，因为这个数据在MemberInfo.xaml.cs中使用
        //
        public static Customer customer = new Customer()
        {
            ID = "123456",
            type = "1",
            zhuang = "success"
        };


        //这里定义一个权限比较大的ObservableCollection，因为下面的按钮事件需要得到这个的值
        ObservableCollection<Customer> memberData = new ObservableCollection<Customer>();


        public Window1()
        {
            
            InitializeComponent();



            //将类添加到memberData里面
            memberData.Add(customer);

            //将数据给前端显示
            dataGrid.DataContext = memberData;




        }


        //刷卡成功后，点击确定按钮标志位 false是未点击确定按钮，true是点击确定按钮后
        public static bool success_Flag = false;

        //取消按钮
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();


        }

        

      
        
        //确定按钮
        void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            success_Flag = true;

            //memberData只有一个元素所以是发送memberData第一个类的ID值给MemberInfo页面
            String ID = (String)memberData[0].ID;


            this.Close();






        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    public class Customer
    {
        public string ID { get; set; }
        public string type { get; set; }
        public string zhuang { get; set; }
    }

}
