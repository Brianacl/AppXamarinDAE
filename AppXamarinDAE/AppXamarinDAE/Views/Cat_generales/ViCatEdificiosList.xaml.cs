using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppXamarinDAE.Data;
using AppXamarinDAE.ViewModels;

namespace AppXamarinDAE.Views.Cat_generales
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViCatEdificiosList : ContentPage
    {
        public ViCatEdificiosList()
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmCatEdificiosList;
            //LoDBContext = new DBContext(DependencyService.Get<IConfigSqlite>().FicGetDataBasePath());
        }

        public ViCatEdificiosList(object FicNavigationContext)
        {
            InitializeComponent();
            BindingContext = App.FicVmLocator.FicVmCatEdificiosList;
            //LoDBContext = new DBContext(DependencyService.Get<IConfigSqlite>().FicGetDataBasePath());
        }

        protected async override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCatEdificiosList;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing();
            }
        }


    }
}