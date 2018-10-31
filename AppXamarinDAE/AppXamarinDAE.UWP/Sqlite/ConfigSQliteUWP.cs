using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using AppXamarinDAE.Interfaces.Sqlite;
using AppXamarinDAE.UWP.Sqlite;

[assembly: Dependency(typeof(ConfigSQliteUWP))]
namespace AppXamarinDAE.UWP.Sqlite
{
    public class ConfigSQliteUWP
    {
        public string FicGetDataBasePath()
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, AppSettings.FicDataBaseName);
        }
    }
}
