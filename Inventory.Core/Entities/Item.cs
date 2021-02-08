using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Core.Entities
{
    public class Item
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
        public int NrOfItems { get; set; }
    }
}
