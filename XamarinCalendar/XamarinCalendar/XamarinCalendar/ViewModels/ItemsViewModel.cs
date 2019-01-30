using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using XamarinCalendar.Models;
using XamarinCalendar.Views;

namespace XamarinCalendar.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Event> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Console.WriteLine("ITEMSVIEWMODEL");
            Title = "Browse";
            Items = new ObservableCollection<Event>();
            LoadItemsCommand = new Command(async () => await LoadItems());
        }




        public async Task LoadItems()
        {

            Console.WriteLine("LOADITEMS");
            Items.Clear();

            var items = await Task.FromResult(DataBase.GetAllEvents());

            Console.WriteLine("ITEMS : ");
            Console.WriteLine(items);


            foreach (var item in items)
            {
                Console.WriteLine("efzfefzfefzfe");
                Console.WriteLine(item.Debut);
                Console.WriteLine(item.Fin);
                Console.WriteLine(item.Image);

                    
                Items.Add(item);
            }

        }
    }
}