using Waddabha.DAL.Data.Enums;
using Waddabha.DAL.Data.Models;
using Waddabha.DAL.Repositories.Generic;

namespace Waddabha.DAL.Repositories.Services
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        Task<IEnumerable<Service>> GetAllServicesByCategory(string id);
        Task<IEnumerable<Service>> GetAllServicesByName(string name);
        Task<IEnumerable<Service>> GetMyServices(string userId);
        Task<IEnumerable<Service>> GetServicesByStatus(Status status);
        Task<IEnumerable<Service>> GetServicesByUserId(string userId);
        Task<Service> GetByIdWithSeller(string id);
    }
}
