using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.BL.DTOs.Categories;
using Waddabha.BL.DTOs.Contracts;

namespace Waddabha.BL.Managers.Contracts
{
    public interface IContractManager
    {
        Task<IEnumerable<ContractReadDTO>> GetAll();
        Task<ContractReadDTO> GetById(string id);
        Task<ContractReadDTO> Add(ContractAddDTO categoryAddDTO);
        Task Delete(string id);

    }
}
