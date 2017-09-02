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

namespace SmartCity.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        MainWindow MW = (MainWindow)Application.Current.MainWindow;


        public LoginPage()
        {
            InitializeComponent();
            txt_username.Focusable = true;
            txt_username.Focus();
        }

        private void onMouseHoverLogin(object sender, MouseEventArgs e)
        {
            lbl_Login.Foreground =Brushes.White;
            border_login.Background = (Brush)new BrushConverter().ConvertFrom("#FF470D47");
            border_login.Opacity = 0.8;
        }

        private void onMouseLeaveLogin(object sender, MouseEventArgs e)
        {
            lbl_Login.Foreground = (Brush)new BrushConverter().ConvertFrom("#FF470D47");
            border_login.Background = Brushes.White;
            border_login.Opacity = 1.0;
        }

        private void onMouseHoverReset(object sender, MouseEventArgs e)
        {
            lbl_Reset.Foreground = Brushes.White;
            border_Reset.Background = (Brush)new BrushConverter().ConvertFrom("#FF470D47");
            border_Reset.Opacity = 0.8;
        }

        private void onMouseLeaveReset(object sender, MouseEventArgs e)
        {
            lbl_Reset.Foreground = (Brush)new BrushConverter().ConvertFrom("#FF470D47");
            border_Reset.Background = Brushes.White;
            border_Reset.Opacity = 1.0;
        }

       

        private void onResetClick(object sender, MouseButtonEventArgs e)
        {
            txt_password.Text = "";
            txt_username.Text = "";
            txt_username.Focusable = true;
            txt_username.Focus();
        }

        private void onLoginClick(object sender, MouseButtonEventArgs e)
        {
            
           MW.MainFrame.NavigationService.Navigate(new Uri(@"Pages\ZonePage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
