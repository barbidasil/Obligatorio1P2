

namespace Obligatorio2.Models
{
    public class Offer
    {
        public int OfferId { get; set; } 
        public Usuario Client { get; set; } 
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
