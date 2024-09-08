using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Waddabha.API.ResponseModels;
using Waddabha.BL.DTOs.Categories;
using Waddabha.BL.DTOs.Users;
using Waddabha.BL.Managers.Users;

namespace Waddabha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserManager _userManager;
        public UsersController(IUserManager userManager)
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
                var user = await _userManager.GetUserFromTokenAsync(token);
                var result = ApiResponse<GetUserDTO>.SuccessResponse(user);
                return Ok(result);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Invalid or expired token");
            }
        }


    }
}
