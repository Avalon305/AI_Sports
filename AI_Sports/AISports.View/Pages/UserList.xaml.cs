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
    /// UserList.xaml 的交互逻辑
    /// </summary>
    public partial class UserList : Page
    {
        public UserList()
        {
            InitializeComponent();
            var students0 = new List<Stu>
        {   new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三feng", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三2222", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
             new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
             new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
         };
            var students1 = new List<Stu>
                 {
         new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
             new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
             new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张" ,Time ="2011.10.12"},
            new Stu{Image="/AI_Sports;component/AISports.View/Images/defaultphoto.png",Age=20,Member_familyName="三", Member_firstName="张", Time ="2011.10.12"},
         };
            this.stackPanel0.DataContext = students0;
            this.stackPanel1.DataContext = students1;
        }
    }
    public class Stu
    {

        ///登陆时间
       public string Time { set; get; }

        /// <summary>
        /// 图片 头像
        /// </summary>
        public string Image { set; get; }
    
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 会员id
        /// </summary>
        public String Member_id { get; set; }

        /// <summary>
        /// 会员名 ！
        /// </summary>
        public String Member_firstName { get; set; }

        /// <summary>
        /// 会员姓
        /// </summary>
        public String Member_familyName { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birth_date { get; set; }

        /// <summary>
        /// 0：女士；1：先生
        /// </summary>
        public int? Sex { get; set; }

        /// <summary>
        /// 住址
        /// </summary>
        public String Address { get; set; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        public String Email_address { get; set; }

        /// <summary>
        /// 工作电话
        /// </summary>
        public String Work_phone { get; set; }

        /// <summary>
        /// 私人电话
        /// </summary>
        public String Personal_phone { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public String Mobile_phone { get; set; }

        /// <summary>
        /// 体重（KG）
        /// </summary>
        public int? Weight { get; set; }

        /// <summary>
        /// 身高 (cm)
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// 年龄 ！
        /// </summary>
        public int? Age { get; set; }

        /// <summary>
        /// 最大心率=220-age
        /// </summary>
        public int? Max_heart_rate { get; set; }

        /// <summary>
        /// 最宜心率
        /// </summary>
        public int? Suitable_heart_rate { get; set; }

        /// <summary>
        /// 角色id，1：会员；0：教练
        /// </summary>
        public int? Role_id { get; set; }

        /// <summary>
        /// 外键关联教练id
        /// </summary>
        public int? Fk_coach_id { get; set; }

        /// <summary>
        /// 标签名数组：标签名：增肌、减脂、塑形、康复，用符号分隔
        /// </summary>
        public String Label_name { get; set; }

        /// <summary>
        /// 是否开启减脂模式 默认0，0:未开启，1:开启
        /// </summary>
        public Boolean? Is_open_fat_reduction { get; set; }

        /// <summary>
        /// 前端备注
        /// </summary>
        public String Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Gmt_create { get; set; }

        /// <summary>
        /// gmt_modified ！
        /// </summary>
        public DateTime? Gmt_modified { get; set; }
    }

}

