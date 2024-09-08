using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Waddabha.BL.Managers.Users;

namespace Waddabha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserManager _userManager;
        public UsersController(UserManager userManager)
        {
            _userManager = userManager;
        }
        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetUserDetails()
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest("Token is missing");
            }
            try
            {
                var userDto = await _userManager.GetUserFromTokenAsync(token);
                return Ok(userDto);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Invalid or expired token");
            }
        }


    }
}
