using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCity.Lib
{
    class IntensityCompare
    {

        public delegate void delegateOnIntensity();
        public event delegateOnIntensity startOnIntensity;
        public event delegateOnIntensity stopOnIntensity;
        int Curlux,lux;
        public static bool flag;

        public void setCurrentIntensity(String Curlux)
        {
            this.Curlux = int.Parse(Curlux);
        }

        public void setIntensity(String lux)
        {
            this.lux = int.Parse(lux);
            Task CheckIntensity = new Task(CompareIntensity);
            CheckIntensity.Start();
        }

        private void CompareIntensity()
        {
            while (true)
            {
                if (Curlux < lux && flag == false)
                {
                    startOnIntensity();
                }

                else if (Curlux >= lux && flag == false)
                {
                    stopOnIntensity();
                }
                else
                    break;
            }
        }

        
    }
}
