﻿using AppXamarinDAE.Views.Cat_generales;
using AppXamarinDAE.Views.Navegacion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
                    new FicMasterPageMenuItem { Id = 0, Title = "Lista de Inventarios",
                                                Icon ="ficAlmacen20x20.png",
                                                FicPageName ="FicViInventariosList"
                                                //TargetType = typeof(FicViInventariosList)
                                                },
                    new FicMasterPageMenuItem { Id = 0, Title = "Importacion Web Api",
                                                Icon ="ficAlmacen20x20.png",
                                                FicPageName ="FicViImportarWebApi"
                                                //TargetType = typeof(FicViImportarWebApi)
                                                },
                    new FicMasterPageMenuItem { Id = 0, Title = "Exportar Web Api",
                                                Icon ="ficAlmacen20x20.png",
                                                FicPageName ="FicViExportarWebApi"
                                                //TargetType = typeof(FicViExportarWebApi)
                                                },
                    new FicMasterPageMenuItem { Id = 0, Title = "Lista edificios",
                                                Icon ="ficAlmacen20x20.png",
                                                FicPageName ="FicViCatEdificiosList",
                                                TargetType = typeof(ViCatEdificiosList)
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