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
    public class PriceAlertViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public PriceAlertViewModel(string title = "")
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
                //Wuye%0A2 Wuse%0A3 Garki %0A4 Lokogoma %0A5 Gwarinpa
                var items1 = new List<Item>()
                {
                    new Item { Id = Guid.NewGuid().ToString(), Text = "Wuye", Description="Get price in Wuye" },
                    new Item { Id = Guid.NewGuid().ToString(), Text = "Wusa", Description="Get price in Wusa" },
                    new Item { Id = Guid.NewGuid().ToString(), Text = "Garki", Description="Get price in Garki" },
                    new Item { Id = Guid.NewGuid().ToString(), Text = "Gwarinpa", Description="Get price in Gwarinpa" },
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
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(PriceAlertDetail)}?{nameof(PriceAlertDetailsViewModel.Title)}={item.Id}");
        }
    }
}