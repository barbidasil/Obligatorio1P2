using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Article
    {
        private int _id;
        private string _name;
        private List<Category> _category = new List<Category>();
        private decimal _sellPrice;

        // Getters y Setters
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Category> Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public decimal SellPrice
        {
            get { return _sellPrice; }
            set { _sellPrice = value; }
        }

        // Constructor opcional para inicializar la clase
        public Article(int id, string name, List<Category> category, int sellPrice)
        {
            _id = id;
            _name = name;
            _category = category;
            _sellPrice = sellPrice;
        }

        // Constructor vacío
        public Article() { }
    }
}
