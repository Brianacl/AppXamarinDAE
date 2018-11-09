using AppXamarinDAE.Interfaces;
using AppXamarinDAE.Interfaces.Navegacion;
using AppXamarinDAE.Models;
using AppXamarinDAE.Services;
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
    public class FicVmCatEdificiosItem : FicViewModelBase
    {
        private Eva_cat_edificios Fic_Eva_cat_edificios_item;
        //private ObservableCollection<Eva_cat_edificios> Fic_items_edificios;

        private ICommand FicSaveCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigationCatEdificios IFicSrvNavigationCatEdificios;
        private IFicSrvCatEdificiosList IFicSrvCatEdificiosList;

        public FicVmCatEdificiosItem(IFicSrvNavigationCatEdificios IFicSrvNavigationCatEdificios, IFicSrvCatEdificiosList IFicSrvCatEdificiosList)
        {
            this.IFicSrvNavigationCatEdificios = IFicSrvNavigationCatEdificios;
            this.IFicSrvCatEdificiosList = IFicSrvCatEdificiosList;
        }

        public Eva_cat_edificios Item
        {
            get { return Fic_Eva_cat_edificios_item; }
            set
            {
                Fic_Eva_cat_edificios_item = value;
                RaisePropertyChanged();
            }
        }

        public ICommand FicMetSaveCommand
        {
            get { return FicSaveCommand = FicSaveCommand ?? 
                    new FicVmDelegateCommand(SaveCommandExecute); }
        }

        public ICommand FicMetCancelCommand
        {
            get { return FicCancelCommand = FicCancelCommand ?? new FicVmDelegateCommand(CancelCommandExecute); }
        }

        public async override void OnAppearing(object FicPaNavigationContext)
        {
            try
            {
                var FicEdificioSeleccionado = FicPaNavigationContext as Eva_cat_edificios;
                
                if (FicEdificioSeleccionado != null)
                {
                    Item = FicEdificioSeleccionado;
                }


                base.OnAppearing(FicPaNavigationContext);
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA ITEM", e.Message.ToString(), "OK");
            }
        }

        private async void SaveCommandExecute()
        {
            try
            {
                await IFicSrvCatEdificiosList.FicMetInsertNewEdificio(Item);
                IFicSrvNavigationCatEdificios.FicMetNavigateBack();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "OK");
            }
        }

        private void CancelCommandExecute()
        {
            IFicSrvNavigationCatEdificios.FicMetNavigateBack();
        }
    }//Fin clase
}
