using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Waddabha.BL.CustomExceptions;
using Waddabha.BL.DTOs.Contracts;
using Waddabha.DAL;
using Waddabha.DAL.Data.Enums;
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

        public async Task<IEnumerable<ContractReadDTO>> GetAllByUserId(string userId)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);

            var contracts = await _unitOfWork.ContractRepository.GetContractsByUserId(userId);
            var result = _mapper.Map<IEnumerable<Contract>, IEnumerable<ContractReadDTO>>(contracts);
            return result;
        }

        public async Task<ContractReadDTO> GetById(string id)
        {
            var contract = await _unitOfWork.ContractRepository.GetContract(id);
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

        [Authorize(Roles = "Buyer")]
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
                ContractId = contract.Id
            };

            var exisitingChatRooms = await _unitOfWork.ChatRoomRepository.GetChatRoomsByUserId(userId);
            var existingChatRoom = exisitingChatRooms.FirstOrDefault(cr => cr.BuyerId == userId && cr.SellerId == contract.SellerId);
            if (existingChatRoom == null)
            {
                var chatRoomResult = await _unitOfWork.ChatRoomRepository.AddAsync(chatRoom);
                contract.ChatRoomId = chatRoomResult.Id;
            }
            else
            {
                contract.ChatRoomId = existingChatRoom.Id;
            }

            var result = await _unitOfWork.ContractRepository.AddAsync(contract);
            chatRoom.ContractId = result.Id;

            await _unitOfWork.SaveChangesAsync();
            var contractadd = _mapper.Map<Contract, ContractAddDTO>(result);
            return contractadd;
        }

        public async Task AcceptContract(string id)
        {
            var existingContract = await _unitOfWork.ContractRepository.GetByIdAsync(id);

            if (existingContract == null)
            {
                throw new RecordNotFoundException();
            }

            existingContract.Status = Status.Accepted;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RejectContract(string id)
        {
            var existingContract = await _unitOfWork.ContractRepository.GetByIdAsync(id);

            if (existingContract == null)
            {
                throw new RecordNotFoundException();
            }

            existingContract.Status = Status.Rejected;
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
