using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartCity.Lib
{
    class TimeCompare
    {
        byte startHour, startMinute,stopHour,stopMinute;
        public static bool flag;
        public delegate void delegateOnTime();
        public event delegateOnTime StartTimeEvent;
        public event delegateOnTime StopTimeEvent;

        public void setTime(byte startHour = 0, byte startMinute = 0,byte  stopHour= 0   , byte  stopMinute= 0 )
        {
            this.startHour = startHour;
            this.startMinute = startMinute;
            this.stopHour = stopHour;
            this.stopMinute = stopMinute;
            Thread compare=new Thread(CompareTime);
            compare.Start();
        }
        bool IsStop = true;
        private void CompareTime()
        {
            while (true)
            {
                if (flag == false)
                {
                    if (DateTime.Now.Hour == startHour && DateTime.Now.Minute == startMinute && IsStop == true)
                    {
                        StartTimeEvent();
                        IsStop = false;
                    }
                    else if (DateTime.Now.Hour == stopHour && DateTime.Now.Minute == stopMinute && IsStop == false)
                    {
                        StopTimeEvent();
                    }
                }
                else
                {
                    break;
                }
            }
        }

    }
}
