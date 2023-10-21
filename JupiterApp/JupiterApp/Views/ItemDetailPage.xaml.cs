using JupiterApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace JupiterApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}