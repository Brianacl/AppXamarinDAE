using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using AppXamarinDAE.Interfaces.Sqlite;
using AppXamarinDAE.UWP.Sqlite;
using System.Diagnostics;

[assembly: Dependency(typeof(ConfigSQliteUWP))]
namespace AppXamarinDAE.UWP.Sqlite
{
    public class ConfigSQliteUWP : IConfigSqlite
    {
        public string FicGetDataBasePath()
        {
            Debug.WriteLine(Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.FicDataBaseName));
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.FicDataBaseName);
        }
    }
}
