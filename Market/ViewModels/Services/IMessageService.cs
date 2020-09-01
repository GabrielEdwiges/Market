using System.Threading.Tasks;

namespace Market.ViewModels.Services
{
    public interface IMessageService
    {
        Task ShowAsync(string message);
    }
}
