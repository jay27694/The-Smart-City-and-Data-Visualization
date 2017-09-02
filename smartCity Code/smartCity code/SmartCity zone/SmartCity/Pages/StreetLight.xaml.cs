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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartCity.Pages
{
    /// <summary>
    /// Interaction logic for StreetLight.xaml
    /// </summary>
    public partial class StreetLight : Page
    {

        Lib.TimeCompare TC = new Lib.TimeCompare();
        Lib.IntensityCompare IC = new Lib.IntensityCompare();

        public StreetLight()
        {
            InitializeComponent();

            Lib.Communication.DataReceivedEventHandler += CommunicationPort_DataReceivedEventHandler;

            TC.StartTimeEvent += TC_StartTimeEvent;
            TC.StopTimeEvent += TC_StopTimeEvent;
            IC.startOnIntensity += TC_StartTimeEvent;
            IC.stopOnIntensity += TC_StopTimeEvent;
        }


        void TC_StopTimeEvent()
        {
            Lib.Communication.Send("0");
            Lbl_Status.Dispatcher.Invoke((Action)delegate
            {
                Lbl_Status.Text = "OFF";
            });
        }

        void TC_StartTimeEvent()
        {
            Lib.Communication.Send("1");
            Lbl_Status.Dispatcher.Invoke((Action)delegate
            {
                Lbl_Status.Text = "ON";
            });
        }

        private void CommunicationPort_DataReceivedEventHandler(string Data)
        {
            try
            {
                String[] sd = Data.Split('|');
                if (sd.Length == 7)
                {

                    lbl_currentIntensity.Dispatcher.Invoke((Action)delegate
                    {
                        try
                        {
                            lbl_currentIntensity.Content = sd[6];
                            IC.setCurrentIntensity(sd[6]);
                        }
                        catch (Exception)
                        {

                        }
                    });
                }
            }
            catch (Exception ex) { }
        }

        //manually method
        private void btn_Manual_Click(object sender, MouseButtonEventArgs e)
        {
            txt_StopTime.IsEnabled = false;
            txt_StartTime.IsEnabled = false;
            txt_LUX.IsEnabled = false;
            img_Off.IsEnabled = true;
            img_On.IsEnabled = true;
            txt_StartTimeMin.IsEnabled = false;
            txt_StopTimeMin.IsEnabled = false;
            Lib.TimeCompare.flag = true;
            Lib.IntensityCompare.flag = true;
        }

        private void btn_startStreet(object sender, MouseButtonEventArgs e)
        {
            TC_StartTimeEvent();
        }

        private void btn_stopStreet(object sender, MouseButtonEventArgs e)
        {
            TC_StopTimeEvent();
        }

        //by time
        private void btn_bytimeClick(object sender, MouseButtonEventArgs e)
        {
            txt_StopTime.IsEnabled = true;
            txt_StartTime.IsEnabled = true;
            txt_LUX.IsEnabled = false;
            img_Off.IsEnabled = false;
            img_On.IsEnabled = false;
            txt_StartTimeMin.IsEnabled = true;
            txt_StopTimeMin.IsEnabled = true;
            Lib.IntensityCompare.flag = true;
        }

       

        private void on_ByTime_Ok_Click(object sender, RoutedEventArgs e)
        {
            byte startHour = byte.Parse(txt_StartTime.Text);
            byte startMin = byte.Parse(txt_StartTimeMin.Text);
            byte stopHour = byte.Parse(txt_StopTime.Text);
            byte stopMin = byte.Parse(txt_StopTimeMin.Text);
            Lib.TimeCompare.flag = false;
            TC.setTime(startHour, startMin, stopHour, stopMin);
        }


        //by intensity
        private void btn_byIntensity(object sender, MouseButtonEventArgs e)
        {
            txt_LUX.IsEnabled = true;
            txt_StopTime.IsEnabled = false;
            txt_StartTime.IsEnabled = false;
            img_Off.IsEnabled = false;
            img_On.IsEnabled = false;
            txt_StartTimeMin.IsEnabled = false;
            txt_StopTimeMin.IsEnabled = false;
            Lib.TimeCompare.flag = true;

        }
        private void onluxOkClick(object sender, RoutedEventArgs e)
        {
            Lib.IntensityCompare.flag = false;
            IC.setIntensity(txt_LUX.Text);
        }

       
    }
}
