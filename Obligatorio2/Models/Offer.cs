

namespace Obligatorio2.Models
{
    public class Offer
    {
        public int OfferId { get; set; } // Identificador único de la oferta
        public Usuario Client { get; set; } // Cliente que hizo la oferta
        public decimal Amount { get; set; } // Monto ofrecido
        public DateTime Date { get; set; } // Fecha de la oferta
    }
}
