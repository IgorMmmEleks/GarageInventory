using GarageInventory.Core.DTOs.Users;
using GarageInventory.Core.Services.Interfaces;
using GarageInventory.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GarageInventory.Api.Controllers
{
    /// <summary>
    /// Controller that provides endpoints to manage users.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Retrieves a paged list of users.
        /// </summary>
        /// <param name="skip">Number of records to skip (paging offset).</param>
        /// <param name="take">Number of records to take (page size).</param>
        /// <returns>
        /// Returns 200 OK with the users collection when successful; otherwise returns an appropriate error response
        /// (404 NotFound when no users were found, 500 Problem on exception, or 400 BadRequest for other errors).
        /// </returns>
        [Authorize(Roles = "Admin")]
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllUsers(int skip = 0, int take = 10)
        {
            var result = await _userService.GetAllAsync(skip, take);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return result.Error switch
                {
                    OperationResultErrors.NotFound => NotFound(new { message = "No users found." }),
                    OperationResultErrors.Exception => Problem("An exception occurred while retrieving users."),
                    _ => BadRequest(new { message = "An error occurred while retrieving users." })
                };
            }
        }

        /// <summary>
        /// Retrieves a single user by login.
        /// </summary>
        /// <param name="userLogin">Login identifier of the user to retrieve.</param>
        /// <returns>
        /// Returns 200 OK with the user data when found; 404 NotFound when the user does not exist; 500 Problem on exception;
        /// otherwise 400 BadRequest for other errors.
        /// </returns>
        [Authorize(Roles = "Admin")]
        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUser(string userLogin)
        {
            var result = await _userService.GetAsync(userLogin);

            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return result.Error switch
                {
                    OperationResultErrors.NotFound => NotFound(new { message = "User not found." }),
                    OperationResultErrors.Exception => Problem("An exception occurred while retrieving the user."),
                    _ => BadRequest(new { message = "An error occurred while retrieving the user." })
                };
            }
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="userDto">Data transfer object containing information required to create the user.</param>
        /// <returns>
        /// Returns 201 Created with the created user's login when successful; 409 Conflict when the user already exists;
        /// 400 BadRequest for validation or other errors; 500 Problem on exception.
        /// </returns>
        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            var result = await _userService.CreateAsync(userDto);

            if(result.IsSuccess)
            {
                return base.CreatedAtAction(nameof(CreateUser), new { login = result.Value.Login, message = "User created successfully." });
            }
            else
            {
                return result.Error switch
                {
                    OperationResultErrors.Invalid => ValidationProblem("Validation error occurred while creating the user." ),
                    OperationResultErrors.AlreadyExists => Conflict(new { message = "User with the same login already exists." }),
                    OperationResultErrors.Exception => Problem("An exception occurred while creating the user." ),
                    _ => BadRequest(new { message = "An error occurred while creating the user." })
                };
            }
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="userDto">Data transfer object containing updated user information.</param>
        /// <returns>
        /// Returns 200 OK when the update succeeds; 404 NotFound when the user does not exist; 400 BadRequest for validation or other errors;
        /// 500 Problem on exception.
        /// </returns>
        [Authorize(Roles = "Admin")]
        [HttpPost("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto userDto)
        {
            var result = await _userService.UpdateAsync(userDto);

            if (result.IsSuccess)
            {
                return Ok(new { message = "User updated successfully." });
            }
            else
            {
                return result.Error switch
                {
                    OperationResultErrors.Invalid => ValidationProblem("Validation error occurred while updating the user."),
                    OperationResultErrors.NotFound => NotFound(new { message = "User not found." }),
                    OperationResultErrors.Exception => Problem("An exception occurred while updating the user."),
                    _ => BadRequest(new { message = "An error occurred while updating the user." })
                };
            }
        }

        /// <summary>
        /// Deletes an existing user identified by id or login.
        /// </summary>
        /// <param name="userId">Unique identifier of the user to delete.</param>
        /// <returns>
        /// Returns 200 OK when deletion succeeds; 404 NotFound when the user does not exist; 500 Problem on exception; otherwise 400 BadRequest.
        /// </returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser(Guid? userId)
        {
            if (userId == null || Guid.Empty == userId)
                return BadRequest(new { message = "User ID is required." });

            var result = await _userService.DeleteAsync(userId.Value);

            if (result.IsSuccess)
            {
                return Ok(new { message = "User deleted successfully." });
            }
            else
            {
                return result.Error switch
                {
                    OperationResultErrors.NotFound => NotFound(new { message = "User not found." }),
                    OperationResultErrors.Exception => Problem("An exception occurred while deleting the user."),
                    _ => BadRequest(new { message = "An error occurred while deleting the user." })
                };
            }
        }
    }
}