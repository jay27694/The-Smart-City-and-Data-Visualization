using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCity.Lib
{
    [Serializable()]
    public class MyLocation
    {
        public Double Latitude;
        public Double Longitude;
        public MyLocation(Double Latitude,Double  Longitude)
        {
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }

    }
}
