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
    public class FicVmCatEdificiosList : INotifyPropertyChanged
    {
        public ObservableCollection<Eva_cat_edificios> _FicSfDataGrid_ItemSource_CatEdificios;
        public Eva_cat_edificios _FicSfDataGrid_SelectItem_CatEdificios;
        private ICommand _FicMetAddEdificioICommand, _FicMetAcumuladosICommand;

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

        private void FicMetAddEdificio()
        {
            if(_FicSfDataGrid_SelectItem_CatEdificios != null)
            {
                IFicSrvNavigationCatEdificios.FicMetNavigateTo<FicVmCatEdificiosList>
                    (_FicSfDataGrid_SelectItem_CatEdificios);
            }
        }

        public async void OnAppearing()
        {
            try
            {
                var source_local_inv = await IFicSrvCatEdificiosList.FicMetGetListEdificios();

                if (source_local_inv != null)
                {
                    foreach (Eva_cat_edificios inv in source_local_inv)
                    {
                        FicSfDataGrid_ItemSource_CatEdificios.Add(inv);
                    }
                }//Llena el GRID
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }//SOBRECARGA AL METODO OnAppearing() DE LA VIEW

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
