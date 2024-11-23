
using System;
using System.Collections.Generic;

namespace Obligatorio2.Models
{
    public class Publicacion
    {
        public int IdP { get; set; } // Identificador único
        public string Name { get; set; } // Nombre de la publicación
        public DateTime PublishDate { get; set; } // Fecha de publicación
        public string Status { get; set; } // Estado (Abierta, Cerrada)
        public List<Article> Articles { get; set; } = new List<Article>(); // Lista de artículos
        public Usuario BuyingUser { get; set; } // Usuario comprador (si aplica)
        public Usuario UserFinish { get; set; } // Usuario que finalizó la publicación (si aplica)
        public DateTime? PublicationEnd { get; set; } // Fecha de finalización (si aplica)

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
            foreach (var article in Articles)
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
