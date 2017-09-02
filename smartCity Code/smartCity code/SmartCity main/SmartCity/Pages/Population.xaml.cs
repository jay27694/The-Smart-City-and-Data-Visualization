using map;
using Microsoft.Maps.MapControl.WPF;
using smartcity.Library;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Population : Page
    {
        // InitializeComponent();
        public MyMap NewMap;  // create object of class MyMap  
        public string MapKey = "Av7tjDXQcLWVTdASoYHbGpaL7kTtAjjoAs0Or0FGcNmbQYLB-87f5lt_RvZ0JKeq";

        LocationCollection[] zone;
        string zoneLocationFromDB;
        Location ll;
        int j = 0;
        string population;
        public Population()
        {
           

        
            InitializeComponent();
            DatabaseOperation.Connect();
            zone = new LocationCollection[6];
            //SqlDataReader readerYear = DatabaseOperation.SelectQuery("SELECT Year FROM Population");

            //while (readerYear.Read())
            //{
            //    comboboxyear.Items.Add(readerYear.GetString(0));
            //    //zoneLocationFromDB = readerYear.GetString(2);
            //}
            //readerYear.Close();

            SqlDataReader reader = DatabaseOperation.SelectQuery("SELECT * FROM mainZone");
            j = 0;
            while (reader.Read())
            {
                zoneLocationFromDB = reader.GetString(2);
                //zone area
                zone[j] = new LocationCollection();
                
                string[] zoneLoc = zoneLocationFromDB.Split('|');
                for (int i = 0; i < zoneLoc.Length; i++)
                {
                    string[] collection = zoneLoc[i].Split(',');
                    Location l = new Location(Convert.ToDouble(collection[0]), Convert.ToDouble(collection[1]));
                    zone[j].Add(l);

                    if (i == 0)
                    {
                        ll = l;
                    }

                }
                zone[j].Add(ll);
                j++;
            }
            reader.Close();
            DatabaseOperation.Disconnect();

          

            NewMap = new MyMap(myMap, MapKey);
            myMap.Center = new Location(21.182782, 72.808912);
            myMap.ZoomLevel = 14;
            myMap.Focus();

           

        }

        private void yearChanged(object sender, SelectionChangedEventArgs e)
        {
            myMap.Dispatcher.BeginInvoke((Action)delegate
            {
                myMap.Children.Clear();
            });


           

       //     for (int i = 0; i < j; i++)
            {
                myMap.Dispatcher.BeginInvoke((Action)delegate
                {
                    DatabaseOperation.Connect();
                    for (int i = 0; i < j; i++)
                    {
                        NewMap.addNewPolyline(zone[i]);
                        
                        string[] year = comboboxyear.SelectedItem.ToString().Split(' ');
                        string zoneName = "Zone" + (i+1);
                        SqlDataReader reader = DatabaseOperation.SelectQuery("SELECT * FROM mainPopulation WHERE Year='" + year[1] + "' AND ZoneId='"+zoneName+"'");

                        while (reader.Read())
                        {
                            population = reader.GetString(1);
                        }
                        reader.Close();

                        if (Convert.ToDouble(population) < 200000)
                            {
                                NewMap.addNewPolygonGreen(zone[i]);
                            }
                        else if (Convert.ToDouble(population) < 500000)
                            {
                                NewMap.addNewPolygonOrange(zone[i]);
                            }

                        else if (Convert.ToDouble(population) > 500000)
                        {
                            NewMap.addNewPolygonRed(zone[i]);
                        }

                    }
                    DatabaseOperation.Disconnect();
                   
                });
            }
        }

    
    }
}
