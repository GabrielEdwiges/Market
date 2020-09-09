using Market.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Market.ViewModels
{
    public class SelecionarDatasViewModel : BaseViewModel
    {
        private string _Categoria { get; set; }
        public string Categoria { get { return _Categoria; } set { _Categoria = value; OnPropertyChanged("Categoria"); } }

        private DateTime _DataMinima { get; set; }
        public DateTime DataMinima { get { return _DataMinima; } set { _DataMinima = value; OnPropertyChanged("DataMinima"); } }

        private List<string> _Meses { get; set; }
        public List<string> Meses { get { return _Meses; } set { _Meses = value; OnPropertyChanged("MesSelecionado"); } }

        public ICommand DataSelecionada { get; set; }
        private void OnDateTimePropertyChanged(List<DateTime> value)
        {
            DatasSelecionadas.Clear();
            DatasSelecionadas = value;
        }

        private readonly INavigationService _NavigationService;
        private readonly IMessageService _MessageService;
        private List<DateTime> _DatasSelecionadas { get; set; }
        public List<DateTime> DatasSelecionadas
        {
            get { return _DatasSelecionadas; }
            set
            {
                _DatasSelecionadas = value;
                AtualizarListaDatas(value);
            }
        }
        private string _Titulo { get; set; }
        public string Titulo { get { return _Titulo; } set { _Titulo = value; } }
        private StackLayout _ResumoDatas { get; set; }
        public StackLayout ResumoDatas { get { return _ResumoDatas; } set { _ResumoDatas = value; OnPropertyChanged("ResumoDatas"); } }
        public ICommand ReservarLocal_Clicked { get; set; }

        [Obsolete]
        public SelecionarDatasViewModel()
        {
            DataSelecionada = new Command(SelecionarDatas);
            ResumoDatas = new StackLayout();
            this._MessageService = DependencyService.Get<IMessageService>();
            this._NavigationService = DependencyService.Get<INavigationService>();
            DatasSelecionadas = new List<DateTime>();
            Categoria = HomeDetailViewModel._AnuncioSelecionado.Categoria;
            Titulo = HomeDetailViewModel._AnuncioSelecionado.Titulo;
            DataMinima = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            Meses = new List<string>()
            {
                "Janeiro",
                "Fevereiro",
                "Março",
                "Abril",
                "Maio",
                "Junho",
                "Agosto",
                "Setembro",
                "Outubro",
                "Novembro",
                "Dezembro"
            };
            MesReferencia(DateTime.Now.Month);
            //ReservarLocal_Clicked = new Command();
        }

        private void MesReferencia(int month)
        {
            switch (month)
            {
                case 1:
                    MesDefault = 0;
                    break;
                case 2:
                    MesDefault = 1;
                    break;
                case 3:
                    MesDefault = 2;
                    break;
                case 4:
                    MesDefault = 3;
                    break;
                case 5:
                    MesDefault = 4;
                    break;
                case 6:
                    MesDefault = 5;
                    break;
                case 7:
                    MesDefault = 6;
                    break;
                case 8:
                    MesDefault = 7;
                    break;
                case 9:
                    MesDefault = 8;
                    break;
                case 10:
                    MesDefault = 9;
                    break;
                case 11:
                    MesDefault = 10;
                    break;
                case 12:
                    MesDefault = 11;
                    break;
            }
        }

        private int _MesDefault { get; set; }
        public int MesDefault { get { return _MesDefault; } set { _MesDefault = value; OnPropertyChanged("MesDefault"); } }

        [Obsolete]
        private void SelecionarDatas(object datas)
        {
            var x = datas as Syncfusion.SfCalendar.XForms.SelectionChangedEventArgs;
            var y = x.Calendar.SelectedDates;
            OnDateTimePropertyChanged(y);
        }

        private void AtualizarListaDatas(List<DateTime> value)
        {
            if (value != null && value.Count != 0)
            {
                var diasOrganizados = OrganizarDatas(value.ToList());
                RegistrarDatas(diasOrganizados);
            }

        }

        private List<DateTime> OrganizarDatas(List<DateTime> dias)
        {
            DateTime maior = new DateTime();
            DateTime menor = new DateTime();
            List<DateTime> diasOrganizados = new List<DateTime>();
            diasOrganizados.Clear();
            DateTime base1 = new DateTime();
            for (var i = 0; i < dias.Count; i++)
            {
                if (i == 0)
                {
                    maior = dias[i];
                    menor = dias[i];
                }
                if (dias[i] >= maior)
                {
                    maior = dias[i];
                }
                if (dias[i] <= menor)
                {
                    menor = dias[i];
                }
            }
            diasOrganizados.Add(menor);
            base1 = menor;
            for (var i = 0; i < (maior.Day - menor.Day); i++)
            {
                base1 = base1.AddDays(1);
                for (var j = 0; j < dias.Count; j++)
                {
                    if (base1 == dias[j])
                    {
                        diasOrganizados.Add(dias[j]);
                    }
                }
            }
            return diasOrganizados;
        }

        private int _indexOfDates { get; set; }
        private void RegistrarDatas(List<DateTime> datas)
        {
            ResumoDatas.Children.Clear();
            var de = new DateTime();
            var ate = new DateTime();
            var j = 1;
            var show = new Label();
            var x = 0;
            for (var i = 0; i < datas.Count; i++)
            {
                if (i == 0)
                {
                    de = datas[i];
                    ate = datas[i];

                    show = new Label()
                    {
                        FontSize = 12,
                        Margin = 10,
                        HorizontalOptions = LayoutOptions.Start,
                        HorizontalTextAlignment = TextAlignment.Start,
                        Text = "De: " + de.ToShortDateString() + " Até: " + ate.ToShortDateString()
                    };

                    var novasDatas = new List<DateTime>();
                    novasDatas.Add(de);
                    novasDatas.Add(ate);
                    LimparDatas();

                    _indexOfDates = RegistrarNovasDatas(novasDatas);

                    ResumoDatas.Children.Add(show);
                }
                else
                {
                    if (datas[i] != ate.AddDays(j))
                    {
                        de = datas[i];
                        ate = datas[i];

                        show = new Label()
                        {
                            FontSize = 12,
                            Margin = 10,
                            HorizontalOptions = LayoutOptions.Start,
                            HorizontalTextAlignment = TextAlignment.Start,
                            Text = "De: " + de.ToShortDateString() + " Até: " + ate.ToShortDateString()
                        };
                        var novasDatas = new List<DateTime>();
                        novasDatas.Add(de);
                        novasDatas.Add(ate);

                        _indexOfDates = RegistrarNovasDatas(novasDatas);
                        ResumoDatas.Children.Add(show);

                        j = 0;
                        x++;
                    }
                    else
                    {

                        var index = ResumoDatas.Children.IndexOf(show);
                        ResumoDatas.Children.Remove(show);
                        var newShow = new Label()
                        {
                            FontSize = 12,
                            Margin = 10,
                            HorizontalOptions = LayoutOptions.Start,
                            HorizontalTextAlignment = TextAlignment.Start,
                            Text = "De: " + de.ToShortDateString() + " Até: " + ate.AddDays(j).ToShortDateString()
                        };
                        var novasDatas = new List<DateTime>();
                        novasDatas.Add(de);
                        novasDatas.Add(ate.AddDays(j));

                        AtualizarUmaData(_indexOfDates, novasDatas);
                        show = newShow;
                        ResumoDatas.Children.Insert(index, newShow);
                    }
                    if (x == 0)
                    {
                        j = i;
                        j++;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
        }
        private int RegistrarNovasDatas(List<DateTime> datas)
        {
            HomeDetailViewModel._AnuncioSelecionado.DatasSelecionadas.Add(datas);

            return HomeDetailViewModel._AnuncioSelecionado.DatasSelecionadas.IndexOf(datas);
        }
        private void LimparDatas()
        {
            HomeDetailViewModel._AnuncioSelecionado.DatasSelecionadas.Clear();
        }
        private void AtualizarUmaData(int index, List<DateTime> datas)
        {
            HomeDetailViewModel._AnuncioSelecionado.DatasSelecionadas.RemoveAt(index);
            HomeDetailViewModel._AnuncioSelecionado.DatasSelecionadas.Insert(index, datas);
        }
    }
}
