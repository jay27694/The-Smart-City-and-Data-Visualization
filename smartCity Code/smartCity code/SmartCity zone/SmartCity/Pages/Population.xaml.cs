using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using Microsoft.Maps.MapControl.WPF;
using map;
namespace SmartCity.Pages
{
    /// <summary>
    /// Interaction logic for Population.xaml
    /// </summary>
    public partial class Population : Page
    {
        public MyMap NewMap;   // create object of class MyMap  
        public string MapKey = "Av7tjDXQcLWVTdASoYHbGpaL7kTtAjjoAs0Or0FGcNmbQYLB-87f5lt_RvZ0JKeq";

        LocationCollection zone1;
        string zoneLocationFromDB;
        Location ll;

        string population;
        public Population()
        {
            InitializeComponent();
            DatabaseOperation.Connect();

            SqlDataReader readerYear = DatabaseOperation.SelectQuery("SELECT Year FROM Population");

            while (readerYear.Read())
            {
                comboboxyear.Items.Add(readerYear.GetString(0));
                //zoneLocationFromDB = readerYear.GetString(2);
            }
            readerYear.Close();

            SqlDataReader reader = DatabaseOperation.SelectQuery("SELECT * FROM Zone WHERE ZoneId='Zone1'");

            while (reader.Read())
            {
                zoneLocationFromDB = reader.GetString(2);
            }
            reader.Close();
            DatabaseOperation.Disconnect();

            //zone1 area
            zone1 = new LocationCollection();
           
            string[] zoneLoc = zoneLocationFromDB.Split('|');
            for (int i = 0; i < 5; i++)
            {
                string[] collection = zoneLoc[i].Split(',');
                Location l = new Location(Convert.ToDouble(collection[0]), Convert.ToDouble(collection[1]));
                zone1.Add(l);
               
                if (i == 0)
                {
                    ll = l;                   
                }

            }
            zone1.Add(ll);

            NewMap = new MyMap(myMap, MapKey);
            myMap.Center = new Location(21.182782, 72.808912);
            myMap.ZoomLevel = 17;
            myMap.Focus();

           

        }

        private void yearChanged(object sender, SelectionChangedEventArgs e)
        {
            myMap.Dispatcher.BeginInvoke((Action)delegate
            {
                myMap.Children.Clear();
            });


            DatabaseOperation.Connect();
            string year = comboboxyear.SelectedItem.ToString();
            SqlDataReader reader = DatabaseOperation.SelectQuery("SELECT * FROM Population WHERE Year='"+year+"'");

            while (reader.Read())
            {
                population = reader.GetString(1);
            }
            reader.Close();

          
            DatabaseOperation.Disconnect();

            myMap.Dispatcher.BeginInvoke((Action)delegate
            {                
                NewMap.addNewPolyline(zone1);
                if (Convert.ToDouble(population) < 200000)
                {
                    NewMap.addNewPolygonGreen(zone1);
                }
                else if (Convert.ToDouble(population) < 400000)
                {
                    NewMap.addNewPolygonOrange(zone1);
                }

                else if (Convert.ToDouble(population) > 500000)
                {
                    NewMap.addNewPolygonRed(zone1);
                }

            });
        }

    }
}
