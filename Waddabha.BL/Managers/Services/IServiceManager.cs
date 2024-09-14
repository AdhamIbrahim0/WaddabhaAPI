using Waddabha.BL.DTOs.Services;

namespace Waddabha.BL.Managers.Services
{
    public interface IServiceManager
    {
        Task<IEnumerable<ServiceReadDTO>> GetAllServicesByCategory(string id);
        Task<ServiceReadDTO> GetById(string id);
        Task<ServiceReadDTO> Add(ServiceAddDTO serviceAddDTO);
        Task<ServiceReadDTO> Update(string id, ServiceUpdateDTO serviceUpdateDTO);

        Task Delete(string id);

    }
}
