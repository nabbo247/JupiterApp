
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
    public partial class ReportInfraction : ContentPage
    {
        ReportInfractionViewModel _viewModel;

        public ReportInfraction()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ReportInfractionViewModel("Report Inftraction");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}