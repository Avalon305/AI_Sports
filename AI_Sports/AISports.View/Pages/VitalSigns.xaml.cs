using AI_Sports.AISports.Dao;
using AI_Sports.AISports.Entity;
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

namespace AI_Sports
{
    /// <summary>
    /// VitalSigns.xaml 的交互逻辑
    /// </summary>
    public partial class VitalSigns : Page
    {
        private SkeletonLengthDAO skeletonLengthDAO = new SkeletonLengthDAO();
        SkeletonLengthEntity skeletonLengthEntity;
        public VitalSigns()
        {
            InitializeComponent();
            //1.首先得到用户的身体长度数据 根据会员id统一更新座位高度、靠背距离、踏板长度
            string memberPK = CommUtil.GetSettingString("memberPrimarykey");
            string coachId = CommUtil.GetSettingString("coachId");

            string fkmemberId = (memberPK != null && memberPK != "") ? memberPK : coachId;
            skeletonLengthEntity = skeletonLengthDAO.getSkeletonLengthRecord(fkmemberId);
            this.stackPanel.DataContext = skeletonLengthEntity;
            //this.stackPanel.DataContext = Lengths;
        }
    }
}
