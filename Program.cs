namespace Inventory_Project
{
    class Program
    {
        static Inventory inventory = new Inventory();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Edit");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Find Product");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        inventory.AddProduct();
                        break;
                    case "2":
                        inventory.ViewAllProducts();
                        break;
                    case "3":
                        inventory.EditProduct();
                        break;
                    case "4":
                        inventory.DeleteProduct();
                        break;
                    case "5":
                        inventory.FindProduct();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        
    }
}
