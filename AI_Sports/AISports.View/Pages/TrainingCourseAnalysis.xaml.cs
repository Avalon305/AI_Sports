using AI_Sports.Entity;
using AI_Sports.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// TrainingCourseAnalysis.xaml 的交互逻辑
    /// </summary>
    public partial class TrainingCourseAnalysis : Page
    {
        TrainingCourseService trainingCourseService = new TrainingCourseService();
        public TrainingCourseAnalysis()
        {
            InitializeComponent();
            //查询课程记录集合 绑定ItemsSource
            List<TrainingCourseVO> trainingCourseVOs = trainingCourseService.listCourseRecord();

            this.TrainingCourseRecords.ItemsSource = trainingCourseVOs;

        }

        private void TrainingCourseRecords_MouseUp(object sender, MouseButtonEventArgs e)
        {
            int? Course_count = (this.TrainingCourseRecords.SelectedItem as TrainingCourseVO).Course_count;

            Console.WriteLine("选中行的course_count："+ Course_count);

        }
    }
}
