using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Waddabha.BL.Managers.Auth;
using Waddabha.BL.Managers.Categories;
using Waddabha.BL.Managers.Contracts;
using Waddabha.BL.Managers.Services;
using Waddabha.BL.MappingProfiles;

namespace Waddabha.BL
{
    public static class ServicesExtension
    {
        public static void AddBLServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(CategoryMappings));
            services.AddAutoMapper(typeof(UserMappings));

            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IContractManager,ContractManager>();
            services.AddScoped<IServiceManager, ServiceManager>();

            var jwtSettings = configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings.GetSection("Secret").Value!);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                        ValidAudience = jwtSettings.GetSection("Audience").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ClockSkew = TimeSpan.Zero
                    };
                });
            services.AddAuthorization();
        }
    }
}
