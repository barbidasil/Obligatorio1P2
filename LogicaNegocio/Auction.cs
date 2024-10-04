using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace LogicaNegocio
{
    public class Auction : Publicacion
    {
        private List<Offer> _offers = new List<Offer>();

        public List<Offer> Offers
        {
            get { return _offers; }
        }

        public Auction(string name, DateTime publishDate, Status status, Usuario buyingUser, Usuario userFinish, DateTime publicationEnd)
            : base(name, publishDate, status, buyingUser, userFinish, publicationEnd)
        {
        }

        public void AddOffer(Offer offer)
        {
            _offers.Add(offer);
        }

        public override string ToString()
        {
            return $"Auction: {Name}, Offers: {Offers.Count}";
        }
    }
}
