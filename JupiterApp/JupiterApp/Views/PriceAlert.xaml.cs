﻿using JupiterApp.Models;
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
    public partial class PriceAlert : ContentPage
    {
        PriceAlertViewModel _viewModel;

        public PriceAlert()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PriceAlertViewModel("Price Alert");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}