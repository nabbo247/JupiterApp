using JupiterApp.Models;
using JupiterApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JupiterApp.Views
{
    public partial class LiveReportItemPage : ContentPage
    {
        public Item Item { get; set; }

        public LiveReportItemPage()
        {
            InitializeComponent();
            BindingContext = new LiveReportItemViewModel();
        }
    }
}