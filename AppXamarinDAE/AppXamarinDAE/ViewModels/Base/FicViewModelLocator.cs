using AppXamarinDAE.Interfaces.Navegacion;
using AppXamarinDAE.Interfaces;
using AppXamarinDAE.Services;
using AppXamarinDAE.Services.Navegacion;
using Autofac;
using AppXamarinDAE.Services.ImportExportWebAPI;
using AppXamarinDAE.Interfaces.ImportExportWebAPI;

namespace AppXamarinDAE.ViewModels.Base
{
    public class FicViewModelLocator
    {
        private static IContainer FicIContainer;

        public FicViewModelLocator()
        {
            //FIC: ContainerBuilder es una clase de la libreria de Autofac para poder ejecutar la interfaz en las diferentes plataformas 
            var FicContainerBuilder = new ContainerBuilder();

            //-------------------------------- VIEW MODELS ------------------------------------------------------
            //FIC: se procede a registrar las ViewModels para que se puedan mandar llamar en cualquier plataforma
            //---------------------------------------------------------------------------------------------------
            FicContainerBuilder.RegisterType<FicVmCatEdificiosList>();
            FicContainerBuilder.RegisterType<FicVmCatEdificiosItem>();
            FicContainerBuilder.RegisterType<FicVmCatEdificiosDetalle>();
            FicContainerBuilder.RegisterType<FicVmExportarWebApi>();
            FicContainerBuilder.RegisterType<FicVmImportarWebApi>();

            //------------------------- INTERFACE SERVICES OF THE VIEW MODELS -----------------------------------
            //FIC: se procede a registrar la interface con la que se comunican las ViewModels con los Servicios 
            //para poder ejecutar las tareas (metodos o funciones, etc) del servicio en cuestion.
            //---------------------------------------------------------------------------------------------------
            FicContainerBuilder.RegisterType<FicSrvNavigationEdificios>().As<IFicSrvNavigationCatEdificios>().SingleInstance();
            FicContainerBuilder.RegisterType<SrvCatEdificiosList>().As<IFicSrvCatEdificiosList>().SingleInstance();
            FicContainerBuilder.RegisterType<SrvExportarWebApi>().As<IFicSrvExportarWebApi>().SingleInstance();
            FicContainerBuilder.RegisterType<SrvImportarWebApi>().As<IFicSrvImportarWebApi>().SingleInstance();
            //FIC: se asigna o se libera el contenedor
            //-------------------------------------------
            if (FicIContainer != null) FicIContainer.Dispose();

            FicIContainer = FicContainerBuilder.Build();
        }//CONSTRUCTOR

        //-------------------- CONTROL DE INVENTARIOS ------------------------
        //FIC: se manda llamar desde el backend de la View de List
        public FicVmCatEdificiosList FicVmCatEdificiosList
        {
            get { return FicIContainer.Resolve<FicVmCatEdificiosList>(); }
        }

        public FicVmCatEdificiosItem FicVmCatEdificiosItem
        {
            get { return FicIContainer.Resolve<FicVmCatEdificiosItem>(); }
        }

        public FicVmCatEdificiosDetalle FicVmCatEdificiosDetalle
        {
            get { return FicIContainer.Resolve<FicVmCatEdificiosDetalle>(); }
        }

        public FicVmExportarWebApi FicVmExportarWebApi
        {
            get { return FicIContainer.Resolve<FicVmExportarWebApi>(); }
        }

        public FicVmImportarWebApi FicVmImportarWebApi
        {
            get { return FicIContainer.Resolve<FicVmImportarWebApi>(); }
        }
    }//Fin clase
}//NAMESPACE
