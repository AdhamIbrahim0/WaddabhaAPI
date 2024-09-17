using AutoMapper;
using Waddabha.BL.DTOs.Contracts;
using Waddabha.DAL;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.Managers.Contracts
{
    public class ContractManager : IContractManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ContractManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContractReadDTO>> GetAllByUserId(string username)
        {
            var user = await _unitOfWork.UserRepository.FindByUserName(username);

            var contracts = await _unitOfWork.ContractRepository.GetContractsByUserId(user.Id);
            var result = _mapper.Map<IEnumerable<Contract>, IEnumerable<ContractReadDTO>>(contracts);
            return result;
        }

        public async Task<ContractReadDTO> GetById(string id)
        {
            var contract = await _unitOfWork.ContractRepository.GetByIdAsync(id);
            if (contract == null)
            {
                throw new Exception("the contract not found!");//handle the error
            }
            var result = _mapper.Map<Contract, ContractReadDTO>(contract);

            return result;
        }
        public async Task Delete(string id)
        {
            var contract = await _unitOfWork.ContractRepository.GetByIdAsync(id);
            if (contract == null)
            {
                throw new Exception("Contract Not Found !");
            }
            await _unitOfWork.ContractRepository.DeleteAsync(contract);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ContractAddDTO> Add(ContractAddDTO contractAddDTO, string userId)
        {
            var service = await _unitOfWork.ServiceRepository.GetByIdAsync(contractAddDTO.ServiceId);

            contractAddDTO.ServiceId = service.Id;
            var contract = _mapper.Map<ContractAddDTO, Contract>(contractAddDTO);

            contract.BuyerId = userId;
            contract.SellerId = service.SellerId;
            var chatRoom = new ChatRoom
            {
                BuyerId = userId,
                SellerId = service.SellerId,
            };

            var chatRoomResult = await _unitOfWork.ChatRoomRepository.AddAsync(chatRoom);
            contract.ChatRoomId = chatRoomResult.Id;

            var result = await _unitOfWork.ContractRepository.AddAsync(contract);
            chatRoom.ContractId = result.Id;

            await _unitOfWork.SaveChangesAsync();
            var contractadd = _mapper.Map<Contract, ContractAddDTO>(result);
            return contractadd;
        }



    }
}
