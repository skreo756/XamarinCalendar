using System;

namespace XamarinCalendar.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }       
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }
        public DateTime Debut { get; set; }  
        public DateTime Fin { get; set; }
        public string Image { get; set; }
    }
}