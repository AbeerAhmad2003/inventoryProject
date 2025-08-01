using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Project
{
    public class Inventory
    {
        private List<Product> products = new List<Product>();

        public void AddProduct()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Console.Write("Enter product price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter product quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            var newProduct = new Product(name, price, quantity);

            var existing = products.FirstOrDefault(p => p.Name.Equals(newProduct.Name, StringComparison.OrdinalIgnoreCase));
            if (existing != null)
            {
                existing.Quantity += newProduct.Quantity;
                Console.WriteLine($"Updated quantity of existing product '{existing.Name}' to {existing.Quantity}");
            }
            else
            {
                products.Add(newProduct);
                Console.WriteLine($"Added product '{newProduct.Name}' with ID {newProduct.Id}");
            }
        }

        public void ViewAllProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            Console.WriteLine("\n--- All Products ---");

            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.Id}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price:C}");
                Console.WriteLine($"Quantity: {product.Quantity}");
                Console.WriteLine("---------------------------");
            }
        }
        public void EditProduct()
        {
            Console.Write("Enter product name to edit: ");
            string nameToEdit = Console.ReadLine()?.Trim();

            var product = products.FirstOrDefault(p => p.Name.Equals(nameToEdit, StringComparison.OrdinalIgnoreCase));
            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("Enter new name (leave empty to keep current): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
                product.Name = newName;

            Console.Write("Enter new price (leave empty to keep current): ");
            string priceInput = Console.ReadLine();
            if (decimal.TryParse(priceInput, out decimal newPrice))
                product.Price = newPrice;

            Console.Write("Enter new quantity (leave empty to keep current): ");
            string qtyInput = Console.ReadLine();
            if (int.TryParse(qtyInput, out int newQty))
                product.Quantity = newQty;

            Console.WriteLine("Product updated successfully.");
        }
        public void DeleteProduct()
        {
            Console.Write("Enter the name of the product to delete: ");
            string nameToDelete = Console.ReadLine();

            Product productToDelete = products.FirstOrDefault(p => p.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

            if (productToDelete != null)
            {
                products.Remove(productToDelete);
                Console.WriteLine($"Product '{nameToDelete}' deleted successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        public void FindProduct()
        {
            Console.Write("Enter product name to search: ");
            string name = Console.ReadLine();

            var product = products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (product != null)
            {
                Console.WriteLine("\n--- Product Details ---");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price:C}");
                Console.WriteLine($"Quantity: {product.Quantity}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }





    }
}
