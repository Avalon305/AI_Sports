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
        public VitalSigns()
        {
            InitializeComponent();
            var Lengths = new List<Lengths>
        {
         new Lengths{Shoulder="30cm",Arm="30cm",Forearm="30cm",Thign="30cm",Shank="30cm",},

         };
            this.stackPanel.DataContext = Lengths;
        }
    }

    public class Lengths
    {
        public string Shoulder { get; set; }
        public string Arm { get; set; }
        public string Forearm { get; set; }
        public string Thign { get; set; }
        public string Shank { get; set; }
    }
}
