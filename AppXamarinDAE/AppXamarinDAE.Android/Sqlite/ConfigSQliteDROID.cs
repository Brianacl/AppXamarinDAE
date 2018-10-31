using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AppXamarinDAE.Interfaces.Sqlite;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using AppXamarinDAE.Droid.Sqlite;

[assembly: Dependency(typeof(ConfigSQliteDROID))]
namespace AppXamarinDAE.Droid.Sqlite
{
    public class ConfigSQliteDROID : IConfigSqlite
    {
        public string FicGetDataBasePath()
        {
            var PathFile = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);
            var DirectorioDB = PathFile.Path + "/CocacolaNay/";
            string PathDB = Path.Combine(DirectorioDB, AppSettings.FicDataBaseName);
            return PathDB;
        }
    }
}