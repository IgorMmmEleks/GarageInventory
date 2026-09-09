using GarageInventory.Core.DTOs.Items;
using GarageInventory.Core.DTOs.Tools;
using GarageInventory.Core.Results;
using GarageInventory.Core.Services.Interfaces;
using GarageInventory.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GarageInventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly IItemsService _itemsService;

        public ItemsController(IItemsService itemsService)
        {
            _itemsService = itemsService;
        }


        #region Tools


        #endregion


        //GET all items by type, with pagination
        //GET all items by type count

        //POST add new item
        //PUT update item


        #region GET
        [HttpGet]
        [Route("{itemType}/count")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin,Manager,Viewer")]
        public async Task<IActionResult> GetItemsCount(
            [FromRoute] ItemTypes itemType,
            [FromQuery] int itemSubType = 0,
            [FromQuery] int skip = 0,
            [FromQuery] int take = 10)
        {
            var result = await _itemsService.GetCountAsync(itemType, itemSubType, skip, take);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return result.Error switch
                {
                    OperationResultErrors.NotFound => NotFound(new { message = "No items found." }),
                    OperationResultErrors.Exception => Problem("An exception occurred while retrieving items."),
                    _ => BadRequest(new { message = "An error occurred while retrieving items." })
                };
            }
        }

        [HttpGet]
        [Route("{itemType}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin,Manager,Viewer")]
        public async Task<IActionResult> GetItems(
            [FromRoute] ItemTypes itemType,
            [FromQuery] int itemSubType = 0,
            [FromQuery] int skip = 0,
            [FromQuery] int take = 10)
        {
            var result = await _itemsService.GetAsync(itemType, itemSubType, skip, take);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return result.Error switch
                {
                    OperationResultErrors.NotFound => NotFound(new { message = "No items found." }),
                    OperationResultErrors.Exception => Problem("An exception occurred while retrieving items."),
                    _ => BadRequest(new { message = "An error occurred while retrieving items." })
                };
            }
        }
        #endregion

        #region POST
        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> AddItem(
            [FromBody] CreateItemDto item)
        {

            //TODO Update Code
            var result = OperationResult<IEnumerable<ItemToolDto>>.Failure(OperationResultErrors.None); // await _itemsService.AddAsync(item); 

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return result.Error switch
                {
                    OperationResultErrors.Exception => Problem("An exception occurred while adding the item."),
                    _ => BadRequest(new { message = "An error occurred while adding the item." })
                };
            }
        }
        #endregion

    }
}
