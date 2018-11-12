using AppXamarinDAE.Interfaces.ImportExportWebAPI;
using AppXamarinDAE.Interfaces.Navegacion;
using AppXamarinDAE.ViewModels.Base;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXamarinDAE.ViewModels
{
    public class FicVmExportarWebApi : FicViewModelBase
    {
        private string _FicTextAreaExpEdificios;
        private ICommand _FicMetExpoEdificios;

        private IFicSrvNavigationCatEdificios IFicSrvNavigationCatEdificios;
        private IFicSrvExportarWebApi IFicSrvExportarWebApi;

        public FicVmExportarWebApi(IFicSrvNavigationCatEdificios IFicSrvNavigationCatEdificios, IFicSrvExportarWebApi IFicSrvExportarWebApi)
        {
            this.IFicSrvNavigationCatEdificios = IFicSrvNavigationCatEdificios;
            this.IFicSrvExportarWebApi = IFicSrvExportarWebApi;
        }//CONSTRUCTOR

        public string FicTextAreaExpEdificios
        {
            get { return _FicTextAreaExpEdificios; }
        }

        public async void OnAppearing()
        {

        }//AL INICIAR DE LA VIEW

        public ICommand FicMetExpoEdificios
        {
            get
            {
                return _FicMetExpoEdificios = _FicMetExpoEdificios ??
                      new FicVmDelegateCommand(FicMetExportInventario);
            }
        }//ESTE VENTO AGREGA EL COMANDO AL BOTON EN LA VIEW

        private async void FicMetExportInventario()
        {
            try
            {
                _FicTextAreaExpEdificios = await IFicSrvExportarWebApi.PostExportEdificios();
                RaisePropertyChanged("FicTextAreaExpEdificio");
                await new Page().DisplayAlert("ALERTA", "Datos Actualizados.", "OK");
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }
    }//Fin clase
}
