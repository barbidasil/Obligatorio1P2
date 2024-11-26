
using System;
using System.Collections.Generic;

namespace Obligatorio2.Models
{
    public class Publicacion
    {
        public int IdP { get; set; } 
        public string Name { get; set; } 
        public DateTime PublishDate { get; set; } 
        public string Status { get; set; } 
        public List<Article> Articles { get; set; } = new List<Article>();
        public Usuario BuyingUser { get; set; } 
        public Usuario UserFinish { get; set; } 
        public DateTime? PublicationEnd { get; set; }

        public Publicacion() { }

        public Publicacion(string name, DateTime publishDate, string status)
        {
            Name = name;
            PublishDate = publishDate;
            Status = status;
        }

        public virtual decimal GetPrice()
        {
            decimal total = 0;
            foreach (Article article in Articles)
            {
                total += article.SellPrice;
            }
            return total;
        }

        public bool IsOpen()
        {
            return Status == "Abierta";
        }

        public void Close(Usuario user, DateTime closeDate)
        {
            UserFinish = user;
            Status = "Cerrada";
            PublicationEnd = closeDate;
        }
    }
}
