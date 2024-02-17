using FireSharp.Interfaces;
using FireSharp.Response;
using ManageBordingFeeses.Classes;
using Newtonsoft.Json;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManageBordingFeeses.UserInterfaces
{
    /// <summary>
    /// Interaction logic for UCDashboard.xaml
    /// </summary>
    public partial class UCDashboard : UserControl
    {
        private FirebaseManager _firebaseManager;
        private IFirebaseClient _firebaseClient;

        private int _akalankaToBhathiya;
        private int _akalankaToYasas;
        private int _bhathiyaToAkalanka;
        private int _bhathiyaToYasas;
        private int _yasasToBhathiya;
        private int _yasasToAkalanka;

        private int _fromBhathiyaToAkalanka;
        private int _fromYasasToAkalanka;
        private int _fromAkalankaToBhathiya;
        private int _fromYasasToBhathiya;
        private int _fromBhathiyaToYasas;
        private int _fromAkalankaToYasas;


        public UCDashboard()
        {
         
            _firebaseManager = FirebaseManager.Instance;
            _firebaseClient = _firebaseManager.GetFirebaseClient();

            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void CBMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedMonth = ((ComboBoxItem)CBMonth.SelectedItem).Content.ToString();
            SelectTotalValue("Akalanka", selectedMonth, LblTotal_A, "c2");
            SelectTotalValue("Bhathiya", selectedMonth, LblTotal_B, "c1");
            SelectTotalValue("Yasas", selectedMonth, LblTotal_Y, "c3");
        }

        //select total 
        private async void SelectTotalValue(string editor, string month, Label label, string key)
        {
            try
            {
                FirebaseResponse firebaseResponse = await _firebaseClient.GetTaskAsync($"Records/{month}");
                if (firebaseResponse.Body != "null")
{
                    var records = JsonConvert.DeserializeObject<Dictionary<string, RecordOfJSON>>(firebaseResponse.Body);

                    int totalPriceSum = 0;
                    int totalPriceAkalanka = 0;
                    int totalPriceBhathiya = 0;
                    int totalPriceYasas = 0;

                    foreach (var kvp in records)
                    {
                        if (kvp.Value.Editor == editor)
                        {
                            totalPriceSum += kvp.Value.TotalPrice;
                            totalPriceAkalanka += kvp.Value.AkalankaPrice;
                            totalPriceBhathiya += kvp.Value.BhathiyaPrice;
                            totalPriceYasas += kvp.Value.YasasPrice;
                        }
                        
                    }

                    label.Content = totalPriceSum.ToString();
                    AssignValuesOfTo(key, totalPriceAkalanka, totalPriceBhathiya, totalPriceYasas);
                    CalculateFromHowMuchNeed();
                    ShowBalanceInLabels();

                }
                else
                {
                    MessageBox.Show("select Valid Month");
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            
        }

        //c1 = yasas,akalanka
        //c2 = yasas, bhathiya
        //c3 = akalanka, bhathiya
        private void AssignValuesOfTo(string combination, int value_A, int value_B, int value_Y)
        {
            switch (combination)
            {
                case "c1":
                    _bhathiyaToAkalanka = value_A;
                    _bhathiyaToYasas = value_Y;
                    break;

                case "c2":
                    _akalankaToBhathiya = value_B;
                    _akalankaToYasas = value_Y;
                    break;

                case "c3":
                    _yasasToBhathiya = value_B;
                    _yasasToAkalanka = value_A;
                    break;
            }
        }



        private void CalculateFromHowMuchNeed()
        {
            _fromBhathiyaToAkalanka = ((_akalankaToBhathiya - _bhathiyaToAkalanka) > 0) ? _akalankaToBhathiya - _bhathiyaToAkalanka : 0;
            _fromYasasToAkalanka = ((_akalankaToYasas - _yasasToAkalanka) > 0) ? _akalankaToYasas - _yasasToAkalanka : 0;

            _fromAkalankaToBhathiya = ((_bhathiyaToAkalanka - _akalankaToBhathiya) > 0) ? _bhathiyaToAkalanka - _akalankaToBhathiya : 0;
            _fromYasasToBhathiya = ((_bhathiyaToYasas - _yasasToBhathiya) > 0) ? _bhathiyaToYasas - _yasasToBhathiya : 0;

            _fromAkalankaToYasas = ((_yasasToAkalanka - _akalankaToYasas) > 0) ? _yasasToAkalanka - _akalankaToYasas : 0;
            _fromBhathiyaToYasas = ((_yasasToBhathiya - _bhathiyaToYasas) > 0) ? _yasasToBhathiya - _bhathiyaToYasas : 0;

        }

        private void ShowBalanceInLabels()
        {
            Dispatcher.Invoke(() =>
            {
                LblBhathi_A.Content = _fromBhathiyaToAkalanka.ToString();
                LblYasas_A.Content = _fromYasasToAkalanka.ToString();

                LblAkalanka_B.Content = _fromAkalankaToBhathiya.ToString();
                LblYasas_B.Content = _fromYasasToBhathiya.ToString();

                LblAkalanka_Y.Content = _fromAkalankaToYasas.ToString();
                LblBhathi_Y.Content = _fromBhathiyaToYasas.ToString();
            });
            


        }

    }
}
