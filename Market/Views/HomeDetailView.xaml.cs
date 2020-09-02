using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Market.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeDetailView : ContentPage
    {
        public HomeDetailView()
        {
            InitializeComponent();

            BindingContext = new ViewModels.HomeDetailViewModel();
        }
    }
}