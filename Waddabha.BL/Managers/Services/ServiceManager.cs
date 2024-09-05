using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waddabha.BL.DTOs.Categories;
using Waddabha.BL.DTOs.Contracts;
using Waddabha.BL.DTOs.Services;
using Waddabha.DAL;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.Managers.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<ServiceReadDTO> GetAll()
        {
            var contracts = _unitOfWork.ServiceRepository.GetAll();
            var result = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceReadDTO>>(contracts);
            return result;
        }
        public ServiceReadDTO GetById(int id)
        {
            var service = _unitOfWork.ServiceRepository.GetById(id);
            if(service == null)
            {
                throw new Exception();//handle the error 
            }
            var result = _mapper.Map<Service,ServiceReadDTO>(service);
            return result;
        }
        public void Delete(int id)
        {

            var service = _unitOfWork.ServiceRepository.GetById(id);
            if (service == null)
            {
                throw new Exception();
            }
            _unitOfWork.ServiceRepository.Delete(service);
            _unitOfWork.SaveChanges();

        }

        
    }
}
