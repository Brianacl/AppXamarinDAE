using AppXamarinDAE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarinDAE.Views.Cat_generales
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViCatEdificiosItem : ContentPage
    {
        private object FicLoParameter { get; set; }

        public ViCatEdificiosItem(object FicNavigationContext)
        {
            InitializeComponent();
            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmCatEdificiosItem;
            //LoDBContext = new DBContext(DependencyService.Get<IConfigSqlite>().FicGetDataBasePath());
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCatEdificiosItem;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
            
        }
    }
}