/*using JupiterApp.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JupiterApp.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class PriceAlertDetailsViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        public string Id { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}*/
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
    public class PriceAlertDetailsViewModel : BaseViewModel
    {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public PriceAlertDetailsViewModel(string title = "")
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
                //%0A1 Oando Filling Station N616 %0A2 Danmarna Petrol Station Wuye N620 %0A3 Eterna filling station N625 %0A4 AYM shafa petrol station N629%0A5 AHMIS Nigeria Limited N630%0A
                var items1 = new List<Item>()
                {
                    new Item { Id = Guid.NewGuid().ToString(), Text = "Oando Filling Station", Description="N616.00" },
                    new Item { Id = Guid.NewGuid().ToString(), Text = "Danmarna Petrol Station Wuye", Description="N620.00" },
                    new Item { Id = Guid.NewGuid().ToString(), Text = "Eterna filling station", Description="N625.00" },
                    new Item { Id = Guid.NewGuid().ToString(), Text = "AYM shafa petrol station", Description="N629.00" },
                    new Item { Id = Guid.NewGuid().ToString(), Text = "AHMIS Nigeria Limited", Description="N630.00" },
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
            //await Shell.Current.GoToAsync($"{nameof(PriceAlertDetail)}?{nameof(PriceAlertDetailsViewModel.ItemId)}={item.Id}");
        }
    }
}