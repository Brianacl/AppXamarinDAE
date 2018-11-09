using AppXamarinDAE.Interfaces;
using AppXamarinDAE.Interfaces.Navegacion;
using AppXamarinDAE.Models;
using AppXamarinDAE.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXamarinDAE.ViewModels
{
    public class FicVmCatEdificiosList : FicViewModelBase
    {
        public ObservableCollection<Eva_cat_edificios> _FicSfDataGrid_ItemSource_CatEdificios;
        public Eva_cat_edificios _FicSfDataGrid_SelectItem_CatEdificios;
        private ICommand _FicMetAddEdificioICommand, _FicMetEditEdificioICommand;
        private ICommand _FicMetDetalleICommand;
        private ICommand _FicMetDeleteICommand;

        private IFicSrvNavigationCatEdificios IFicSrvNavigationCatEdificios;
        private IFicSrvCatEdificiosList IFicSrvCatEdificiosList;

        public FicVmCatEdificiosList(IFicSrvNavigationCatEdificios IFicSrvNavigationCatEdificios, IFicSrvCatEdificiosList IFicSrvCatEdificiosList)
        {
            this.IFicSrvNavigationCatEdificios = IFicSrvNavigationCatEdificios;
            this.IFicSrvCatEdificiosList = IFicSrvCatEdificiosList;
            _FicSfDataGrid_ItemSource_CatEdificios = new ObservableCollection<Eva_cat_edificios>();
        }

        public ObservableCollection<Eva_cat_edificios> FicSfDataGrid_ItemSource_CatEdificios
        {
            get
            {
                return _FicSfDataGrid_ItemSource_CatEdificios;
            }

            set
            {
                if (_FicSfDataGrid_ItemSource_CatEdificios != value)
                {
                    _FicSfDataGrid_ItemSource_CatEdificios = value;
                    RaisePropertyChanged();
                }
            }
        }//ESTE APUNTA A TRAVÉS DEL BindingContext AL GRID DE LA VIEW

        public Eva_cat_edificios FicSfDataGrid_SelectItem_CatEdificios
        {
            get
            {
                return _FicSfDataGrid_SelectItem_CatEdificios;
            }
            set
            {
                if (value != null)
                {
                    _FicSfDataGrid_SelectItem_CatEdificios = value;
                    RaisePropertyChanged();
                }
            }//ITEM SELECCIONADO
        }

        public ICommand FicMetAddEdificioICommand
        {
            get
            {
                return _FicMetAddEdificioICommand = _FicMetAddEdificioICommand ??
                    new FicVmDelegateCommand(FicMetAddEdificio);
            }
        }

        public ICommand FicMetDeleteICommand
        {
            get
            {
                return _FicMetDeleteICommand = _FicMetDeleteICommand ??
                    new FicVmDelegateCommand(FicMetDeleteEdificio);
            }
        }

        public ICommand FicMetDetalleICommand
        {
            get
            {
                return _FicMetDetalleICommand = _FicMetDetalleICommand ??
                    new FicVmDelegateCommand(FicMetDetalleEdificio);
            }
        }

        public ICommand FicMetEditarEdificioICommand
        {
            get
            {
                return _FicMetEditEdificioICommand = _FicMetEditEdificioICommand ??
                    new FicVmDelegateCommand(FicMetEditEdificio);
            }
        }

        private void FicMetAddEdificio()
        {
            IFicSrvNavigationCatEdificios.FicMetNavigateTo<FicVmCatEdificiosItem>
                    (new Eva_cat_edificios());
        }

        private async void FicMetDeleteEdificio()
        {
            try
            {
                if (_FicSfDataGrid_SelectItem_CatEdificios != null)
                {
                    await IFicSrvCatEdificiosList.FicMetDeleteEdificio(_FicSfDataGrid_SelectItem_CatEdificios);
                    _FicSfDataGrid_SelectItem_CatEdificios = null;
                }
                else
                    await new Page().DisplayAlert("ALERTA", "Para eliminar un registro,  primero seleccione un registro", "OK");
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        private async void FicMetEditEdificio()
        {
            if (_FicSfDataGrid_SelectItem_CatEdificios != null)
                IFicSrvNavigationCatEdificios.FicMetNavigateTo<FicVmCatEdificiosItem>
                    (_FicSfDataGrid_SelectItem_CatEdificios);
            else
                await new Page().DisplayAlert("ALERTA", "Para editar,  primero seleccione un registro", "OK");
        }

        private async void FicMetDetalleEdificio()
        {
            if (_FicSfDataGrid_SelectItem_CatEdificios != null)
            {
                //System.Diagnostics.Debug.WriteLine(_FicSfDataGrid_SelectItem_CatEdificios.IdEdificio);
                IFicSrvNavigationCatEdificios.FicMetNavigateTo<FicVmCatEdificiosDetalle>
                    (_FicSfDataGrid_SelectItem_CatEdificios);
            }
            else
                await new Page().DisplayAlert("ALERTA", "Para ver el detalle, primero seleccione un registro", "OK");
        }

        public async override void OnAppearing(object context)
        {
            try
            {
                FicSfDataGrid_ItemSource_CatEdificios.Clear();

                var source_local_inv = await IFicSrvCatEdificiosList.FicMetGetListEdificios();

                if (source_local_inv != null)
                {
                    foreach (Eva_cat_edificios inv in source_local_inv)
                    {
                        FicSfDataGrid_ItemSource_CatEdificios.Add(inv);
                    }
                }//No llena el grid, llena el observableCollection para poder hacer el binding
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//SOBRECARGA AL METODO OnAppearing() DE LA VIEW
    }
}
