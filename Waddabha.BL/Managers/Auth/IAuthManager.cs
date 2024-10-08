﻿using Waddabha.BL.DTOs.Auth;
using Waddabha.BL.DTOs.Users;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.Managers.Auth
{
    public interface IAuthManager
    {
        Task<string> Register(UserRegisterDTO userDTO);
        Task<string> Login(UserLoginDTO userDTO);
        Task<string> AdminLogin(UserLoginDTO userDTO);
        Task<string> GenerateJWT(User user);
        Task FindByEmailAsync(string name);
        Task<bool> VerifyOtpAsync(ResetPassDTO ResetPassDTO);
        Task<Boolean> Update(EditUserDTO editUserDTO, string userId);

    }
}
