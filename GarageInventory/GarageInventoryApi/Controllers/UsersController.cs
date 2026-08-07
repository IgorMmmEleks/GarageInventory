using GarageInventory.Core.Database.Interfaces;
using GarageInventory.Core.DTOs.Users;
using GarageInventory.Core.Models.Users;
using GarageInventory.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GarageInventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        private const string SessionCookieName = "Session";
        private const int CookieExpirationDays = 7;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Helper method to set session cookie with UserId and SessionId
        /// </summary>
        private void SetSessionCookie(Guid userId)
        {
            var sessionId = Guid.NewGuid().ToString();
            var cookieValue = $"{userId}|{sessionId}";

            Response.Cookies.Append(SessionCookieName, cookieValue, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddDays(CookieExpirationDays)
            });
        }

        /// <summary>
        /// Helper method to clear session cookie
        /// </summary>
        private void ClearSessionCookie()
        {
            Response.Cookies.Delete(SessionCookieName);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            try
            {
                if (await _userService.UserExistsAsync((string?)userDto.Email))
                {
                    return base.BadRequest(new { message = "User with this email already exists." });
                }

                var user = await _userService.CreateAsync((CreateUserDto)userDto);

                // Set session cookie with user ID and session ID
                SetSessionCookie(user.Id);

                return base.CreatedAtAction(nameof(CreateUser), new { nickname = user.Login },
                    new { userId=user, message = "User created successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Error creating user: {ex.Message}" });
            }
        }
    }
}
