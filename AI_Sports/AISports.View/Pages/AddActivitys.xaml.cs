using AI_Sports.Dao;
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

namespace AI_Sports
{
    /// <summary>
    /// Xw_2.xaml 的交互逻辑
    /// </summary>
    public partial class AddActivitys : Page
    {
        private TrainingActivityService trainingActivityService = new TrainingActivityService();

        private DatacodeDAO datacodeDAO = new DatacodeDAO();

        public AddActivitys()
        {
            InitializeComponent();

            //初始化训练活动listbox
            InitTraingingActivities();
        }
        //以下是训练活动的相关方法：
        /// <summary>
        /// 减少轮次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lunci_minus(object sender, RoutedEventArgs e)
        {
            int text = int.Parse(lunci_content.Content.ToString());
            //轮次最小为1
            if (text > 1)
            {
                text--;
                lunci_content.Content = text.ToString();
            }

        }
        /// <summary>
        /// 增加伦次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lunci_plus(object sender, RoutedEventArgs e)
        {
            int text = int.Parse(lunci_content.Content.ToString());
            text++;
            lunci_content.Content = text.ToString();
        }
        /// <summary>
        /// 查询出训练活动，初始化listbox
        /// </summary>
        private void InitTraingingActivities()
        {
            List<DatacodeEntity> datacodeEntities = datacodeDAO.ListByTypeId("CYCLE_TYPE");
            this.huodong.ItemsSource = datacodeEntities;
        }

        /// <summary>
        /// 训练活动保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Save_Activity(object sender, RoutedEventArgs e)
        {
            //实例化一个活动集合
            List<ActivityEntity> activities = new List<ActivityEntity>();

            for (int i = 0; i < this.huodong.Items.Count; i++)
            {
                ListBoxItem item = this.huodong.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem;
                //调用方法通过VisualTreeHelper去找到TextBlock|Checkbox控件
                
                CheckBox chkBox = FindFirstElementInVisualTree<CheckBox>(item);

                //如果是被选中的就添加
                if (chkBox.IsChecked == true)
                {
                    //MessageBox.Show(chkBox.Content.ToString());
                    ActivityEntity activityEntity = new ActivityEntity();
                    //获得总的训练目标轮次
                    activityEntity.Target_turn_number = ParseIntegerUtil.ParseInt(lunci_content.Content.ToString());
                    //获得选中训练活动转化为对应编码，力量循环：0 。力量耐力循环：1
                    if ("力量循环".Equals(chkBox.Content))
                    {
                        activityEntity.Activity_type = "0";

                    }
                    else if ("力量耐力循环".Equals(chkBox.Content))
                    {
                        activityEntity.Activity_type = "1";

                    }

                    //添加到集合
                    activities.Add(activityEntity);


                }
            }

            //数组不为空则插入
            if (activities.Count > 0)
            {
                //批量添加训练活动
                trainingActivityService.BatchSaveActivity(activities);
                //跳转到活动设置页面
                NavigationService.GetNavigationService(this).Navigate(new Uri("/AI_Sports;component/AISports.View/Pages/trainingCourse.xaml", UriKind.Relative));

            }
            else
            {
                Console.WriteLine("训练活动不能为空，请至少选择一个");
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
