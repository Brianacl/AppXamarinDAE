using System;
using System.IO;
using Xamarin.Forms;
using AppXamarinDAE.iOS.SQlite;
using AppXamarinDAE.Interfaces.Sqlite;

[assembly: Dependency(typeof(ConfigSQliteIOS))]
namespace AppXamarinDAE.iOS.SQlite
{
    public class ConfigSQliteIOS : IConfigSqlite
    {
        public string FicGetDataBasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if(!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, AppSettings.FicDataBaseName);
        }
    }
}