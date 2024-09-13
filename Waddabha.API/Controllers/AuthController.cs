﻿using Microsoft.AspNetCore.Mvc;
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
            var response = ApiResponse<object>.SuccessResponse(new { token });
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userDTO)
        {
            var token = await _authManager.Login(userDTO);
            var response = ApiResponse<object>.SuccessResponse(new { token });
            return Ok(response);
        }
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] string email)
        {
            if (email == null)
            {
                throw new Exception("البريد الإلكتروني مطلوب");
            }

            await _authManager.FindByEmailAsync(email);

            var successResponse = ApiResponse<string>.SuccessResponse("تم إرسال رمز التحقق بنجاح");
            return Ok(successResponse);

        }

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyPassword([FromBody] ResetPassDTO resetPassDTO)
        {
            var result = await _authManager.VerifyOtpAsync(resetPassDTO);

            if (!result)
            {
                var errorResponse = ApiResponse<string>.ErrorResponse(new List<string> { "فشل التحقق من رمز التحقق أو الرمز غير صحيح." });
                return BadRequest(errorResponse);
            }
            else
            {
                var successResponse = ApiResponse<string>.SuccessResponse("تم إعادة تعيين كلمة المرور بنجاح.");
                return Ok(successResponse);
            }
        }



    }
}
