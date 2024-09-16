using Waddabha.BL.DTOs.Contracts;

namespace Waddabha.BL.Managers.Contracts
{
    public interface IContractManager
    {
       public Task<IEnumerable<ContractReadDTO>> GetAllByUserId(string id);
        Task<ContractReadDTO> GetById(string id);
        Task<ContractAddDTO> Add(ContractAddDTO contractAddDTO, string username);
        Task Delete(string id);

    }
}
