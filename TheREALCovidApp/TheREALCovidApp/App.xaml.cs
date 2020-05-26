using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TheREALCovidApp.Views;
using TheREALCovidApp.Data;
using SQLite;

namespace TheREALCovidApp
{
    public partial class App : Application
    {
        public static NewsManager NewsManager { get; private set; }
        public static CovidManager CovidManager { get; private set; }

        static ToDoItemDatabase database;
        public App()
        {
            InitializeComponent();
            NewsManager = new NewsManager(new NewsRestService());
            CovidManager = new CovidManager(new CovidRestService());
            MainPage = new MainPage();
        }

        public static ToDoItemDatabase Database
        {
            get
            {
                if(database == null)
                {
                    database = new ToDoItemDatabase();
                }
                return database;
            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
