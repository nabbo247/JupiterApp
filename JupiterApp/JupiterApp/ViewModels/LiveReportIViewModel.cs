//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace JupiterApp.ViewModels
//{
//    class LiveReportIViewModel
//    {
//    }
//}
using JupiterApp.Models;
using JupiterApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JupiterApp.ViewModels
{
    public class LiveReportIViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public LiveReportIViewModel(string title = "")
        {
            if (string.IsNullOrEmpty(title))
                Title = "Browse";
            else
                Title = title;
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items1 = new List<Item>()
                {
                    new Item { Id = Guid.NewGuid().ToString(), Text = "Fire outbreak", Description="Report a Fire outbreak in your area ." },
                    new Item { Id = Guid.NewGuid().ToString(), Text = "Long queue station refuse to sell", Description="Report Long queue station refuse to sell" },
                    new Item { Id = Guid.NewGuid().ToString(), Text = "selling product in keg refusing cars Send", Description="Report selling product in keg refusing cars Send" },
                };

                var items = items1;//await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            //LiveReportItemPage.xaml
            await Shell.Current.GoToAsync(nameof(LiveReportItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync(nameof(LiveReportItemPage));
            //await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}