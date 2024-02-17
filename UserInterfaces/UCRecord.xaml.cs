using FireSharp.Interfaces;
using FireSharp.Response;
using ManageBordingFeeses.Classes;
using RestSharp;
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

namespace ManageBordingFeeses.UserInterfaces
{
    /// <summary>
    /// Interaction logic for UCRecord.xaml
    /// </summary>
    public partial class UCRecord : UserControl
    {
        public UCRecord()
        {
            InitializeComponent();

            BtnBhathi.Visibility = Visibility.Collapsed;
            BtnAkalanka.Visibility = Visibility.Collapsed;
            BtnYasas.Visibility = Visibility.Collapsed;
            BtnBandA.Visibility = Visibility.Collapsed;
            BtnBandY.Visibility = Visibility.Collapsed;
            BtnAandY.Visibility = Visibility.Collapsed;

            FilerFieldsForSelectedButton(6);

        }

        private void BtnBhathi_Click(object sender, RoutedEventArgs e)
        {
            FilerFieldsForSelectedButton(1);
            TBBhathiya.Text = Convert.ToInt32(Convert.ToInt32(TBSpentPrice.Text) / 2).ToString();
            TBAkalanka.Text = "0";
            TBYasas.Text = "0";
        }

        private void BtnAkalanka_Click(object sender, RoutedEventArgs e)
        {
            FilerFieldsForSelectedButton(0);
            TBAkalanka.Text = Convert.ToInt32(Convert.ToInt32(TBSpentPrice.Text) / 2).ToString();
            TBYasas.Text = "0";
            TBBhathiya.Text = "0";
        }

        private void BtnYasas_Click(object sender, RoutedEventArgs e)
        {
            FilerFieldsForSelectedButton(2);
            TBYasas.Text = Convert.ToInt32(Convert.ToInt32(TBSpentPrice.Text) / 2).ToString();
            TBBhathiya.Text = "0";
            TBAkalanka.Text = "0";
        }

        private void BtnBandA_Click(object sender, RoutedEventArgs e)
        {
            FilerFieldsForSelectedButton(3);
            TBBhathiya.Text = Convert.ToInt32(Convert.ToInt32(TBSpentPrice.Text) / 3).ToString();
            TBAkalanka.Text = Convert.ToInt32(Convert.ToInt32(TBSpentPrice.Text) / 3).ToString();
            TBYasas.Text = "0";
        }

        private void BtnBandY_Click(object sender, RoutedEventArgs e)
        {
            FilerFieldsForSelectedButton(5);
            TBBhathiya.Text = Convert.ToInt32(Convert.ToInt32(TBSpentPrice.Text) / 3).ToString();
            TBYasas.Text = Convert.ToInt32(Convert.ToInt32(TBSpentPrice.Text) / 3).ToString();
            TBAkalanka.Text = "0";
        }

        private void BtnAandY_Click(object sender, RoutedEventArgs e)
        {
            FilerFieldsForSelectedButton(4);
            TBYasas.Text = Convert.ToInt32(Convert.ToInt32(TBSpentPrice.Text) / 3).ToString();
            TBAkalanka.Text = Convert.ToInt32(Convert.ToInt32(TBSpentPrice.Text) / 3).ToString();
            TBBhathiya.Text = "0";
        }

        private void CBNameSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBNameSelect.SelectedItem != null)
            {
                string selectedOption = ((ComboBoxItem)CBNameSelect.SelectedItem).Content.ToString();
                FilterButtonsForSelectedEditor(selectedOption);
                FilerFieldsForSelectedButton(6);
            }
        }

        private void FilterButtonsForSelectedEditor(string editor)
        {
            if(editor == "Akalanka")
            {
                BtnBhathi.Visibility = Visibility.Visible;
                BtnAkalanka.Visibility = Visibility.Collapsed;
                BtnYasas.Visibility = Visibility.Visible;
                BtnBandA.Visibility = Visibility.Collapsed;
                BtnBandY.Visibility = Visibility.Visible;
                BtnAandY.Visibility = Visibility.Collapsed;
            }
            else if(editor == "Bhathiya")
            {
                BtnBhathi.Visibility = Visibility.Collapsed;
                BtnAkalanka.Visibility = Visibility.Visible;
                BtnYasas.Visibility = Visibility.Visible;
                BtnBandA.Visibility = Visibility.Collapsed;
                BtnBandY.Visibility = Visibility.Collapsed;
                BtnAandY.Visibility = Visibility.Visible;
            }
            else if(editor == "Yasas")
            {
                BtnBhathi.Visibility = Visibility.Visible;
                BtnAkalanka.Visibility = Visibility.Visible;
                BtnYasas.Visibility = Visibility.Collapsed;
                BtnBandA.Visibility = Visibility.Visible;
                BtnBandY.Visibility = Visibility.Collapsed;
                BtnAandY.Visibility = Visibility.Collapsed;
            }
        }

        //akalanka 0
        //bhathiya 1
        //yasas 2
        //a and b 3
        //a and y 4
        //b and y 5
        private void FilerFieldsForSelectedButton(int value)
        {
            switch (value)
            {
                case 0:
                    PnlYasas.Visibility = Visibility.Collapsed;
                    PnlBhathiya.Visibility = Visibility.Collapsed;
                    PnlAlakanka.Visibility = Visibility.Visible;
                    
                    break;

                case 1:
                    PnlYasas.Visibility = Visibility.Collapsed;
                    PnlBhathiya.Visibility = Visibility.Visible;
                    PnlAlakanka.Visibility = Visibility.Collapsed;
                    break;

                case 2:
                    PnlYasas.Visibility = Visibility.Visible;
                    PnlBhathiya.Visibility = Visibility.Collapsed;
                    PnlAlakanka.Visibility = Visibility.Collapsed;
                    break;

                case 3:
                    PnlYasas.Visibility = Visibility.Collapsed;
                    PnlBhathiya.Visibility = Visibility.Visible;
                    PnlAlakanka.Visibility = Visibility.Visible;
                    break;

                case 4:
                    PnlYasas.Visibility = Visibility.Visible;
                    PnlBhathiya.Visibility = Visibility.Collapsed;
                    PnlAlakanka.Visibility = Visibility.Visible;
                    break;

                case 5:
                    PnlYasas.Visibility = Visibility.Visible;
                    PnlBhathiya.Visibility = Visibility.Visible;
                    PnlAlakanka.Visibility = Visibility.Collapsed;
                    break;

                case 6:
                    PnlYasas.Visibility = Visibility.Collapsed;
                    PnlBhathiya.Visibility = Visibility.Collapsed;
                    PnlAlakanka.Visibility = Visibility.Collapsed;
                    break;


            }
        }

        private async void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {

            string akalankaPrice , bhathiyaPrice , yasasPrice , totalPrice , firebased , toLog = "";

            try
            {
                FirebaseManager firebaseManager = FirebaseManager.Instance;
                IFirebaseClient firebaseClient = firebaseManager.GetFirebaseClient();

                var data = new InsertData
                {
                    Editor = ((ComboBoxItem)CBNameSelect.SelectedItem).Content.ToString(),
                    AkalankaPrice = StringValue(TBAkalanka),
                    Reason = TBReason.Text,
                    BhathiyaPrice = StringValue(TBBhathiya),
                    YasasPrice = StringValue(TBYasas),
                    TotalPrice = StringValue(TBSpentPrice),
                    InsertedDate = DateTime.Now.ToString("dd/MM/yyyy")

                };

                akalankaPrice = StringValue(TBAkalanka).ToString();
                bhathiyaPrice = StringValue(TBBhathiya).ToString();
                yasasPrice = StringValue(TBYasas).ToString();
                totalPrice = StringValue(TBSpentPrice).ToString();

                string space = "            ";

                toLog = $"total :{totalPrice} {space.Substring(totalPrice.Length, space.Length - totalPrice.Length)} | A:{akalankaPrice} {space.Substring(akalankaPrice.Length, space.Length - akalankaPrice.Length)}| B:{bhathiyaPrice} {space.Substring(bhathiyaPrice.Length, space.Length - bhathiyaPrice.Length)}| Y:{yasasPrice} {space.Substring(yasasPrice.Length, space.Length - yasasPrice.Length)} | ";


                ClearDataAfterOneSubmition();

                SetResponse response = await firebaseClient.SetTaskAsync("Records/" + DateTime.Now.ToString("MM/dd") + GererateNumber(), data);
                InsertData reslt = response.ResultAs<InsertData>();

                Dispatcher.Invoke(() =>
                {
                    LblRTransState.Content = "Record In Databse - Success";
                    LblTransDetail.Content = $"Record Editor - {reslt.Editor}";
                    LblTransCost.Content = $"Recorded Price - {reslt.TotalPrice}";
                });

                BdrLastBill.Visibility = Visibility.Visible;
                firebased = "true";






            }
            catch (Exception ex)
            {
                LblRTransState.Content = "Record In Databse - Failed";
                firebased = "false";
            }

            toLog = toLog + $"Is firebase saved : {firebased}";
            Logger.WriteLogOfRecord(((ComboBoxItem)CBNameSelect.SelectedItem).Content.ToString(), toLog);



        }


        private int StringValue(TextBox textBox)
        {
            string returnValue = textBox.Text == null ? "0" : textBox.Text ;
            return Convert.ToInt32(returnValue);
        }

        private void Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Actions.NumberValidation(sender, e);
        }

        private void TBSpentPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private string GererateNumber()
        {
            Random random = new Random();
            int randomNumber = random.Next(10000, 90000);
            return "|" + Convert.ToString(randomNumber);
        }
        private void ClearDataAfterOneSubmition()
        {
            TBAkalanka.Text = "0";
            TBBhathiya.Text = "0";
            TBYasas.Text = "0";
            TBReason.Text = "";
            TBSpentPrice.Text = "0";
        }
    }
}
