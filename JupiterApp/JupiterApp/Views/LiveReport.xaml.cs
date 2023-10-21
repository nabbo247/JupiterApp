using JupiterApp.CommonData;
using JupiterApp.Models;
using JupiterApp.ViewModels;
using JupiterApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JupiterApp.Views
{
    public partial class LiveReport : ContentPage
    {
        LiveReportIViewModel _viewModel;

        public LiveReport()
        {
            InitializeComponent();

            BindingContext = _viewModel = new LiveReportIViewModel("Live Report");
            
        }
        private async void LoginButtonClick(object sender,EventArgs e)
        {
            //Here first complete the login process
            var keyValues = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("username", "EntryUserName.Text"),
                    new KeyValuePair<string, string>("password", "EntryPassword.Text"),
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("response_type", "token"),
                };

            LoginToken loginToken = null;
            var content = new FormUrlEncodedContent(keyValues);

            try
            {

                var response = HelperClass.SendRecord($"{Global.WebApiUrl}/token", content);
                loginToken = JsonConvert.DeserializeObject<LoginToken>(response);

            }
            catch (Exception)
            {
                await DisplayAlert("Invalid", "Provided username and password is incorrect", "Okay");
                //LoginButton.IsEnabled = true;
                return;
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}