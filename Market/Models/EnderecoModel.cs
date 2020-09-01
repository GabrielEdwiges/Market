namespace Market.Models
{
    public class EnderecoModel
    {
        public int Cep { get; set; }
        public string Estado { get; set; }
        public string CidadeMunicipio { get; set; }
        public string NomeDoEdificio { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
