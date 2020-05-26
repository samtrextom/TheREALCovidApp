using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TheREALCovidApp
{
    public class Constants
    {

        public static string NewsUrl = "https://newsapi.org/v2/top-headlines?country=us&apiKey=ddb5407d46614c1c8224a2fa4b0c8d31";
        public static string CovidUsUrl = "https://covidtracking.com/api/v1/us/current.json";
        public static string CovidUsByDateUrl = "https://covidtracking.com/api/v1/us/";
        public static string CovidStateUrl = "https://covidtracking.com/api/v1/states/WI/current.json";
        public static string CovidStateByDateUrl = "https://covidtracking.com/api/v1/states/WI/";

        public const string DatabaseFilename = "TodoSQLite.db4";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
