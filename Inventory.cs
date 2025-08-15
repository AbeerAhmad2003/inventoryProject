using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Project
{
    public class Inventory
    {
        private List<Product> _products = new List<Product>();

        public void AddProduct(Product product)
        {
            var existing = GetProductByName(product.Name);
            if (existing != null)
            {
                existing.Quantity += product.Quantity;
            }
            else
            {
                _products.Add(product);
            }
        }

        public List<Product> GetAllProducts() => _products;

        public Product GetProductByName(string name)
        {
            return _products.FirstOrDefault(p =>
                p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public bool DeleteProduct(string name)
        {
            var product = GetProductByName(name);
            if (product != null)
            {
                _products.Remove(product);
                return true;
            }
            return false;
        }

        public void UpdateProduct(Product product, string? newName, decimal? newPrice, int? newQuantity)
        {
            if (!string.IsNullOrWhiteSpace(newName)) product.Name = newName;
            if (newPrice.HasValue) product.Price = newPrice.Value;
            if (newQuantity.HasValue) product.Quantity = newQuantity.Value;
        }
    }
}

