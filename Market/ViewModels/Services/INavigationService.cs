using System.Threading.Tasks;

namespace Market.ViewModels.Services
{
    public interface INavigationService
    {
        Task NavigateToWelcome();
        Task NavigateToRegister();
        Task NavigateToHomePage();
        Task NavigateToForgetPassword();
        Task NavigateToSelectDates();
    }
}
