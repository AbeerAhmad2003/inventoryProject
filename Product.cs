using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Project
{
    public class Product
    {
        private static int nextId = 1;
        public int Id { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, decimal price, int quantity)
        {
            Id = nextId++;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }

}
