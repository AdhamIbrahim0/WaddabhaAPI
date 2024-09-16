using Waddabha.BL.DTOs.Contracts;

namespace Waddabha.BL.Managers.Contracts
{
    public interface IContractManager
    {
        Task<IEnumerable<ContractReadDTO>> GetAll();
        Task<ContractReadDTO> GetById(string id);
        Task<ContractAddDTO> Add(ContractAddDTO contractAddDTO, string username);
        Task Delete(string id);

    }
}
