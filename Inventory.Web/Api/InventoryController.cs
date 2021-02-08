using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;
using Inventory.Core.Entities;
using System.Net.Http;

namespace Inventory.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController
    {
        [HttpGet("get")] 
        public async Task<Item> GetInventory()
        {
            var httpClient = new HttpClient();

            //get inventory
            return new Item { };
        }
    }
}
