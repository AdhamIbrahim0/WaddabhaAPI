using Waddabha.BL.DTOs.Services;
using Waddabha.DAL.Data.Enums;

namespace Waddabha.BL.Managers.Services
{
    public interface IServiceManager
    {
        Task<IEnumerable<ServiceReadDTO>> GetAllServicesByCategory(string id);
        Task<IEnumerable<ServiceReadDTO>> GetServicesByStatus(Status status);
        Task<ServiceReadDTO> GetById(string id);
        Task<ServiceReadDTO> Add(ServiceAddDTO serviceAddDTO);
        Task<ServiceReadDTO> Update(string id, ServiceUpdateDTO serviceUpdateDTO);
        Task<ServiceReadDTO> GetByIdWithSeller(string id);
        Task Delete(string id);
        Task ApproveService(string id);
        Task RejectService(string id, string rejectionMessage);
    }
}
