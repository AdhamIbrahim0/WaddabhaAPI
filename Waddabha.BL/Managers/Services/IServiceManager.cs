using Waddabha.BL.DTOs.Services;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.Managers.Services
{
    public interface IServiceManager
    {
        Task<IEnumerable<ServiceReadDTO>> GetAllServicesByCategory(string id);
        Task<ServiceReadDTO> GetById(string id);
        Task<ServiceReadDTO> Add(ServiceAddDTO serviceAddDTO, string username);
        Task<ServiceReadDTO> Update(string id, ServiceUpdateDTO serviceUpdateDTO);

        Task Delete(string id);

    }
}
