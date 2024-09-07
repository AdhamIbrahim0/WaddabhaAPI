using Microsoft.AspNetCore.Mvc;
using Waddabha.API.ResponseModels;
using Waddabha.BL.DTOs.Auth;
using Waddabha.BL.Managers.Auth;

namespace Waddabha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO userDTO)
        {
            var token = await _authManager.Register(userDTO);
            var response = ApiResponse<string>.SuccessResponse(token);
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userDTO)
        {
            var token = await _authManager.Login(userDTO);
            var response = ApiResponse<string>.SuccessResponse(token);
            return Ok(response);
        }
    }
}
