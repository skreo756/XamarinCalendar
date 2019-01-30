using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinCalendar.Models;
using XamarinCalendar.Views;
using XamarinCalendar.ViewModels;

namespace XamarinCalendar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel itemsViewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = itemsViewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Event;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
        

        protected override void OnAppearing()
        {


            base.OnAppearing();

            if (itemsViewModel.Items.Count == 0)
                itemsViewModel.LoadItemsCommand.Execute(null);
        }

        




    }
}