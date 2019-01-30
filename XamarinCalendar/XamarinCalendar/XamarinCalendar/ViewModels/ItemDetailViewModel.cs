using System;

using XamarinCalendar.Models;

namespace XamarinCalendar.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Event Item { get; set; }
        public ItemDetailViewModel(Event item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
