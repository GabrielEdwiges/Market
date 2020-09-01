using Market.Models;
using Market.ViewModels.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Market.ViewModels
{
    public class BoasVindasViewModel : BaseViewModel
    {
        private ObservableCollection<BoasVindasModel> _BoasVindasModels { get; set; }
        public ObservableCollection<BoasVindasModel> BoasVindasSlides { get { return _BoasVindasModels; } set { _BoasVindasModels = value; } }

        private readonly INavigationService _NavigationService;

        private int _Posicao { get; set; }
        public int Posicao { get { return _Posicao; } set { _Posicao = value; OnPropertyChanged("Posicao"); } }
        public int i = 0;//Contador para o número de apresentações


        public BoasVindasViewModel()
        {

            BoasVindasSlides = new ObservableCollection<BoasVindasModel>()
            {
                new BoasVindasModel(){ Imagem = "Imagem1_BoasVindas.png" },
                new BoasVindasModel(){ Imagem = "Imagem2_BoasVindas.png" }
            };
            this._NavigationService = DependencyService.Get<INavigationService>();
            SlidesDeApresentacao();
        }

        internal void SlidesDeApresentacao()
        {
            var qtde = BoasVindasSlides.ToList().Count;

            Device.StartTimer(TimeSpan.FromSeconds(4), (Func<bool>)(() =>
            {
                i++;
                Posicao = (Posicao + 1) % qtde;

                if (i == qtde)
                {
                    i = 0;
                    _NavigationService.NavigateToHomePage();
                    return false;
                }
                else
                {
                    return true;
                }
            }));
        }
    }
}
