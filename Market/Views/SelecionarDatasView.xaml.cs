
using Market.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Market.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelecionarDatasView : ContentPage
    {
        [System.Obsolete]
        public SelecionarDatasView()
        {
            InitializeComponent();
            BindingContext = new SelecionarDatasViewModel();
        }
    }
}