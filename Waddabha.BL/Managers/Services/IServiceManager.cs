using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.BL.DTOs.Categories;
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
