using Microsoft.AspNetCore.Mvc;
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
            var result = await _authManager.Register(userDTO);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userDTO)
        {
            var result = await _authManager.Login(userDTO);
            return Ok(result);
        }
    }
}
