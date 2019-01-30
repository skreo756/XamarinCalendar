using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XamarinCalendar.Models;
using XamarinCalendar.ViewModels;

namespace XamarinCalendar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;



           // Console.WriteLine(viewModel.Photo);


        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Event
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}