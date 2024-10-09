using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace LogicaNegocio
{
    public class Offer
    {
        private int _offerId;
        private Cliente _client;
        private int _amount;
        private DateTime _date;

        public int OfferId
        {
            get { return _offerId; }
        }

        public Cliente Client
        {
            get { return _client; }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public Offer(int offerId, Cliente client, int amount, DateTime date)
        {
            this._offerId = offerId;
            this._client = client ?? throw new ArgumentNullException(nameof(client));
            this._amount = amount;
            this._date = date;
        }

        public override string ToString()
        {
            return $"OfferId: {OfferId}, Amount: {Amount}, Date: {Date}";
        }
    }
}
