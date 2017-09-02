using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace SmartCity.Lib
{
    static class Communication
    {
        private static SerialPort MainPort;
      
        public delegate void DataReceived(string Data);
        public static event DataReceived DataReceivedEventHandler;

        static Communication()
        {
            MainPort = new SerialPort("COM9", 9600);
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
            if (DataReceivedEventHandler != null && MainPort.IsOpen==true)
            {
                DataReceivedEventHandler(MainPort.ReadLine());
            }
        }
    }
}
