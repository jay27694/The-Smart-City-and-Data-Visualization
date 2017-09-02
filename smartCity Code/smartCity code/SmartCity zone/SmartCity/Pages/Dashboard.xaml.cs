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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartCity.Pages
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();
            DoubleAnimation da1 = new DoubleAnimation();
            da.From = 500;
            da.To = 200;
            da.Duration = TimeSpan.FromSeconds(2);
            da.AutoReverse = true;
            lst_Main.BeginAnimation(ListView.WidthProperty, da);
            da1.From = 1;
            da1.To = 0;
            da1.Duration = TimeSpan.FromSeconds(2);
            da1.AutoReverse = true;
            lst_Main.BeginAnimation(ListView.OpacityProperty, da1);
        }
    }
}
