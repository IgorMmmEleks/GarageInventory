using GarageInventory.Core.Services.Interfaces;
using GarageInventory.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GarageInventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolController : ControllerBase
    {
        private readonly IToolService _toolService;

        public ToolController(IToolService toolService)
        {
            _toolService = toolService;
        }


        #region GET

        [HttpGet]
        [Route("{toolType}/count")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Admin,Manager,Viewer")]
        public async Task<IActionResult> GetToolsCount([FromRoute] ToolTypes toolType)
        {
            var result = await _toolService.GetCountAsync(toolType);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return result.Error switch
                {
                    OperationResultErrors.NotFound => NotFound(new { message = $"No tools, type of {toolType}, were found." }),
                    OperationResultErrors.Exception => Problem("An exception occurred while retrieving tools."),
                    _ => BadRequest(new { message = "An error occurred while retrieving tools." })
                };
            }
        }

        [HttpGet]
        [Route("{toolType}/paginated")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = "Admin,Manager,Viewer")]
        public async Task<IActionResult> GetTools(
            [FromRoute] ToolTypes toolType,
            [FromQuery] int skip = 0,
            [FromQuery] int take = 10)
        {
            var result = await _toolService.GetAsync(toolType, skip, take);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return result.Error switch
                {
                    OperationResultErrors.NotFound => NotFound(new { message = $"No tools, type of {toolType}, were found." }),
                    OperationResultErrors.Exception => Problem("An exception occurred while retrieving tools."),
                    _ => BadRequest(new { message = "An error occurred while retrieving tools." })
                };
            }
        }
        #endregion

        #region POST

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> AddTool(
            [FromBody] ToolDto toolDto)
        {
            var result = await _toolService.AddAsync();

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return result.Error switch
                {
                    OperationResultErrors.NotFound => NotFound(new { message = $"No tools, type of {toolType}, were found." }),
                    OperationResultErrors.Exception => Problem("An exception occurred while retrieving tools."),
                    _ => BadRequest(new { message = "An error occurred while retrieving tools." })
                };
            }
        }

        #endregion
    }
}
