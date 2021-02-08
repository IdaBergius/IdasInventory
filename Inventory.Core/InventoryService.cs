using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Inventory.Core.Entities;

namespace Inventory.Core
{
    public class InventoryService
    {
        public int InventoryCount { get; set; }

        public bool InventoryHandler(string actionAndNumber)
        {
            var Item = new Item() { Action = "", NrOfItems = 0 };

            var numberOfItems = Regex.Match(actionAndNumber, @"\d+").Value;
            if (!string.IsNullOrEmpty(numberOfItems))
            {
                Item.NrOfItems = Convert.ToInt32(numberOfItems);
            }

            Item.Action = new string(actionAndNumber.Where(c => !char.IsDigit(c))
                                                .Where(s => !char.IsWhiteSpace(s)).ToArray());

            if (Item.Action.Length > 1)
            {
                Console.WriteLine($"Sorry i did not understand what you wish to do. Did you mean '{Item.Action[0]}' Y or N");
                var newAction = Console.ReadLine().ToUpper();
                if (newAction == "Y")
                {
                    Item.Action = Item.Action[0].ToString();
                }
                else
                {
                    return true;
                }
            }

            switch (Item.Action)
            {
                case "I":
                    {
                        InventoryCount += Item.NrOfItems;
                        return true;
                    }

                case "S":
                    {
                        InventoryCount -= Item.NrOfItems;
                        return true;
                    }

                case "L":
                    {
                        return true;
                    }

                case "X":
                    {
                        return false;
                    }

                default:
                    {
                        return true;
                    }
            }
        }
    }
}
