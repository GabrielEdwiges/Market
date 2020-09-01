using System;

namespace Market.Models
{
    public class CartaoModel
    {
        public string NumeroCartao { get; set; }
        public string Titular { get; set; }
        public DateTime Validade { get; set; }
        public short CVV { get; set; }
        public ResumoModel Produtos { get; set; }
        public bool SalvarCartao { get; set; }
    }
}
