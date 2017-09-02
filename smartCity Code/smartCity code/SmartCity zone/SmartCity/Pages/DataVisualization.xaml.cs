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
using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources; // EnumerableDataSource
using Microsoft.Research.DynamicDataDisplay.PointMarkers;
using System.IO; // CirclePointMarker

namespace SmartCity.Pages
{
    /// <summary>
    /// Interaction logic for DataVisualization.xaml
    /// </summary>
    public partial class DataVisualization : Page
    {
        public DataVisualization()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(onWindowLoad);
        }

        private void onWindowLoad(object sender, RoutedEventArgs e)
        {
          
            List<temperatureInfo> temperatureInfoList = LoadTemperatureInfo();
            List<pressureInfo> pressureInfoList = LoadPressureInfo();
            List<humidityInfo> humidityInfoList = LoadHumidityInfo();
            //List<temperatureInfo> temperatureInfoList = LoadTemperatureInfo();

            //DateTime[] dates = new DateTime[bugInfoList.Count];
            DateTime[] temperatureDates = new DateTime[temperatureInfoList.Count];
            DateTime[] pressureDates = new DateTime[pressureInfoList.Count];
            int[] temperature = new int[temperatureInfoList.Count];
            int[] pressure = new int[pressureInfoList.Count];

            DateTime[] humidityDates = new DateTime[humidityInfoList.Count];
            int[] humidity = new int[humidityInfoList.Count];

            for (int i = 0; i < temperatureInfoList.Count; ++i)
            {
                temperatureDates[i] = temperatureInfoList[i].date;
                temperature[i] = temperatureInfoList[i].temperature;
                // numberClosed[i] = bugInfoList[i].numberClosed;
            }

            for (int i = 0; i < pressureInfoList.Count; ++i)
            {
                pressureDates[i] = pressureInfoList[i].date;
                pressure[i] = pressureInfoList[i].pressure;
                // numberClosed[i] = bugInfoList[i].numberClosed;
            }

            for (int i = 0; i < humidityInfoList.Count; ++i)
            {
                humidityDates[i] = humidityInfoList[i].date;
                humidity[i] = humidityInfoList[i].humidity;
                // numberClosed[i] = bugInfoList[i].numberClosed;
            }

            var temperatureDatesDataSource = new EnumerableDataSource<DateTime>(temperatureDates);
            temperatureDatesDataSource.SetXMapping(x => dateAxis.ConvertToDouble(x));

            var numberTemperature = new EnumerableDataSource<int>(temperature);
            numberTemperature.SetYMapping(y => Convert.ToDouble(y));

            var pressureDatesDataSource = new EnumerableDataSource<DateTime>(pressureDates);
            pressureDatesDataSource.SetXMapping(x => dateAxis.ConvertToDouble(x));

            var numberPressure = new EnumerableDataSource<int>(pressure);
            numberPressure.SetYMapping(y => Convert.ToDouble(y));

            var humidityDatesDataSource = new EnumerableDataSource<DateTime>(humidityDates);
            humidityDatesDataSource.SetXMapping(x => dateAxis.ConvertToDouble(x));

            var numberHumidity = new EnumerableDataSource<int>(humidity);
            numberHumidity.SetYMapping(y => Convert.ToDouble(y));

            CompositeDataSource compositeDataSource1 = new CompositeDataSource(temperatureDatesDataSource, numberTemperature);
            CompositeDataSource compositeDataSource2 = new CompositeDataSource(pressureDatesDataSource, numberPressure);
            CompositeDataSource compositeDataSource3 = new CompositeDataSource(humidityDatesDataSource, numberHumidity);

            plotter.AddLineGraph(compositeDataSource1,
                      new Pen(Brushes.Blue, 2),
                      new CirclePointMarker { Size = 10.0, Fill = Brushes.Red },
                      new PenDescription("Temperature Details(in C)"));

           // plotter.AddLineGraph(compositeDataSource1, Colors.Red, 1, "Temperature");

            //Pen dashedPen = new Pen(Brushes.Magenta, 3);
            //dashedPen.DashStyle = DashStyles.DashDot;
        //    plotter.AddLineGraph(compositeDataSource1, dashedPen, new PenDescription("Pressure"));

            plotter.AddLineGraph(compositeDataSource2,
                     new Pen(Brushes.Green, 2),
                     new TrianglePointMarker { Size = 10.0, Pen = new Pen(Brushes.Black, 2.0), Fill = Brushes.GreenYellow },
                     new PenDescription("Pressure details(in Hg/m^3)"));


            plotter.AddLineGraph(compositeDataSource3,
                      new Pen(Brushes.Cyan, 2),
                      new CirclePointMarker { Size = 10.0, Fill = Brushes.Red },
                      new PenDescription("Humidity Details"));


            plotter.Viewport.FitToView();

          
        }

      
        
        
        private static List<temperatureInfo> LoadTemperatureInfo()
        {
            var result = new List<temperatureInfo>();
            DatabaseOperation.Connect();
            SqlDataReader reader1 = DatabaseOperation.SelectQuery("SELECT SensedValue,TimeStamp FROM Temp ORDER BY TimeStamp");

            while (reader1.Read())
            {
                string[] sensed = reader1.GetString(0).Split('.');
                int sensedValue = Convert.ToInt16(sensed[0]);
                DateTime date = reader1.GetDateTime(1);
                temperatureInfo t = new temperatureInfo(date, sensedValue);
                result.Add(t);
                
            }
            reader1.Close();
            DatabaseOperation.Disconnect();
            
            return result;
        }

        private static List<pressureInfo> LoadPressureInfo()
        {
            var result = new List<pressureInfo>();
            DatabaseOperation.Connect();
            SqlDataReader reader1 = DatabaseOperation.SelectQuery("SELECT SensedValue,TimeStamp FROM Pressure ORDER BY TimeStamp");

            while (reader1.Read())
            {
                string[] sensed = reader1.GetString(0).Split('.');
                int sensedValue = Convert.ToInt16(sensed[0]);
                DateTime date = reader1.GetDateTime(1);
                pressureInfo t = new pressureInfo(date, sensedValue);
                result.Add(t);

            }
            reader1.Close();
            DatabaseOperation.Disconnect();

            return result;
        }


        private static List<humidityInfo> LoadHumidityInfo()
        {
            var result = new List<humidityInfo>();
            DatabaseOperation.Connect();
            SqlDataReader reader1 = DatabaseOperation.SelectQuery("SELECT SensedValue,TimeStamp FROM Humidity ORDER BY TimeStamp");

            while (reader1.Read())
            {
                string[] sensed = reader1.GetString(0).Split('.');
                int sensedValue = Convert.ToInt16(sensed[0]);
                DateTime date = reader1.GetDateTime(1);
                humidityInfo t = new humidityInfo(date, sensedValue);
                result.Add(t);

            }
            reader1.Close();
            DatabaseOperation.Disconnect();

            return result;
        }

        private void datechanged(object sender, SelectionChangedEventArgs e)
        {
            DatabaseOperation.Connect();
            DateTime dt = (DateTime)selected_date.SelectedDate;

            SqlDataReader reader = DatabaseOperation.SelectQuery("SELECT SensedValue,TimeStamp FROM Temp");

            while (reader.Read())
            {
                string sensed = reader.GetString(0);
                DateTime date = reader.GetDateTime(1);
                if (date.Date == dt.Date)
                {
                    lbl_temp.Content = sensed;
                }
            }
            reader.Close();

            SqlDataReader reader1 = DatabaseOperation.SelectQuery("SELECT SensedValue,TimeStamp FROM Pressure");

            while (reader1.Read())
            {
                string sensed = reader1.GetString(0);
                DateTime date = reader1.GetDateTime(1);
                if (date.Date == dt.Date)
                {
                    lbl_pressure.Content = sensed;
                }
            }
            reader1.Close();

            SqlDataReader reader2 = DatabaseOperation.SelectQuery("SELECT SensedValue,TimeStamp FROM Humidity");

            while (reader2.Read())
            {
                string sensed = reader2.GetString(0);
                DateTime date = reader2.GetDateTime(1);
                if (date.Date == dt.Date)
                {
                    lbl_humidity.Content = sensed;
                }
            }
            reader2.Close();

            DatabaseOperation.Disconnect();

        }
        


    } // class Window1

    public class temperatureInfo
    {
        public DateTime date;
        public int temperature;
        //public int numberClosed;

        public temperatureInfo(DateTime date, int temperature)
        {
            this.date = date; 
            this.temperature = temperature; //this.numberClosed = numberClosed;
        }
    }

    public class humidityInfo
    {
        public DateTime date;
        public int humidity;
        //public int numberClosed;

        public humidityInfo(DateTime date, int humidity)
        {
            this.date = date;
            this.humidity = humidity; //this.numberClosed = numberClosed;
        }
    }

    public class pressureInfo
    {
        public DateTime date;
        public int pressure;
        //public int numberClosed;

        public pressureInfo(DateTime date, int pressure)
        {
            this.date = date;
            this.pressure = pressure; //this.numberClosed = numberClosed;
        }
    }
}

    


