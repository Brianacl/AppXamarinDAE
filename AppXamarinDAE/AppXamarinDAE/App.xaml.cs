using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppXamarinDAE.Views.Cat_generales;
using AppXamarinDAE.Views.Navegacion;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppXamarinDAE
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new ViCatEdificiosList());
            MainPage = new FicMasterPage();
            //MainPage = new ViCatEdificiosList();
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
