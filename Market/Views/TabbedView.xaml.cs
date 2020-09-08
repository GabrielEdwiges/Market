using Naxam.Controls.Forms;
using Xamarin.Forms.Xaml;

namespace Market.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedView : BottomTabbedPage
    {
        public TabbedView()
        {
            InitializeComponent();
        }
    }
}