using System.Collections.Generic;
using Obligatorio2.Models;

namespace Obligatorio2.Models
{
    public class Article
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public List<Category> Categories { get; set; } = new List<Category>(); 
        public decimal SellPrice { get; set; } 

        public Article() { }

        public Article(int id, string name, decimal sellPrice)
        {
            Id = id;
            Name = name;
            SellPrice = sellPrice;
        }
    }
}
