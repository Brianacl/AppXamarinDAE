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
	public partial class ViCatEdificiosDetalle : ContentPage
	{
        private object FicLoParameter { get; set; }

        public ViCatEdificiosDetalle (object FicNavigationContext)
		{
			InitializeComponent ();
            btnEliminar.Clicked += btnEliminar_Clicked;

            FicLoParameter = FicNavigationContext;
            BindingContext = App.FicVmLocator.FicVmCatEdificiosDetalle;
        }

        protected override void OnAppearing()
        {
            var FicViewModel = BindingContext as FicVmCatEdificiosDetalle;
            if (FicViewModel != null) FicViewModel.OnAppearing(FicLoParameter);
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Aviso", "Se va a eliminar este conteo, ¿Está seguro?", "Si", "No");
            if (res)
            {
                var viewModel = BindingContext as FicVmCatEdificiosDetalle;
                viewModel.DeleteCommandExecute();
            }
        }
    }
}