using Market.Models;
using System.Collections.ObjectModel;

namespace Market.ViewModels
{
    public class HomeDetailViewModel: BaseViewModel
    {
        private ObservableCollection<DetalheModel> _DetalhesModel { get; set; }
        public ObservableCollection<DetalheModel> DetalhesModel { get { return _DetalhesModel; } set { _DetalhesModel = value; } }
        public HomeDetailViewModel()
        {
            DetalhesModel = new ObservableCollection<DetalheModel>()
            {
                new DetalheModel(){ Icone = "DetalheHelicoptero_HomeDetailView.png", ESelecionado = false, Representacao = 1, Titulo = "Helipontos"},
                new DetalheModel(){ Icone = "DetalhePosicao_HomeDetailView.png", ESelecionado = false, Representacao = 2, Titulo = "Posição \nde Trabalho"},
                new DetalheModel(){ Icone = "DetalheReuniao_HomeDetailView.png", ESelecionado = false, Representacao = 3, Titulo = "Sala \nde Reunião"},
                new DetalheModel(){ Icone = "DetalheRestaurante_HomeDetailView.png", ESelecionado = false, Representacao = 4, Titulo = "Restaurantes"},
                new DetalheModel(){ Icone = "DetalheMoveis_HomeDetailView.png", ESelecionado = false, Representacao = 5, Titulo = "Móveis"},
                new DetalheModel(){ Icone = "DetalheDeposito_HomeDetailView.png", ESelecionado = false, Representacao = 6, Titulo = "Depósito"},
            };
        }
    }
}
