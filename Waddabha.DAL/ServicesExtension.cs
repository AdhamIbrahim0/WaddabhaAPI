using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Waddabha.DAL.Data.Context;
using Waddabha.DAL.Repositories.Categories;
using Waddabha.DAL.Repositories.Contracts;
using Waddabha.DAL.Repositories.Messages;
using Waddabha.DAL.Repositories.Notifications;
using Waddabha.DAL.Repositories.Services;

namespace Waddabha.DAL
{
    public static class ServicesExtension
    {
        public static void AddDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
