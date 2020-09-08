
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Market.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : MasterDetailPage
    {
        public HomeView()
        {
            InitializeComponent();

            BindingContext = new ViewModels.HomeViewModel();
            Detail = new NavigationPage(new TabbedView());
        }
    }
}