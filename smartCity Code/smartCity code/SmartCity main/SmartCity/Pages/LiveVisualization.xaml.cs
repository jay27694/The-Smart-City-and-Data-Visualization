using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using map;
using Microsoft.Maps.MapControl.WPF;
using TeamComet.TcpIp.Practice;
using System.Threading;
namespace SmartCity.Pages
{
    /// <summary>
    /// Interaction logic for LiveVisualization.xaml
    /// </summary>
    public partial class LiveVisualization : Page
    {

        public MyMap NewMap;   // create object of class MyMap  
        public string MapKey = "Av7tjDXQcLWVTdASoYHbGpaL7kTtAjjoAs0Or0FGcNmbQYLB-87f5lt_RvZ0JKeq";

        bool flag_task = false;
       
        SoundPlayer simpleSound;
        Task task_fire;
        //for main server
        Server MainServer = new Server();

        public string ZoneId { get; set; }
        public string ZoneName { get; set; }
        public LocationCollection ZoneLocation { get; set; }
        public string Temperature { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
        public Boolean FireStatus { get; set; }
        public Location Fire_Location { get; set; }
        public Boolean Rain1_Status { get; set; }
        public LocationCollection Rain1_Location { get; set; }
        public Boolean Rain2_Status { get; set; }
        public LocationCollection Rain2_Location { get; set; }

        public LiveVisualization()
        {
            InitializeComponent();

            //main server initialization
            MainServer.Initialize(9001, data_Rec);
            MainServer.Start();

             task_fire = new Task(onFire);

            NewMap = new MyMap(myMap, MapKey);
            myMap.Center = new Location(21.182782, 72.808912);

            myMap.ZoomLevel = 17;
                   
            myMap.Focus();
        }

        private void data_Rec(XComm.Sample.Message Data)
        {
            try
            {

                this.ZoneId = Data.ZoneId;
                this.ZoneName = Data.ZoneName;
                LocationCollection temp_locationCollection = new LocationCollection();
                for(int i=0;i<Data.ZoneLocation.Count;i++)
                {
                    Location temp=new Location(Data.ZoneLocation[i].Latitude,Data.ZoneLocation[i].Longitude);
                    temp_locationCollection.Add(temp);
                }
                ZoneLocation=temp_locationCollection;
              
                this.Temperature = Data.Temperature;
                this.Pressure = Data.Pressure;
                this.Humidity = Data.Humidity;
                this.FireStatus = Data.FireStatus;
                this.Fire_Location = new Location(Data.Fire_Location.Latitude,Data.Fire_Location.Longitude);
                this.Rain1_Status = Data.Rain1_Status;



                LocationCollection temp_locationCollection1 = new LocationCollection();
                for (int i = 0; i < Data.Rain1_Location.Count; i++)
                {
                    Location temp = new Location(Data.Rain1_Location[i].Latitude, Data.Rain1_Location[i].Longitude);
                    temp_locationCollection1.Add(temp);
                    
                }
                Rain1_Location = temp_locationCollection1;



                //this.Rain1_Location = Data.Rain1_Location;
                this.Rain2_Status = Data.Rain2_Status;
                LocationCollection temp_locationCollection2 = new LocationCollection();
              
                for (int i = 0; i < Data.Rain2_Location.Count; i++)
                {
                    Location temp = new Location(Data.Rain2_Location[i].Latitude, Data.Rain2_Location[i].Longitude);
                    temp_locationCollection2.Add(temp);
                }
                Rain2_Location = temp_locationCollection2;
                //this.Rain2_Location = Data.Rain2_Location;

                zone1_name.Dispatcher.BeginInvoke((Action)delegate
                {
                    zone1_name.Content = ZoneName;
                });

                lbl_temp.Dispatcher.BeginInvoke((Action)delegate
                {
                    lbl_temp.Content = Temperature;
                });

                lbl_pressure.Dispatcher.BeginInvoke((Action)delegate
                {
                    lbl_pressure.Content = Pressure;
                });
                lbl_humidity.Dispatcher.BeginInvoke((Action)delegate
                {
                    lbl_humidity.Content = Humidity;
                });


                myMap.Dispatcher.BeginInvoke((Action)delegate
                {
                    // for drawing zone area
                    NewMap.addNewPolyline(ZoneLocation);
                    //for zone 1 fire
                    if (Data.FireStatus == true && flag_task==false)
                    {
                        if (flag_task == false)
                        {
                            //task_fire.Start();
                        }
                        NewMap.AddLabel(Fire_Location, "fire");
                        NewMap.AddPushpin(Fire_Location);

                    }
                    else if (flag_task == true)
                    {
                        simpleSound.Stop();
                        flag_task = false;
                    }
                    //for zone 1 rain
                    if (Data.Rain1_Status == true)
                    {
                        NewMap.addNewPolygon(Rain1_Location);
                    }
                    if (Data.Rain2_Status == true)
                    {
                        NewMap.addNewPolygon(Rain2_Location);
                    }

                    //-------------------------------------------------------------------------------------------------
                    myMap.Children.Clear();
                    //------------------------------------------------------------------------------------------------
                    if (Data.Rain1_Status == true)
                    {
                        NewMap.addNewPolygon(Rain1_Location);
                    }
                    if (Data.Rain2_Status == true)
                    {
                        NewMap.addNewPolygon(Rain2_Location);
                    }
                    NewMap.addNewPolyline(ZoneLocation);
                    if (Data.FireStatus == true)
                    {
                        NewMap.AddLabel(Fire_Location, "fire");
                        NewMap.AddPushpin(Fire_Location);
                    }
                   

                });
            }
            catch (Exception ex) {  }
            Thread.Sleep(1000);
        }
        // private void CommunicationPort_DataReceivedEventHandler(string Data)
        //{
        //     try
        //     {
        //    string[] sd = Data.Split('|');

        //    bool rain1_flag=false,rain2_flag=false,flag=false;
        //    Task task_fire = new Task(onFire);
          
        //    LocationCollection zone1, zone1_rain1,zone1_rain2;

         
        //    myMap.Dispatcher.BeginInvoke((Action)delegate
        //    {
                
                
        //        //fire

        //        if (sd[3] == "1")
        //        {
        //            if (flag_task==false)
        //            {
        //                task_fire.Start();
                       
        //            }
        //            NewMap.AddLabel(new Location(21.182782, 72.808912), "fire");
        //            NewMap.AddPushpin(new Location(21.182782, 72.808912));
        //            flag = true;
        //        }
        //        else if (flag_task==true )
        //        {
                 
        //            simpleSound.Stop();                 
        //            flag_task = false;
        //        }

        //        //rain
        //        if (sd[4] == "1")
        //        {
        //            //NewMap.AddLabel(new Location(22.182175, 74.8086424), "rain");                                                              
        //            NewMap.addNewPolygon(zone1_rain1);
        //            rain1_flag = true;
        //        }

        //        if (sd[5] == "1")
        //        {
        //            //NewMap.AddLabel(new Location(22.182175, 74.8086424), "rain");
        //            NewMap.addNewPolygon(zone1_rain2);
        //            rain2_flag = true;
        //        }

        //        lbl_temp.Dispatcher.BeginInvoke((Action)delegate
        //        {
        //            lbl_temp.Content = sd[0];
        //        });

        //        lbl_pressure.Dispatcher.BeginInvoke((Action)delegate
        //        {
        //            lbl_pressure.Content = sd[1];     
        //        });
        //        lbl_humidity.Dispatcher.BeginInvoke((Action)delegate
        //        {
        //            lbl_humidity.Content = sd[2];     
        //        });
                
               
        //        if (flag == true)
        //        {
        //            NewMap.AddLabel(new Location(21.181797, 72.809357), "fire");
        //            NewMap.AddPushpin(new Location(21.182782, 72.808912));
        //        }
               
              
                 

                
        //        NewMap.addNewPolyline(zone1); 
 
        //        //map clear
        //        myMap.Children.Clear();
               
                           
        //        NewMap.addNewPolyline(zone1);  
        //        if (flag == true)
        //        {
        //            NewMap.AddLabel(new Location(21.181797, 72.809357), "fire");
        //            NewMap.AddPushpin(new Location(21.182782, 72.808912));
        //        }
        //        if (rain1_flag == true)
        //        {
        //           // NewMap.AddLabel(new Location(21.181797, 72.809357), "rain");
        //            NewMap.addNewPolygon(zone1_rain1);
        //        }
        //        if (rain2_flag == true)
        //        {
        //            // NewMap.AddLabel(new Location(21.181797, 72.809357), "rain");
        //            NewMap.addNewPolygon(zone1_rain2);
        //        }
              
        //    }
             
             
        //   );
        // }

        //    catch(Exception ex)
        //    {}
           
        //}

        private void onFire()
        {
             simpleSound = new SoundPlayer(@"C:\Users\jay\Downloads\alarm.wav");
            simpleSound.Play();
            flag_task = true;       
                 
        }

      
       


       

    }
    
}
