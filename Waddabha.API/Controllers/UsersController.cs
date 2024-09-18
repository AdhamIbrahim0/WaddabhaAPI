using Microsoft.AspNetCore.Mvc;
using Waddabha.API.ResponseModels;
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
        public async Task<IActionResult> GetUserDetails([FromHeader] string Authorization)
        {
            var token = Authorization.ToString().Trim().Replace("bearer ", "");
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
