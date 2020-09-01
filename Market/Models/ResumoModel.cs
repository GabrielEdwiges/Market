using System.Collections.Generic;

namespace Market.Models
{
    public class ResumoModel
    {
        public List<CheckInModel> Anuncios { get; set; }
        public decimal Total { get; set; }
    }
}
