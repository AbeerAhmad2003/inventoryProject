using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Project
{
    public  class Menu
    {
        private Inventory _inventory;
        private ProductInputReader _reader;

        public Menu(Inventory inventory, ProductInputReader reader)
        {
            _inventory = inventory;
            _reader = reader;
        }

        public void Show()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Edit Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Find Product");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        var product = _reader.ReadProduct();
                        if (ProductValidator.IsValid(product))
                        {
                            _inventory.AddProduct(product);
                            Console.WriteLine("Product added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid product data.");
                        }
                        break;

                    case "2":
                        var all = _inventory.GetAllProducts();
                        if (all.Count == 0)
                            Console.WriteLine("Inventory is empty.");
                        else
                            foreach (var p in all)
                                Console.WriteLine($"ID:{p.Id} Name:{p.Name} Price:{p.Price} Quantity:{p.Quantity}");
                        break;

                    case "3":
                        var nameToEdit = _reader.ReadProductName("Enter product name to edit: ");
                        var productToEdit = _inventory.GetProductByName(nameToEdit);
                        if (productToEdit != null)
                        {
                            var updates = _reader.ReadProductUpdates(productToEdit);
                            _inventory.UpdateProduct(productToEdit, updates.newName, updates.newPrice, updates.newQuantity);
                            Console.WriteLine("Product updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Product not found.");
                        }
                        break;

                    case "4":
                        var nameToDelete = _reader.ReadProductName("Enter product name to delete: ");
                        if (_inventory.DeleteProduct(nameToDelete))
                            Console.WriteLine("Product deleted successfully.");
                        else
                            Console.WriteLine("Product not found.");
                        break;

                    case "5":
                        var nameToFind = _reader.ReadProductName("Enter product name to search: ");
                        var found = _inventory.GetProductByName(nameToFind);
                        if (found != null)
                            Console.WriteLine($"ID:{found.Id} Name:{found.Name} Price:{found.Price} Quantity:{found.Quantity}");
                        else
                            Console.WriteLine("Product not found.");
                        break;

                    case "6":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
    }
}
    

