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
using smartcity.Library;
using System.Data.SqlClient;
using System.Security.Cryptography;
namespace SmartCity.Pages
{
    /// <summary>
    /// Interaction logic for loginPage2.xaml
    /// </summary>
    public partial class loginPage2 : Page
    {
        MainWindow MW = (MainWindow)Application.Current.MainWindow;
        public loginPage2()
        {
            InitializeComponent();
        }

        private void onLoginClick(object sender, MouseButtonEventArgs e)
        {
            DatabaseOperation.Connect();
            SqlDataReader reader = DatabaseOperation.SelectQuery("SELECT * FROM Admin WHERE Username = '" + Username.Text + "'");
            if (reader.Read())
            {
                string password = reader.GetString(1);
                string enteredPassword = CalculateMD5Hash(Password.Password);
                if (password == enteredPassword)
                {
                    MW.MainFrame.NavigationService.Navigate(new Uri(@"Pages\ZonePage.xaml", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    MessageBox.Show("Wrong Password");
                }
                reader.Close();
            }
            else
            {
                MessageBox.Show("Wrong username");
            }
            DatabaseOperation.Disconnect();
        }

        public string CalculateMD5Hash(string input)
        {
            // Step 1 calculate md5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputbytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputbytes);

            //step 2 convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private void onEnter(object sender, MouseEventArgs e)
        {
            border_login.Opacity = .5;
        }

        private void onLeave(object sender, MouseEventArgs e)
        {
            border_login.Opacity = 1;
        }
    }
}
