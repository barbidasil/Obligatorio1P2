

namespace Obligatorio2.Models
{
    public class Auction : Publicacion
    {
        public List<Offer> Offers { get; set; } = new List<Offer>(); // Lista de ofertas

        public override decimal GetPrice()
        {
            decimal highestOffer = 0;
            foreach (var offer in Offers)
            {
                if (offer.Amount > highestOffer)
                {
                    highestOffer = offer.Amount;
                }
            }
            return highestOffer;
        }

        public void AddOffer(Offer offer)
        {
            if (!IsOpen())
                throw new InvalidOperationException("La subasta no está abierta.");

            decimal highestOffer = GetPrice();
            if (offer.Amount <= highestOffer)
                throw new ArgumentException("La oferta debe ser mayor que la actual.");

            Offers.Add(offer);
        }
    }
}
