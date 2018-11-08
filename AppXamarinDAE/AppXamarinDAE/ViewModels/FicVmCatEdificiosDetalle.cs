﻿using AppXamarinDAE.Interfaces;
using AppXamarinDAE.Interfaces.Navegacion;
using AppXamarinDAE.Models;
using AppXamarinDAE.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppXamarinDAE.ViewModels
{
    public class FicVmCatEdificiosDetalle : FicViewModelBase
    {
        private Eva_cat_edificios Fic_Eva_cat_edificios_item;
        //private ObservableCollection<Eva_cat_edificios> Fic_items_edificios;

        private ICommand FicDeleteCommand;
        private ICommand FicCancelCommand;

        private IFicSrvNavigationCatEdificios IFicSrvNavigationCatEdificios;
        private IFicSrvCatEdificiosList IFicSrvCatEdificiosList;

        public FicVmCatEdificiosDetalle(IFicSrvNavigationCatEdificios IFicSrvNavigationCatEdificios, IFicSrvCatEdificiosList IFicSrvCatEdificiosList)
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

        public ICommand FicMetDeleteCommand
        {
            get
            {
                return FicDeleteCommand = FicDeleteCommand ??
                  new FicVmDelegateCommand(DeleteCommandExecute);
            }
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


                System.Diagnostics.Debug.WriteLine("Esta wea --> "+FicEdificioSeleccionado.IdEdificio);
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

        public async void DeleteCommandExecute()
        {
            try
            {
                await IFicSrvCatEdificiosList.FicMetDeleteEdificio(Item);
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