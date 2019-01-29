using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// MemberInfo.xaml 的交互逻辑
    /// </summary>
    public partial class MemberInfo : Page
    {
        private jieMain jiekou = new jieMain();
        public MemberInfo()
        {
            InitializeComponent();



            this.L1.DataContext = jiekou.person;
            this.L2.DataContext = jiekou.person;
            this.L3.DataContext = jiekou.person;
            this.Name.DataContext = jiekou.person;
            jiekou.addperson();
            jiekou.addtype();
            if (jiekou.type.a1)
            {
                runtimes1.Visibility = Visibility.Visible;
            }


            if (jiekou.type.a2)
            {
                runtimes2.Visibility = Visibility.Visible;
            }


            if (jiekou.type.a3)
            {
                runtimes2.Visibility = Visibility.Visible;
            }


            if (jiekou.type.a4)
            {
                runtimes2.Visibility = Visibility.Visible;
            }
            jiekou.addcard();
            if (jiekou.card.Score1 == null)
            {
                x1.Visibility = Visibility.Visible;
                x2.Visibility = Visibility.Collapsed;

            }
            else
            {
                x1.Visibility = Visibility.Collapsed;
                x2.Visibility = Visibility.Visible;
                this.x3.DataContext = jiekou.card;
            }
            jiekou.addperson();


        }
        private void Checkbox1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Checkbox2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Checkbox3_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Checkbox4_Checked(object sender, RoutedEventArgs e)
        {

        }
    }

    class jieMain
    {
        public person person;
        public type type;
        public Card card;
        public jieMain()
        {
            person = new person();

            type = new type();
            card = new Card();
        }
        public void addperson()
        {
            person.Coach = "123";
            person.FirstTime = "1-1";
            person.LastTime = "1-10";
            person.Name = "陈 先生";
        }
        public void addtype()
        {
            type.a1 = true;
            type.a2 = true;
            type.a3 = true;
            type.a4 = true;
        }
        public void addcard()
        {
            card.Score1 = "123456";
        }

    }

    public class Card
    {
        public string Score1 { get; set; }

    }
    public class type
    {
        public bool a1 { get; set; }
        public bool a2 { get; set; }
        public bool a3 { get; set; }
        public bool a4 { get; set; }
    }

    class person
    {

        public string Name { get; set; }
        public string Coach { get; set; }
        public string FirstTime { get; set; }
        public string LastTime { get; set; }


    }






}
