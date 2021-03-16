using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JarvisGoogleAPI.Tools
{
    public static class Config
    {
        public static Keys RecordKey = Keys.F12;
        public static string ScreenshotPath = "Screenshots";
        public static DatabaseType DatabaseType = DatabaseType.SQLite;

        public static int Rate = 16000;
        public static string AudioFileName = "demo.wav";
        public static string GoogleAPI = @"https://www.google.com/speech-api/v2/recognize?output=json&lang=ru-RU&key=AIzaSyBOti4mM-6x9WDnZIjIeyEU21OpBXqWBgw";

        public static string EfConnectionString = "Server=(localdb)\\mssqllocaldb; Database=JarvisDB; Trusted_Connection=True";
        public static string SQLiteConnectionString = "Filename=Jarvis.db";

        public static int OnBeepFrequency = 800;
        public static int OffBeepFrequency = 500;
        public static int BeepDuration = 100;

    }

    public enum DatabaseType
    {
        MSSQL,
        SQLite
    }
}
