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
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Maps.MapControl.WPF.Design;
using TeamComet.TcpIp.Practice;
using map;
namespace SmartCity.Pages
{
    /// <summary>
    /// Interaction logic for ZonePage.xaml
    /// </summary>
    public partial class ZonePage : Page
    {
       // Server MainServer = new Server();
        
       // String temp, pres, humidity;
      //  public MyMap NewMap;   // create object of class MyMap  
      //  public string MapKey = "Av7tjDXQcLWVTdASoYHbGpaL7kTtAjjoAs0Or0FGcNmbQYLB-87f5lt_RvZ0JKeq";
      //  bool firests,rainsts;
        public ZonePage()
        {
            InitializeComponent();
            //ZoneFrame.NavigationService.Navigate(new Uri("Pages/Livevisulization.xaml", UriKind.RelativeOrAbsolute));
            //MainServer.Initialize(9001, data_Rec);
          
            //MainServer.Start();
            //NewMap = new MyMap(myMap, MapKey);
            //myMap.Center = new Location(21.182782, 72.808912);
            //myMap.ZoomLevel = 17;
                             
            //myMap.Focus();
            grid1.Width = 0;
            grid_data.Height = 50;
            grid_control.Height = 50;
        }
        //private void data_Rec(XComm.Sample.Message Data)
        //{
        //    temp = Data.Temperature;
        //    pres = Data.Pressure;
        //    humidity = Data.Humidity;
        //    firests = Data.FireStatus;
        //    rainsts = Data.RainStatus;
        //    myMap.Dispatcher.BeginInvoke((Action)delegate
        //    {
        //        NewMap.AddLabel(new Location(21.182782, 72.808912), "Temp:" + temp + "°C");
        //        NewMap.AddLabel(new Location(21.182452, 72.807968), "Pressure:" + pres + "Hg");
        //        NewMap.AddLabel(new Location(21.181432, 72.808435), "Humidity:" + humidity + "gm/m3");
        //        if (firests == true)
        //        {
        //            NewMap.AddLabel(new Location(21.181797, 72.809357), "fire");
        //            NewMap.AddPushpin(new Location(21.182782, 72.808912));
        //        }
        //        if (rainsts == true)
        //        {
        //            NewMap.AddLabel(new Location(21.181797, 72.809357), "rain");
        //            addNewPolygon();
        //        }
               
        //        myMap.Children.Clear();
        //        NewMap.AddLabel(new Location(21.182782, 72.808912), "Temp:" + temp + "°C");
        //        NewMap.AddLabel(new Location(21.182452, 72.807968), "Pressure:" + pres + "Hg");
        //        NewMap.AddLabel(new Location(21.181432, 72.808435), "Humidity:" + humidity + "gm/m3");


        //        if (firests == true)
        //        {
        //            NewMap.AddLabel(new Location(21.181797, 72.809357), "fire");
        //            NewMap.AddPushpin(new Location(21.182782, 72.808912));
        //        }
        //    //    if (flag == true)
        //    //    {
        //    //        NewMap.AddLabel(new Location(21.181797, 72.809357), "fire");
        //    //        NewMap.AddPushpin(new Location(21.182782, 72.808912));
        //    //    }
        //        if (rainsts == true)
        //        {
        //            NewMap.AddLabel(new Location(21.181797, 72.809357), "rain");
        //            addNewPolygon();
        //        }
        //    });
        //}
        //void addNewPolygon()
        //{
        //    MapPolygon polygon = new MapPolygon();
        //    polygon.Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
        //    polygon.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
        //    polygon.StrokeThickness = 5;
        //    polygon.Opacity = 0.3;
        //    polygon.Locations = new LocationCollection() 
        //    { 
        //        new Location( 21.182782, 72.808912), 
        //        new Location( 21.182452, 72.807968),
        //        new Location( 21.181432, 72.808435),
        //        new Location( 21.181797, 72.809357) 
        //    };

        //    myMap.Children.Add(polygon);
        //    //Thread.Sleep(10000);

        //}




        //-------------------------------------------------------------------------------------------------------------------
        //methods for animations and page navigation
        private void onRightArroeClick(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation da = new DoubleAnimation();

            if (grid1.Width == 00)
            {
                da.From = 0;
                da.To = 250;
                
                grid1.BeginAnimation(Grid.WidthProperty, da);
                img_arrow.Source = new BitmapImage(new Uri(@"..\Images\leftarrow.png", UriKind.Relative));
            }
            else
            {
                da.From = 250;
                da.To = 0;
                grid1.BeginAnimation(Grid.WidthProperty, da);
                img_arrow.Source = new BitmapImage(new Uri(@"..\Images\rightarrow.png", UriKind.Relative));
            }

        }

        private void onGridDataEnter(object sender, MouseEventArgs e)
        {
           
           
        }

        private void onGridControlEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void onLiveEnter(object sender, MouseEventArgs e)
        {
            border_live.Opacity = .5;
            border_data.Opacity = 1;
            border_controlable.Opacity = 1;

        }

        private void onCrimeEnter(object sender, MouseEventArgs e)
        {
            border_crime.Opacity = .6;
            border_environment.Opacity = .5;
            border_population.Opacity = .5;
            border_fire.Opacity = .5;
        }

        private void onPopulationEnter(object sender, MouseEventArgs e)
        {
            border_crime.Opacity = .5;
            border_environment.Opacity = .5;
            border_population.Opacity = .6;
            border_fire.Opacity = .5;
        }

        private void onEnvironmentEnter(object sender, MouseEventArgs e)
        {
            border_crime.Opacity = .5;
            border_environment.Opacity = .6;
            border_population.Opacity = .5;
            border_fire.Opacity = .5;
        }

        private void onFireEnter(object sender, MouseEventArgs e)
        {
            border_crime.Opacity = .5;
            border_environment.Opacity = .5;
            border_population.Opacity = .5;
            border_fire.Opacity = .6;
        }

        private void onLightEnter(object sender, MouseEventArgs e)
        {
            border_light.Opacity = .6;
        }

        private void onLightLeave(object sender, MouseEventArgs e)
        {
            border_light.Opacity = .5;
        }

        private void onDataBorderEnter(object sender, MouseEventArgs e)
        {
            border_data.Opacity = .5;
            border_controlable.Opacity = 1;
            border_live.Opacity = 1;
            DoubleAnimation da = new DoubleAnimation();


            da.From = 50;
            da.To = 190;
            da.SpeedRatio = 3;
            grid_data.BeginAnimation(Grid.HeightProperty, da);

            if (grid_control.Height == 90)
            {
                DoubleAnimation da1 = new DoubleAnimation();


                da1.From = 90;
                da1.To = 50;
                da1.SpeedRatio = 3;
                grid_control.BeginAnimation(Grid.HeightProperty, da1);
            }
        }

        private void onControlBorderEnter(object sender, MouseEventArgs e)
        {
            border_controlable.Opacity = .5;
            border_data.Opacity = 1;
            border_live.Opacity = 1;
            DoubleAnimation da = new DoubleAnimation();


            da.From = 50;
            da.To = 90;
            da.SpeedRatio = 3;
            grid_control.BeginAnimation(Grid.HeightProperty, da);

            if (grid_data.Height == 190)
            {
                DoubleAnimation da1 = new DoubleAnimation();


                da1.From = 190;
                da1.To = 50;
                da1.SpeedRatio = 3;
                grid_data.BeginAnimation(Grid.HeightProperty, da1);
            }
        }

        private void onLiveVisualizationClick(object sender, MouseButtonEventArgs e)
        {            
             ZoneFrame.NavigationService.Navigate(new Uri("Pages/LiveVisualization.xaml", UriKind.RelativeOrAbsolute));                   
        }

        private void onStreetLightClick(object sender, MouseButtonEventArgs e)
        {
            ZoneFrame.NavigationService.Navigate(new Uri("Pages/StreetLight.xaml", UriKind.RelativeOrAbsolute));
        }

        private void onDataVisualizationClick(object sender, MouseButtonEventArgs e)
        {
            ZoneFrame.NavigationService.Navigate(new Uri("Pages/DataVisualization.xaml", UriKind.RelativeOrAbsolute));
        }

        private void onPopulationClick(object sender, MouseButtonEventArgs e)
        {
            ZoneFrame.NavigationService.Navigate(new Uri("Pages/Population.xaml", UriKind.RelativeOrAbsolute));
        }

        private void onUnload(object sender, RoutedEventArgs e)
        {
            
        }

        


    }
}
