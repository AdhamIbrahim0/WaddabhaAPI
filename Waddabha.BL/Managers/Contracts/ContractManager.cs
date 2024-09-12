using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.BL.DTOs.Categories;
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

       

        public async Task<IEnumerable<ContractReadDTO>> GetAll()
        {
            var contracts =await _unitOfWork.ContractRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<Contract>,IEnumerable<ContractReadDTO>>(contracts);
            return result;
        }

        public async Task<ContractReadDTO> GetById(string id)
        {
            var contract =await _unitOfWork.ContractRepository.GetByIdAsync(id);
            if (contract == null)
            {
                throw new Exception("the contract not found!");//handle the error
            }
            var result = _mapper.Map<Contract, ContractReadDTO>(contract);

            return result; 
        }
        public async Task Delete(string id)
        {
            var contract =await _unitOfWork.ContractRepository.GetByIdAsync(id);
            if (contract == null)
            {
                throw new Exception("Contract Not Found !");
            }
           await _unitOfWork.ContractRepository.DeleteAsync(contract);
           await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ContractReadDTO> Add(ContractAddDTO contractAddDTO)
        {
                var contract = _mapper.Map<ContractAddDTO, Contract>(contractAddDTO);
                
                var result = await _unitOfWork.ContractRepository.AddAsync(contract);
                await _unitOfWork.SaveChangesAsync();
                var contractRead = _mapper.Map<Contract, ContractReadDTO>(result);
                return contractRead;
        }


    }
}
