using AppXamarinDAE.Views.Cat_generales;
using AppXamarinDAE.Views.ImportExportWebAPI;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarinDAE.Views.Navegacion
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FicMasterPageMaster : ContentPage
    {
        public ListView ListView;

        public FicMasterPageMaster()
        {
            InitializeComponent();

            BindingContext = new FicMasterPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class FicMasterPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FicMasterPageMenuItem> MenuItems { get; }

            public FicMasterPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<FicMasterPageMenuItem>(new[]
                {
                    new FicMasterPageMenuItem { Id = 0, Title = "Lista edificios",
                                                Icon ="ficAlmacen20x20.png",
                                                FicPageName ="ViCatEdificiosList",
                                                TargetType = typeof(ViCatEdificiosList)
                                                },
                    new FicMasterPageMenuItem { Id = 0, Title = "Exportar API",
                                                Icon ="ficAlmacen20x20.png",
                                                FicPageName ="ViExportarWebApi",
                                                TargetType = typeof(ViExportarWebApi)
                                                },
                    new FicMasterPageMenuItem { Id = 0, Title = "Importar API",
                                                Icon ="ficAlmacen20x20.png",
                                                FicPageName ="ViImportarWebApi",
                                                TargetType = typeof(ViImportarWebApi)
                                                }

                });
            }//CONSTRUCTOR

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }//CLASS FicMasterPageMasterViewModel
    }//CLASS FicMasterPageMaster
}//NAMESPACE