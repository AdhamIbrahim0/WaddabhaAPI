using Microsoft.Extensions.DependencyInjection;
using Waddabha.BL.Managers.Categories;
using Waddabha.BL.MappingProfiles;

namespace Waddabha.BL
{
    public static class ServicesExtension
    {
        public static void AddBLServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CategoryProfile));
            services.AddScoped<ICategoryManager, CategoryManager>();
        }
    }
}
