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
        IEnumerable<ServiceReadDTO> GetAllServicesByCategory(string id);
        ServiceReadDTO GetById(string id);
        ServiceReadDTO Add(ServiceAddDTO serviceAddDTO);
        ServiceReadDTO Update(string id, ServiceUpdateDTO serviceUpdateDTO);

        void Delete(string id);

    }
}
