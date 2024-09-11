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
        IEnumerable<ServiceReadDTO> GetAllServicesByCategory(int id);
        ServiceReadDTO GetById(int id);
        void Delete(int id);

    }
}
