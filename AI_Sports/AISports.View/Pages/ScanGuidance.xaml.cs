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
using System.Windows.Threading;

namespace AI_Sports.AISports.View.Pages
{
    /// <summary>
    /// ScanAndGuidance.xaml 的交互逻辑
    /// </summary>
    public partial class ScanGuidance : Page
    {

        private DispatcherTimer ShowTimer;
        public ScanGuidance()
        {
            InitializeComponent();

           

        }

        //show timer by_songgp 
        public void ShowCurTimer(object sender, EventArgs e)
        {
        }


        public String Member_id { get; set; }

    }

}
