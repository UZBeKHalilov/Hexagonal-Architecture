using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        private Product() { }

        public Product(Guid id, string name, decimal price, int stock)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty."); 
            if (price < 0) throw new ArgumentException("Price cannot be negative.");
            if (stock < 0) throw new ArgumentException("Stock cannot be negative.");
            Id = id;

            Name = name;
            Price = price;
            Stock = stock;
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentException("Name cannot be empty."); 
            Name = newName;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0) throw new ArgumentException("Price cannot be negative.");
            Price = newPrice;
        }

        public void UpdateStock(int newStock)
        {
            if (newStock < 0) throw new ArgumentException("Stock cannot be negative.");
            Stock = newStock;
        }
    }
}
