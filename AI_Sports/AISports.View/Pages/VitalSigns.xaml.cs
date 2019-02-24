using AI_Sports.AISports.Dao;
using AI_Sports.AISports.Entity;
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
            skeletonLengthEntity = skeletonLengthDAO.getSkeletonLengthRecord("123456");
            this.stackPanel.DataContext = skeletonLengthEntity;
            //this.stackPanel.DataContext = Lengths;
        }
    }
}
