namespace Inventory_Project
{
    class Program
    {

        static void Main(string[] args)
        {
            var inventory = new Inventory();
            var reader = new ProductInputReader();
            var menu = new Menu(inventory, reader);
            menu.Show();
        }
    }
}
