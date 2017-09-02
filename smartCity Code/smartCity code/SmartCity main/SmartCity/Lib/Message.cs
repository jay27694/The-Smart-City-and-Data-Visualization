using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Maps.MapControl.WPF;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCity.Lib;
namespace XComm
{
    namespace Sample
    {
        [Serializable()]
        public class Message
        {
            public string ZoneId { get; set; }
            public string ZoneName { get; set; }
            //  public LocationCollection zone_location { get; set; }
            public string Temperature { get; set; }
            public string Pressure { get; set; }
            public string Humidity { get; set; }
            public Boolean FireStatus { get; set; }
            //  public Location Fire_Location { get ;set;}

            public Boolean Rain1_Status { get; set; }
            // public LocationCollection Rain1_Location { get ; set; }          

            public Boolean Rain2_Status { get; set; }
            // public LocationCollection Rain2_Location { get ; set; }     

            public List<MyLocation> ZoneLocation { get; set; }
            public List<MyLocation> Rain1_Location { get; set; }
            public List<MyLocation> Rain2_Location { get; set; }
            public MyLocation Fire_Location { get; set; }   
          
        }
    }
}
