using Microsoft.AspNetCore.Mvc;
using Waddabha.API.ResponseModels;
using Waddabha.BL.DTOs.Auth;
using Waddabha.BL.Managers.Auth;

namespace Waddabha.API.Controllers.Admin
{
    [Route("api/admin/auth")]
    [ApiController]
    public class AdminAuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AdminAuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userDTO)
        {
            var token = await _authManager.AdminLogin(userDTO);
            var response = ApiResponse<object>.SuccessResponse(new { token });
            return Ok(response);
        }
    }
}
