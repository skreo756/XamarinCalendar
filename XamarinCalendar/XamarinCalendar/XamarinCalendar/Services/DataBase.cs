using SQLite;
using System;
using System.Collections.Generic;
using XamarinCalendar.Models;
using System.IO;
using System.Text;
using System.Threading.Tasks;
 // using static Android.App.Usage.UsageEvents;
namespace XamarinCalendar

{
    public static class DataBase
    {
        private static SQLiteConnection sqliteConnection = new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EventDatabase.db"));


        static DataBase()
        {
            sqliteConnection.CreateTable<Event>();
        }

        public static void InsertEvent(Event eventToInsert)
        {
            Console.WriteLine(eventToInsert.Debut);
            sqliteConnection.Insert(eventToInsert);
        }

        public static Event[] GetAllEvents()
        {
            RemoveOldEvents();
            return sqliteConnection.Table<Event>().ToArray();
        }

        private static void RemoveOldEvents()
        {
            sqliteConnection.Execute("DELETE FROM Event WHERE Debut < " + DateTime.Now.Ticks + "; ");
        }
    }
}
