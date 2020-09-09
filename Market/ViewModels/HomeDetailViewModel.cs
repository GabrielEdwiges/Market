using Market.Models;
using Market.ViewModels.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Market.ViewModels
{
    public class HomeDetailViewModel : BaseViewModel
    {
        private AnuncioModel _oldDivulgacao;
        private readonly INavigationService _NavigationService;
        private readonly IMessageService _MessageService;
        private AnuncioModel _ItemSelecionado { get; set; }
        public AnuncioModel ItemSelecionado
        {
            get { return _ItemSelecionado; }
            set
            {
                if (_ItemSelecionado != value)
                {
                    _ItemSelecionado = value;
                }
                HideOrShowAgendamento(value);
            }
        }
        private ObservableCollection<AnuncioModel> _AnunciosDisponiveis { get; set; }
        public ObservableCollection<AnuncioModel> AnunciosDisponiveis { get { return _AnunciosDisponiveis; } set { _AnunciosDisponiveis = value; } }
        public string ImagemSelecionada { get; set; }
        private ObservableCollection<DetalheModel> _DetalhesModel { get; set; }
        public ObservableCollection<DetalheModel> DetalhesModel { get { return _DetalhesModel; } set { _DetalhesModel = value; } }
        public HomeDetailViewModel()
        {
            Reservar_Clicked = new Command(ReservarCommand);

            this._MessageService = DependencyService.Get<IMessageService>();
            this._NavigationService = DependencyService.Get<INavigationService>();

            DetalhesModel = new ObservableCollection<DetalheModel>()
            {
                new DetalheModel(){ Icone = "DetalheHelicoptero_HomeDetailView.png", ESelecionado = false, Representacao = 1, Titulo = "Helipontos"},
                new DetalheModel(){ Icone = "DetalhePosicao_HomeDetailView.png", ESelecionado = false, Representacao = 2, Titulo = "Posição \nde Trabalho"},
                new DetalheModel(){ Icone = "DetalheReuniao_HomeDetailView.png", ESelecionado = false, Representacao = 3, Titulo = "Sala \nde Reunião"},
                new DetalheModel(){ Icone = "DetalheRestaurante_HomeDetailView.png", ESelecionado = false, Representacao = 4, Titulo = "Restaurantes"},
                new DetalheModel(){ Icone = "DetalheMoveis_HomeDetailView.png", ESelecionado = false, Representacao = 5, Titulo = "Móveis"},
                new DetalheModel(){ Icone = "DetalheDeposito_HomeDetailView.png", ESelecionado = false, Representacao = 6, Titulo = "Depósito"},
                new DetalheModel(){ Icone = "DetalheSaloes_HomeDetailView.png", ESelecionado = false, Representacao = 7, Titulo = "Salões/\nAuditorios"},
                new DetalheModel(){ Icone = "DetalheTransporte_HomeDetailView.png", ESelecionado = false, Representacao = 8, Titulo = "Transporte"},
                new DetalheModel(){ Icone = "DetalheTerrenos_HomeDetailView.png", ESelecionado = false, Representacao = 9, Titulo = "Terrenos"},
                new DetalheModel(){ Icone = "DetalheQuadras_HomeDetailView.png", ESelecionado = false, Representacao = 10, Titulo = "Quadras"},
                new DetalheModel(){ Icone = "DetalheMarket_HomeDetailView.png", ESelecionado = false, Representacao = 11, Titulo = "Market\nPlace"},
                new DetalheModel(){ Icone = "DetalheGaragem_HomeDetailView.png", ESelecionado = false, Representacao = 12, Titulo = "Vagas\nde Garagem"},
                new DetalheModel(){ Icone = "DetalheObjetos_HomeDetailView.png", ESelecionado = false, Representacao = 13, Titulo = "Objetos"}
            };
            var ListaImagens = new List<ImagemModel>()
            {
                new ImagemModel()
                {
                ImagemSource = "Divulgacao1.png"
                },
                new ImagemModel()
                {
                ImagemSource = "Divulgacao2.png"
                },
            };
            AnunciosDisponiveis = new ObservableCollection<AnuncioModel>()
            {
                new AnuncioModel()
                {
                    Categoria="SALA",
                    Titulo = "CENTRO COMERCIAL PAULISTA",
                    PreTitulo = "AV. PAULISTA, 435",
                    Descricao = "Sala escritório 45m2. Ótima localização\n" +
                    "Mesas para 16 pessoas. Wifi.\n\n" +
                    "Prédio com sala de espera e cafeteria.",
                    Endereco = "Av. Paulista, 435, 7º Andar\n" +
                    "Sala 1 - Jardim Paulista - São Paulo - SP",
                    Possui360 = true,
                    EFavorita = false,
                    Avaliacao = 3,
                    Capacidade = 25,
                    Hora = 150,
                    Diaria = 345,
                    Imagens = ListaImagens,
                    Codigo = "WTRI-5648954",
                    ESelecionado = false
                },
                new AnuncioModel()
                {
                    Categoria="SALA",
                    Titulo = "CENTRO COMERCIAL REBOUÇAS",
                    PreTitulo = "AV. REBOUÇAS, 1206",
                    Descricao = "Sala escritório 50m2. Ótima localização\n" +
                    "Mesas para 18 pessoas. Wifi.\n\n" +
                    "Prédio com sala de espera e cafeteria.",
                    Endereco = "Av. Moema, 287, 5º Andar\n" +
                    "Sala 5 - Moema - São Paulo - SP",
                    Possui360 = true,
                    EFavorita = false,
                    Avaliacao = 4,
                    Capacidade = 18,
                    Hora = 125,
                    Diaria = 400,
                    Imagens = ListaImagens,
                    Codigo = "WTRI-5648955",
                    ESelecionado = false
                }
            };

            ImagemSelecionada = "MenuInferior_Home_Selecionado.png";
        }
        private string _Pesquisa { get; set; }
        public string Pesquisa { get { return _Pesquisa; } set { _Pesquisa = value; OnPropertyChanged("Pesquisa"); } }

        public ICommand Reservar_Clicked { get; set; }

        public static AnuncioModel _AnuncioSelecionado { get; private set; }

        private void ReservarCommand()
        {
            _AnuncioSelecionado = ItemSelecionado;
            if (_AnuncioSelecionado == null)
            {
                this._MessageService.ShowAsync("Não á nenhum anuncio selecionado!");
            }
            else
            {
                this._NavigationService.NavigateToSelectDates();
            }
        }

        internal virtual void HideOrShowAgendamento(AnuncioModel divulgacao)
        {
            if (divulgacao == null)
            {
                return;
            }
            if (_oldDivulgacao == divulgacao)
            {
                //click twice on the same item will hide it
                divulgacao.ESelecionado = !divulgacao.ESelecionado;
                UpdateDivulgacoes(divulgacao);
            }
            else
            {
                if (_oldDivulgacao != null)
                {
                    // hide previous selected item
                    _oldDivulgacao.ESelecionado = false;
                    UpdateDivulgacoes(_oldDivulgacao);
                }
                // show selected item
                divulgacao.ESelecionado = true;
                UpdateDivulgacoes(divulgacao);
            }

            _oldDivulgacao = divulgacao;
        }

        private void UpdateDivulgacoes(AnuncioModel divulgacao)
        {
            var index = AnunciosDisponiveis.IndexOf(divulgacao);
            AnunciosDisponiveis.Remove(divulgacao);
            AnunciosDisponiveis.Insert(index, divulgacao);
        }
    }
}
