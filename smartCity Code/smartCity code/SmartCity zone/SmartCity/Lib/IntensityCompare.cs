using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            //CompareIntensity();
           Thread CheckIntensity = new Thread(CompareIntensity);
           CheckIntensity.Start();
         //  Task.Factory.StartNew(CompareIntensity);
         //  CheckIntensity.Start();
        }

        bool IsStop = true;
        private void CompareIntensity()
        {
            while (true)
            {
                if (Curlux < lux && flag == false && IsStop==true)
                {
                    startOnIntensity();

                    IsStop = false;
                }

                else if (Curlux >= lux && flag == false && IsStop==false)
                {
                    stopOnIntensity();
                   // Thread.Sleep(4000);
                    IsStop = true;
                }
                else if (flag==true)
                    break;
            }
        }

        
    }
}
