using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
namespace SmartCity.Lib
{
    static class Communication
    {
        private static SerialPort MainPort;
      
        public delegate void DataReceived(string Data);
        public static event DataReceived DataReceivedEventHandler;

        static Communication()
        {
            MainPort = new SerialPort("COM12", 9600);
            MainPort.Open();
            MainPort.DataReceived += MainPort_DataReceived;
        }
        

        public static void Send(string Data)
        {
            MainPort.WriteLine(Data);
        }
        public static void close()
        {
            if (MainPort.IsOpen)
            {
                MainPort.Close();
            } 
        }
       
        static void MainPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
              
            String d = MainPort.ReadLine();          
            MainPort.DiscardInBuffer();
            Thread.Sleep(300);
            DataReceivedEventHandler(d);
        }
    }
}
