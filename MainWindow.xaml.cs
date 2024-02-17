using ManageBordingFeeses.UserInterfaces;
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


using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using ManageBordingFeeses.Classes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ManageBordingFeeses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            FirebaseManager firebaseManager = FirebaseManager.Instance;
            IFirebaseClient firebaseClient = firebaseManager.GetFirebaseClient();
            GetConState(firebaseClient);


            UCRecord uCRecord = new UCRecord();
            GrdRecord.Children.Add(uCRecord);


            UCDashboard uCDashboard = new UCDashboard();
            GrdDashboard.Children.Add(uCDashboard);

            this.Dispatcher.Invoke(() =>
            {
                LblHello.Content = SayGreetingBasedOnTime();
            });
        }


        private string SayGreetingBasedOnTime()
        {
            DateTime currentTime = DateTime.Now;
            string greeting = "";

            string day = currentTime.ToString("dddd, MMMM dd, yyyy");

            if (currentTime.Hour >= 6 && currentTime.Hour < 12)
            {
                greeting = "Good Morning";
            }
            else if (currentTime.Hour >= 12 && currentTime.Hour < 18)
            {
                greeting = "Good Afternoon";
            }
            else
            {
                greeting = "Good Night";
            }

            return $"Welcome and {greeting}! Today is {day}";
        }


        private void BtnFirebaseConnect_Click(object sender, RoutedEventArgs e)
        {
            FirebaseManager firebaseManager = FirebaseManager.Instance;
            IFirebaseClient firebaseClient = firebaseManager.GetFirebaseClient();
            
            GetConState(firebaseClient);

        }


        private async void GetConState(IFirebaseClient firebaseClient)
        {
            string message = "";
            try
            {
                FirebaseResponse firebaseResponse = await firebaseClient.GetTaskAsync($"Connection");

                if (firebaseResponse != null)
                {
                    string json = firebaseResponse.Body;
                    string jsonValue = JsonConvert.DeserializeObject<string>(json);

                    if (jsonValue == "yes")
                    {
                        message = "Success";
                    }
                    else
                    {
                        message = "Failed";
                    }
                }
                else
                {
                    message = "Failed";
                }
            }
            catch (Exception ex)
            {
                message = "Error";
            }

            LblConState.Content = $"Firebase Connection State : {message}";
        }
    }
}
