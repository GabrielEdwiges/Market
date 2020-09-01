using System;
using System.Collections.Generic;

namespace Market.Models
{
    public class CalendarioModel
    {
        public AnuncioModel AnuncioSelecionado { get; set; }
        public List<DateTime> DatasSelecionadas { get; set; }
    }
}
