using Market.Models;
using System.Collections.ObjectModel;

namespace Market.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private ObservableCollection<MenuModel> _Menu { get; set; }
        public ObservableCollection<MenuModel> Menu { get { return _Menu; } set { _Menu = value; } }

        private MenuModel _ItemSelecionado { get; set; }
        public MenuModel ItemSelecionado
        {
            get { return _ItemSelecionado; }
            set
            {
                if(_ItemSelecionado != value)
                {
                    _ItemSelecionado = value;
                    HandleSelectedItem();
                }
            }
        }

        private string _ImagemFundo_MenuView { get; set; }
        public string ImagemFundo_MenuView { get { return _ImagemFundo_MenuView; } set { _ImagemFundo_MenuView = value; OnPropertyChanged("ImagemFundo_MenuView"); } }

        public HomeViewModel()
        {
            ImagemFundo_MenuView = "ImagemFundo_MenuView.png";
            Menu = new ObservableCollection<MenuModel>()
            {
                new MenuModel(){ Icone = "IconePerfil_MenuView.png", Titulo = "Minha Conta", Avancar = "IconeAvancar_MenuView.png" },
                new MenuModel(){ Icone = "IconeMinhasReservas_MenuView.png", Titulo = "Minhas Reservas", Avancar = "IconeAvancar_MenuView.png" },
                new MenuModel(){ Icone = "IconeMeioPagamento_MenuView.png", Titulo = "Meio de Pagamento", Avancar = "IconeAvancar_MenuView.png" },
                new MenuModel(){ Icone = "IconeMeusAnuncios_MenuView.png", Titulo = "Meus Anuncios", Avancar = "IconeAvancar_MenuView.png" },
                new MenuModel(){ Icone = "IconePatrocinar_MenuView.png", Titulo = "Patrocinar Anúncio", Avancar = "IconeAvancar_MenuView.png" },
                new MenuModel(){ Icone = "IconeAjuda_MenuView.png", Titulo = "Ajuda", Avancar = "IconeAvancar_MenuView.png" },
                new MenuModel(){ Icone = "IconeTermosECondicoes_MenuView.png", Titulo = "Termos e Condições", Avancar = "IconeAvancar_MenuView.png" },
                new MenuModel(){ Icone = "IconeSair_MenuView.png", Titulo = "Sair", Avancar = "IconeAvancar_MenuView.png" },

            };
        }

        private void HandleSelectedItem()
        {

        }
    }
}
