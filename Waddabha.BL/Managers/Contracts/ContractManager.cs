using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

       

        public IEnumerable<ContractReadDTO> GetAll()
        {
            var contracts = _unitOfWork.ContractRepository.GetAll();
            var result = _mapper.Map<IEnumerable<Contract>,IEnumerable<ContractReadDTO>>(contracts);
            return result;
        }

        public ContractReadDTO GetById(string id)
        {
            var contract = _unitOfWork.ContractRepository.GetById(id);
            if (contract == null)
            {
                throw new Exception("the contract not found!");//handle the error
            }
            var result = _mapper.Map<Contract, ContractReadDTO>(contract);

            return result; 
        }
        public void Delete(string id)
        {
            var contract = _unitOfWork.ContractRepository.GetById(id);
            if (contract == null)
            {
                throw new Exception("Contract Not Found !");
            }
            _unitOfWork.ContractRepository.Delete(contract);
            _unitOfWork.SaveChanges();
        }


    }
}
