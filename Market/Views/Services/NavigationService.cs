using Market.ViewModels.Services;
using System;
using System.Threading.Tasks;

namespace Market.Views.Services
{
    public class NavigationService : INavigationService
    {
        public Task NavigateToForgetPassword()
        {
            throw new NotImplementedException();
        }

        public async Task NavigateToHomePage()
        {
            await Market.App.Current.MainPage.Navigation.PushAsync(new Views.HomeView());
        }

        public Task NavigateToRegister()
        {
            throw new NotImplementedException();
        }

        public async Task NavigateToWelcome()
        {
            await Market.App.Current.MainPage.Navigation.PushAsync(new Views.BoasVindasView());
        }
    }
}
