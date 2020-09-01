using Market.ViewModels.Services;
using System.Threading.Tasks;

namespace Market.Views.Services
{
    public class MessageService : IMessageService
    {
        public async Task ShowAsync(string message)
        {
            await Market.App.Current.MainPage.DisplayAlert("Alerta!", message, "Certo");
        }
    }
}
