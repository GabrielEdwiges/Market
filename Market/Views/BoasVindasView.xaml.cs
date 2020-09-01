
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Market.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoasVindasView : ContentPage
    {
        public BoasVindasView()
        {
            InitializeComponent();

            BindingContext = new ViewModels.BoasVindasViewModel();
        }
    }
}