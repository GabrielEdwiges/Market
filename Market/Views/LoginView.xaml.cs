
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Market.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();

            BindingContext = new ViewModels.LoginViewModel();
        }
    }
}