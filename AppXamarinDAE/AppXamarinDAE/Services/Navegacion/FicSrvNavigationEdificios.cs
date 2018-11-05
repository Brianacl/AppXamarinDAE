using AppXamarinDAE.Interfaces.Navegacion;
using AppXamarinDAE.Views.Navegacion;
using AppXamarinDAE.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using AppXamarinDAE.Views.Cat_generales;

namespace AppXamarinDAE.Services.Navegacion
{
    public class FicSrvNavigationEdificios : IFicSrvNavigationCatEdificios
    {
        private IDictionary<Type, Type> FicViewModelRouting = new Dictionary<Type, Type>()
        { 
            //AQUI SE HACE UNA UNION ENTRE LA VM Y VI DE CADA VIEW DE LA APP
            { typeof(FicVmCatEdificiosList),typeof(ViCatEdificiosList) },
            //{ typeof(FicVmInventarioConteoList),typeof(FicMasterPageDetail) },
            //{ typeof(FicVmInventarioConteosItem),typeof(FicMasterPageMaster) },
        };

        #region METODOS DE IMPLEMENTACION DE LA INTERFACE -> IFicSrvNavigationInventario
                public void FicMetNavigateTo<FicTDestinationViewModel>(object FicNavigationContext = null)
                    {
                        Type FicPageType = FicViewModelRouting[typeof(FicTDestinationViewModel)];
                        var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

                        if (FicPage != null)
                        {
                            var mdp = Application.Current.MainPage as MasterDetailPage;
                            mdp.Detail.Navigation.PushAsync(FicPage);
                        }
                }

                public void FicMetNavigateTo(Type FicDestinationType, object FicNavigationContext = null)
                {
                    Type FicPageType = FicViewModelRouting[FicDestinationType];
                    var FicPage = Activator.CreateInstance(FicPageType, FicNavigationContext) as Page;

                    if (FicPage != null)
                    {
                        var mdp = Application.Current.MainPage as MasterDetailPage;
                        mdp.Detail.Navigation.PushAsync(FicPage);
                    }
                }

                public void FicMetNavigateBack()
                {
                    Application.Current.MainPage.Navigation.PopAsync(true);
                }
            #endregion

    }//CLASS
}//NAMESPACE
