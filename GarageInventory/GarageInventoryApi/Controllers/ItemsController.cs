using GarageInventory.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GarageInventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        [HttpGet]
        [Route("api/items/{itemType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin,Manager,Viewer")]
        public async Task<IActionResult> GetItems(ItemTypes itemType)
        {
            return Ok(new { message = "Items retrieved successfully." });
        }
    }
}
