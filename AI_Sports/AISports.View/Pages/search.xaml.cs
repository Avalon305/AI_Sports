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
        public search()
        {
            InitializeComponent();
            var member = new List<MemberVO>
            {
                new MemberVO{Image="/AI_Sports;component/AISports.View/Images/photo.png",Sex="男",Age=20,Zhuang="增肌",Time="2011.10.12"},
                new MemberVO{Image="/AI_Sports;component/AISports.View/Images/photo.png",Sex="男",Age=20,Zhuang="增肌，塑形",Time="2011.10.12"},
                new MemberVO{Image="/AI_Sports;component/AISports.View/Images/photo.png",Sex="男",Age=20,Zhuang="增肌，塑形，减脂",Time="2011.10.12"},
            };
            this.stackPanel.DataContext = member;
        }
    }
    public class MemberVO
    {
        public string Zhuang { get; set; }
        public string Image { set; get; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Time { get; set; }
    }
}
