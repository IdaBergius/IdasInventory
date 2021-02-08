using Inventory.Core;
using System;


namespace Inventory.ConsoleApp
{
    class Program
    {
        public static int InventoryCount { get; set; }

        public static InventoryService _inventoryService = new InventoryService();
        static void Main(string[] args)
        {
            InventoryWorker(true);
        }

        public static void InventoryWorker(bool runInventory)
        {
            if (!runInventory)
            {
                StopInventory();
                return;
            }
            if (_inventoryService.InventoryCount == 0)
            {
                _inventoryService.InventoryCount = StartInventory();
            }

            DisplayNumberOfItems();
            var actionAndnumber = ActionDecider();

           var continueInventory = _inventoryService.InventoryHandler(actionAndnumber);
            InventoryWorker(continueInventory);
        }

        private static void StopInventory()
        {
            Console.WriteLine("Thank you, shutting down");
        }

        public static int StartInventory()
        {
            Console.WriteLine("Welcome to Idas shop!");

            Console.WriteLine("The day started, enter how many items is in the shop today");

            var numberOfItems = Console.ReadLine();
            return Convert.ToInt32(numberOfItems);
        }

        public static void DisplayNumberOfItems()
        {
            Console.WriteLine($"Your inventory is {_inventoryService.InventoryCount} nr of items");

        }

        public static string ActionDecider()
        {
            Console.WriteLine(@"What would you like to do? Push key I to deliver items, key S for sell, L for inventory count
                                If you wish to quit the program, push X");

            return Console.ReadLine().ToUpper();
        }
    }
}
