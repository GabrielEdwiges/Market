﻿using System;
using System.Collections.Generic;

namespace Market.Models
{
    public class AnuncioModel
    {
        public string Categoria { get; set; }
        public string Titulo { get; set; }
        public List<ImagemModel> Imagens { get; set; }
        public List<DetalheModel> Detalhes { get; set; }
        public List<DateTime> DatasIndisponiveis { get; set; }
        public EnderecoModel Endereco { get; set; }
        public bool Possui360 { get; set; }
        public bool EFavorita { get; set; }
        public short Avaliacao { get; set; }
        public string Descricao { get; set; }
        public int Capacidade { get; set; }
        public decimal Hora { get; set; }
        public decimal Diaria { get; set; }
        public string Codigo { get; set; }
        public bool EstaReservado { get; set; }
    }
}