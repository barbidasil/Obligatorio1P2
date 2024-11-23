using System.Collections.Generic;
using Obligatorio2.Models;

namespace Obligatorio2.Models
{
    public class Article
    {
        public int Id { get; set; } // Identificador único
        public string Name { get; set; } // Nombre del artículo
        public List<Category> Categories { get; set; } = new List<Category>(); // Categorías del artículo
        public decimal SellPrice { get; set; } // Precio de venta

        public Article() { }

        public Article(int id, string name, decimal sellPrice)
        {
            Id = id;
            Name = name;
            SellPrice = sellPrice;
        }
    }
}
