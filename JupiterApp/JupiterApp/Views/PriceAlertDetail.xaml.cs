/*using JupiterApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace JupiterApp.Views
{
    public partial class PriceAlertDetail : ContentPage
    {
        public PriceAlertDetail()
        {
            InitializeComponent();
            BindingContext = new PriceAlertDetailsViewModel();
        }
    }
}
*/
using JupiterApp.Models;
using JupiterApp.ViewModels;
using JupiterApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JupiterApp.Views
{
    public partial class PriceAlertDetail : ContentPage
    {
        PriceAlertDetailsViewModel _viewModel;

        public PriceAlertDetail()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PriceAlertDetailsViewModel("Price Alert");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}