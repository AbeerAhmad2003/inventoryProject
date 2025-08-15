using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Project
{
        public class ProductInputReader
        {
            public Product ReadProduct()
            {
                Console.Write("Enter Product Name: ");
                string name = Console.ReadLine()?.Trim();

                decimal price = ReadDecimal("Enter Product Price: ");
                int quantity = ReadInt("Enter Product Quantity: ");

                return new Product(name, price, quantity);
            }

            public (string? newName, decimal? newPrice, int? newQuantity) ReadProductUpdates(Product existing)
            {
                Console.Write($"New Name (leave empty to keep '{existing.Name}'): ");
                string name = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(name)) name = null;

                decimal? price = ReadOptionalDecimal($"New Price (leave empty to keep {existing.Price}): ");
                int? quantity = ReadOptionalInt($"New Quantity (leave empty to keep {existing.Quantity}): ");

                return (name, price, quantity);
            }

            public string ReadProductName(string prompt)
            {
                Console.Write(prompt);
                return Console.ReadLine()?.Trim();
            }

            private decimal ReadDecimal(string message)
            {
                decimal value;
                while (true)
                {
                    Console.Write(message);
                    string input = Console.ReadLine();
                    if (decimal.TryParse(input, out value) && value >= 0) return value;
                    Console.WriteLine("Invalid number, try again.");
                }
            }

            private int ReadInt(string message)
            {
                int value;
                while (true)
                {
                    Console.Write(message);
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out value) && value >= 0) return value;
                    Console.WriteLine("Invalid number, try again.");
                }
            }

            private decimal? ReadOptionalDecimal(string message)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) return null;
                if (decimal.TryParse(input, out decimal val) && val >= 0) return val;
                Console.WriteLine("Invalid number, change skipped.");
                return null;
            }

            private int? ReadOptionalInt(string message)
            {
                Console.Write(message);
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input)) return null;
                if (int.TryParse(input, out int val) && val >= 0) return val;
                Console.WriteLine("Invalid number, change skipped.");
                return null;
            }
        }
    }

