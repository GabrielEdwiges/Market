using Market.ViewModels.Services;
using Market.Views.Services;
using Xamarin.Forms;

namespace Market
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.Register<IMessageService, MessageService>();
            DependencyService.Register<INavigationService, NavigationService>();
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzAxMzkxQDMxMzgyZTMyMmUzMFdHTUppVTNUckVZdWFrUmxHSjJMelpDa1ZGWllTQmZpbWVIZDZ0OGhlRmM9");

            InitializeComponent();

            MainPage = new NavigationPage(new Views.LoginView());
            //MainPage = new Views.BoasVindasView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
