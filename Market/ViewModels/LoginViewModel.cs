using Market.ViewModels.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace Market.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _Email { get; set; }
        public string Email { get { return _Email; } set { _Email = value; OnPropertyChanged("Email"); } }
        private string _Password { get; set; }
        public string Password { get { return _Password; } set { _Password = value; OnPropertyChanged("Password"); } }

        private readonly IMessageService _MessageService;
        private readonly INavigationService _NavigationService;

        public ICommand Registrar { get; set; }
        public ICommand Entrar { get; set; }
        public ICommand EsqueceuSenha { get; set; }

        public LoginViewModel()
        {
            Registrar = new Command(RegistrarAction);
            Entrar = new Command(EntrarAction);
            EsqueceuSenha = new Command(EsqueceuSenhaAction);


            this._MessageService = DependencyService.Get<IMessageService>();
            this._NavigationService = DependencyService.Get<INavigationService>();
        }

        private void EntrarAction()
        {
            if (this.Email == "adm" && this.Password == "123")
            {
                this._NavigationService.NavigateToWelcome();
            }
            else
            {
                this._MessageService.ShowAsync("Email e/ou senha incorretos!");
            }
        }

        private void RegistrarAction()
        {
            Email = "Registrar";
        }

        private void EsqueceuSenhaAction()
        {
            Email = "Esqueceu foi ?";
        }

    }
}
