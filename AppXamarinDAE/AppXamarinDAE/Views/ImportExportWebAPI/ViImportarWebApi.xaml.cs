using AppXamarinDAE.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarinDAE.Views.ImportExportWebAPI
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViImportarWebApi : ContentPage
	{
		public ViImportarWebApi ()
		{
			InitializeComponent ();
            BindingContext = App.FicVmLocator.FicVmImportarWebApi;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmImportarWebApi;
            if (FicViewModel != null)
            {
                FicViewModel.OnAppearing();
            }

        }//SE EJECUTA CUANDO SE ABRE LA VIEW
    }
}