using AppXamarinDAE.Interfaces.ImportExportWebAPI;
using AppXamarinDAE.Interfaces.Navegacion;
using AppXamarinDAE.ViewModels.Base;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXamarinDAE.ViewModels
{
    public class FicVmImportarWebApi : FicViewModelBase
    {
        private string _FicTextAreaImpEdificio, _FicLabelIdEdificio;
        private ICommand _FicMecImportIdEdificio, _FicMecImportEdificio, _FicMecImportCat;

        private IFicSrvNavigationCatEdificios IFicSrvNavigationCatEdificios;
        private IFicSrvImportarWebApi IFicSrvImportarWebApi;
        public FicVmImportarWebApi(IFicSrvNavigationCatEdificios IFicSrvNavigationCatEdificios, IFicSrvImportarWebApi IFicSrvImportarWebApi)
        {
            this.IFicSrvNavigationCatEdificios = IFicSrvNavigationCatEdificios;
            this.IFicSrvImportarWebApi = IFicSrvImportarWebApi;
        }//CONSTRUCTOR

        public string FicTextAreaImpEdificio
        {
            get { return _FicTextAreaImpEdificio; }
        }

        public string FicLabelIdEdificio
        {
            get { return _FicLabelIdEdificio; }
            set
            {
                if (value != null) _FicLabelIdEdificio = value;
            }
        }

        public async void OnAppearing()
        {

        }//METODO QUE SE MANDA A LLAMAR EN LA VIEW

        public ICommand FicMecImportIdEdificio
        {
            get
            {
                return _FicMecImportIdEdificio = _FicMecImportIdEdificio ??
                      new FicVmDelegateCommand(FicMecImportEdificioId);
            }
        }//ESTE VENTO AGREGA EL COMANDO AL BOTON EN LA VIEW

        private async void FicMecImportEdificioId()
        {
            try
            {
                if (_FicLabelIdEdificio.Length > 0)
                {
                    _FicTextAreaImpEdificio = await IFicSrvImportarWebApi.FicGetImportEdificios(int.Parse(_FicLabelIdEdificio));
                    RaisePropertyChanged("FicTextAreaImpEdificio");
                    await new Page().DisplayAlert("ALERTA", "Datos Actualizados.", "OK");
                }
                else await new Page().DisplayAlert("ALERTA", "ID NO VALIDO.", "OK");

            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        public ICommand FicMecImportEdificio
        {
            get
            {
                return _FicMecImportEdificio = _FicMecImportEdificio ??
                      new FicVmDelegateCommand(FicMetodoImportEdificio);
            }
        }//ESTE VENTO AGREGA EL COMANDO AL BOTON EN LA VIEW

        private async void FicMetodoImportEdificio()
        {
            try
            {
                _FicTextAreaImpEdificio = await IFicSrvImportarWebApi.FicGetImportEdificios();
                RaisePropertyChanged("FicTextAreaImpEdificio");
                await new Page().DisplayAlert("ALERTA", "Datos Actualizados.", "OK");
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        /*
        public ICommand FicMecImportCat
        {
            get
            {
                return _FicMecImportCat = _FicMecImportCat ??
                      new FicVmDelegateCommand(FicMecImportCatalogo);
            }
        }//ESTE VENTO AGREGA EL COMANDO AL BOTON EN LA VIEW

        private async void FicMecImportCatalogo()
        {
            try
            {
                _FicTextAreaImpEdificio = await IFicSrvImportarWebApi.FicGetImportCatalogos();
                RaisePropertyChanged("FicTextAreaImpInv");
                await new Page().DisplayAlert("ALERTA", "Datos Actualizados.", "OK");
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }*/
    }//Fin clase
}
