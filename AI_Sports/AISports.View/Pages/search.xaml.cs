using AI_Sports.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// search.xaml 的交互逻辑
    /// </summary>
    public partial class search : Page
    {

        //创建service
        private MemberService memberService = new MemberService();
        public search()
        {
            InitializeComponent();


            MemberEntity memberEntity = new MemberEntity();
            List<MemberEntity> membersList = new List<MemberEntity>();
            Dictionary<MemberEntity, MemberEntity> myDictionary = new Dictionary<MemberEntity, MemberEntity>();
            //数据库中查阅的信息赋给membersList
            membersList = memberService.ListAllMember();
            //按照登录时间降序排列
            var members =membersList.OrderByDescending(i => i.Last_login_date);
            
            //把数据展示在前端
            this.stackPanel.DataContext = members;
           
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //这两个是给函数传参
            String first_Name;
            String phone_Number;

            
            //按照不同情况给变量给值
            if (name.Text != "会员名")
            {
                first_Name = name.Text;
            }
            else
                first_Name = null;
            if (phone.Text != "手机号")
            {
                phone_Number = phone.Text;
            }
            else
                phone_Number = null;
            

            MemberEntity memberEntity = new MemberEntity();
            List<MemberEntity> membersList = new List<MemberEntity>();
            Dictionary<MemberEntity, MemberEntity> myDictionary = new Dictionary<MemberEntity, MemberEntity>();
            membersList = memberService.ListNameMember(first_Name,phone_Number);

            var members = membersList.OrderByDescending(i => i.Last_login_date);
          
            this.stackPanel.DataContext = members;
            
            
        }

        private void StackPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
 
  
}
