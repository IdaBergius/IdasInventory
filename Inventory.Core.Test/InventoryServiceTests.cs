using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Core.Test
{
    [TestFixture]
    public class InventoryServiceTests
    {

        [TestCase("I 3")]
        [TestCase("S 2")]
        public void InventoryHandler__InputContainsWhiteSpace__StillUpdatesInventory(string actionAndNumber)
        {
            //Arrange
            InventoryService inventoryService = new InventoryService();
            var startInventory = 10;

            //Act
            inventoryService.InventoryHandler(actionAndNumber);

            //Assert
            Assert.That(inventoryService.InventoryCount != startInventory);
        }
    }
}
