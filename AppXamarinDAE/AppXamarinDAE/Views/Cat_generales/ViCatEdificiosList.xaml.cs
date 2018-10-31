using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppXamarinDAE.Data;
using AppXamarinDAE.Interfaces.Sqlite;

namespace AppXamarinDAE.Views.Cat_generales
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViCatEdificiosList : ContentPage
    {

        private readonly DBContext LoDBContext;

        public ViCatEdificiosList()
        {
            InitializeComponent();

            //LoDBContext = new DBContext(DependencyService.Get<IConfigSqlite>().FicGetDataBasePath());
        }
    }
}