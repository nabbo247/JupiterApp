using JupiterApp.ViewModels;
using JupiterApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JupiterApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            Routing.RegisterRoute(nameof(PriceAlertDetail), typeof(PriceAlertDetail));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(LiveReportItemPage), typeof(LiveReportItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
