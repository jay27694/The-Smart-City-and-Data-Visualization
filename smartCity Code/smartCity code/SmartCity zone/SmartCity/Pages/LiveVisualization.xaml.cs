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
using SmartCity.Lib;
using System.Threading;
using smartcity.Library;
using System.Data.SqlClient;
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
       
        //for all server
        XComm.Sample.Message Message1 = new XComm.Sample.Message();

        //for main server-client
        LocalClient Client_main = new LocalClient();

        Location rl1, rl2, rl3, rl4, rl5, rl6, r1l1, r1l2, r1l3, r1l4, r1l5;
        LocationCollection zone1, zone1_rain1, zone1_rain2;

        //for inserting data in database
        DateTime currentDate;
        string tempSensorId;
        string presSensorId;
        string humSensorId;
        string zoneId;
        string zoneLocationFromDB;

        Location ll;
        MyLocation ml1;

        public LiveVisualization()
        {
            InitializeComponent();

            DatabaseOperation.Connect();

            SqlDataReader reader = DatabaseOperation.SelectQuery("SELECT * FROM Zone WHERE ZoneId='Zone1'");

            while (reader.Read())
            {
                Message1.ZoneId = reader.GetString(0);
                Message1.ZoneName = reader.GetString(1);
                zoneLocationFromDB = reader.GetString(2); 
            }
            reader.Close();
            DatabaseOperation.Disconnect();

            //zone1 area
            zone1 = new LocationCollection();
            List<MyLocation> zoneLocation = new List<MyLocation>();
            string[] zoneLoc = zoneLocationFromDB.Split('|');
            for (int i = 0; i < 5; i++)
            {
                string[] collection = zoneLoc[i].Split(',');
                Location l = new Location(Convert.ToDouble(collection[0]),Convert.ToDouble(collection[1]));
                zone1.Add(l);


                MyLocation ml = new MyLocation(Convert.ToDouble(collection[0]), Convert.ToDouble(collection[1]));
                zoneLocation.Add(ml);

                if (i == 0)
                {
                    ll = l;
                    ml1 = ml;
                }
                
            }
            zone1.Add(ll);
            zoneLocation.Add(ml1);
            Message1.ZoneLocation = zoneLocation;

            //rain sensor1
            rl1 = new Location(21.1843465, 72.8080135);
            rl2 = new Location(21.183261, 72.805444);
            rl3 = new Location(21.180415, 72.807622);
            rl4 = new Location(21.180685, 72.809339);
            rl5 = new Location(21.1820105, 72.8115755);
            rl6 = new Location(21.1843465, 72.8080135);
            zone1_rain1 = new LocationCollection();
            zone1_rain1.Add(rl1);
            zone1_rain1.Add(rl2);
            zone1_rain1.Add(rl3);
            zone1_rain1.Add(rl4);
            zone1_rain1.Add(rl5);
            zone1_rain1.Add(rl6);

            //rain sensor2
            r1l1 = new Location(21.1843465, 72.8080135);
            r1l2 = new Location(21.1820105, 72.8115755);
            r1l3 = new Location(21.183336, 72.813812);
            r1l4 = new Location(21.185432, 72.810583);
            r1l5 = new Location(21.1843465, 72.8080135);
            zone1_rain2 = new LocationCollection();
            zone1_rain2.Add(r1l1);
            zone1_rain2.Add(r1l2);
            zone1_rain2.Add(r1l3);
            zone1_rain2.Add(r1l4);
            zone1_rain2.Add(r1l5);


            

            //for main server client
            Client_main.Connect(@"172.16.0.12", 9001);

            
            //creation of msg1 object
           
            Message1.Fire_Location = new MyLocation(21.182782, 72.808912);
          
            //for rain1 location,creation of message class
            List<MyLocation> rain1Location = new List<MyLocation>();
            rain1Location.Add(new MyLocation(21.1843465, 72.8080135));
            rain1Location.Add(new MyLocation(21.183261, 72.805444));
            rain1Location.Add(new MyLocation(21.180415, 72.807622));
            rain1Location.Add(new MyLocation(21.180685, 72.809339));
            rain1Location.Add(new MyLocation(21.1820105, 72.8115755));
            rain1Location.Add(new MyLocation(21.1843465, 72.8080135));
            Message1.Rain1_Location = rain1Location;

            //for rain2 location,creation of message class
            List<MyLocation> rain2Location = new List<MyLocation>();
            rain2Location.Add(new MyLocation(21.1843465, 72.8080135));
            rain2Location.Add(new MyLocation(21.1820105, 72.8115755));
            rain2Location.Add(new MyLocation(21.183336, 72.813812));
            rain2Location.Add(new MyLocation(21.185432, 72.810583));
            rain2Location.Add(new MyLocation(21.1843465, 72.8080135));
            Message1.Rain2_Location = rain2Location;


            currentDate = DateTime.Now;
            tempSensorId ="temp1";
            presSensorId = "pres1";
            humSensorId = "humidity1";
            zoneId = "zone1";

            Lib.Communication.DataReceivedEventHandler += CommunicationPort_DataReceivedEventHandler;
            NewMap = new MyMap(myMap, MapKey);
            myMap.Center = new Location(21.182782, 72.808912);
            myMap.ZoomLevel = 17;                  
            myMap.Focus();
        }

         private void CommunicationPort_DataReceivedEventHandler(string Data)
        {
             try
             {        
                    //split the serial port data
                     string[] sd = Data.Split('|');

                     if (sd.Length == 7)
                     {
                         task_fire = new Task(onFire);

                         if (currentDate.Hour == DateTime.Now.Hour)
                         {
                             DatabaseOperation.Connect();
                             if(sd[0]!="")
                             DatabaseOperation.InsertUpdateDelete("INSERT INTO Temp VALUES('"+tempSensorId+"','"+zoneId+"','"+sd[0]+"','"+DateTime.Now+"') ");
                             DatabaseOperation.Disconnect();
                             DatabaseOperation.Connect();
                             if (sd[1] != "")
                             DatabaseOperation.InsertUpdateDelete("INSERT INTO Pressure VALUES('" + presSensorId + "','" + zoneId + "','" + sd[1] + "','" + DateTime.Now + "') ");
                             DatabaseOperation.Disconnect();
                             DatabaseOperation.Connect();
                             if (sd[2] != "")
                             DatabaseOperation.InsertUpdateDelete("INSERT INTO Humidity VALUES('" + humSensorId + "','" + zoneId + "','" + sd[2] + "','" + DateTime.Now + "') ");
                             DatabaseOperation.Disconnect();
                             currentDate=currentDate.AddHours(2.0);
                         }
                         Message1.Temperature = sd[0];
                         Message1.Pressure = sd[1];
                         Message1.Humidity = sd[2];


                         //fire
                         if (sd[3] == "1")
                         {
                             //border label
                             lbl_firestatus.Dispatcher.BeginInvoke((Action)delegate
                             {
                                 lbl_firestatus.Content = "Fire";
                             });

                             //playing alarm
                             if (flag_task == false)
                             {
                                 task_fire.Start();
                             }

                             myMap.Dispatcher.BeginInvoke((Action)delegate
                             {
                                 NewMap.AddLabel(new Location(21.182782, 72.808912), "fire");
                                 NewMap.AddPushpin(new Location(21.182782, 72.808912));
                             });

                             Message1.FireStatus = true;

                         }
                         else if (flag_task == true)
                         {
                             //border label
                             lbl_firestatus.Dispatcher.BeginInvoke((Action)delegate
                             {
                                 lbl_firestatus.Content = "-";
                             });

                             //stop sound
                             simpleSound.Stop();
                             flag_task = false;

                             Message1.FireStatus = false;
                         }

                         //rain

                         if (sd[4] == "1")
                         {
                             //border lbl
                             lbl_rain1status.Dispatcher.BeginInvoke((Action)delegate
                             {
                                 lbl_rain1status.Content = "rain1";
                             });
                             myMap.Dispatcher.BeginInvoke((Action)delegate
                             {
                                 NewMap.addNewPolygon(zone1_rain1);
                             });
                             Message1.Rain1_Status = true;
                         }
                         else if (sd[4] == "0")
                         {

                             lbl_rain1status.Dispatcher.BeginInvoke((Action)delegate
                             {
                                 lbl_rain1status.Content = "-";
                             });



                             Message1.Rain1_Status = false;

                         }
                         if (sd[5] == "1")
                         {
                             lbl_rain2status.Dispatcher.BeginInvoke((Action)delegate
                             {
                                 lbl_rain2status.Content = "rain2";
                             });
                             myMap.Dispatcher.BeginInvoke((Action)delegate
                             {
                                 NewMap.addNewPolygon(zone1_rain2);
                             });

                             Message1.Rain2_Status = true;

                         }
                         else if (sd[5] == "0")
                         {
                             lbl_rain2status.Dispatcher.BeginInvoke((Action)delegate
                             {
                                 lbl_rain2status.Content = "-";
                             });
                             Message1.Rain2_Status = false;
                         }

                         lbl_temp.Dispatcher.BeginInvoke((Action)delegate
                         {
                             lbl_temp.Content = sd[0];
                         });

                         lbl_pressure.Dispatcher.BeginInvoke((Action)delegate
                         {
                             lbl_pressure.Content = sd[1];
                         });
                         lbl_humidity.Dispatcher.BeginInvoke((Action)delegate
                         {
                             lbl_humidity.Content = sd[2];
                         });





                         myMap.Dispatcher.BeginInvoke((Action)delegate
                         {
                             //for zone area
                             NewMap.addNewPolyline(zone1);

                             //map clear--------------------------------------------------------------------------------------------
                             myMap.Children.Clear();
                             //-----------------------------------------------------------------------------------------------------

                             NewMap.addNewPolyline(zone1);

                         });


                         if (sd[3] == "1")
                         {
                             myMap.Dispatcher.BeginInvoke((Action)delegate
                             {
                                 NewMap.AddLabel(new Location(21.182782, 72.808912), "fire");
                                 NewMap.AddPushpin(new Location(21.182782, 72.808912));
                             });
                         }
                         if (sd[4] == "1")
                         {
                             myMap.Dispatcher.BeginInvoke((Action)delegate
                             {
                                 NewMap.addNewPolygon(zone1_rain1);
                             });
                         }

                         if (sd[5] == "1")
                         {
                             myMap.Dispatcher.BeginInvoke((Action)delegate
                             {
                                 NewMap.addNewPolygon(zone1_rain2);
                             });

                         }


                         Client_main.Send(Message1);

                     } 
                
         }

            catch(Exception ex)
            {}
           
        }

        

        private void onFire()
        {
            simpleSound = new SoundPlayer(@"C:\Users\jay\Downloads\alarm.wav");
            //simpleSound.Play();
            flag_task = true;                        
        }

      
       
       

        private void myMap_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (myMap.ZoomLevel < 17)

                myMap.ZoomLevel = 17;
        }

        private void onUnload(object sender, RoutedEventArgs e)
        {
           // Client_main.Close();
        }

          

    }
    
}
