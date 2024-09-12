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
        public async Task<IEnumerable<ServiceReadDTO>> GetAllServicesByCategory(string id)
        {
            var contracts =await _unitOfWork.ServiceRepository.GetAllServicesByCategory(id);
            var result = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceReadDTO>>(contracts);
            return result;
        }
        public async Task<ServiceReadDTO> GetById(string id)
        {
            var service = await _unitOfWork.ServiceRepository.GetByIdAsync(id);
            if(service == null)
            {
                throw new Exception();//handle the error 
            }
            var result = _mapper.Map<Service,ServiceReadDTO>(service);
            return result;
        }
        public async Task Delete(string id)
        {

            var service = await _unitOfWork.ServiceRepository.GetByIdAsync(id);
            if (service == null)
            {
                throw new Exception();
            }
           await _unitOfWork.ServiceRepository.DeleteAsync(service);
            _unitOfWork.SaveChangesAsync();

        }
        public async Task<ServiceReadDTO> Add(ServiceAddDTO serviceAddDTO)
        {
            var service = _mapper.Map<ServiceAddDTO, Service>(serviceAddDTO);
            var result =await _unitOfWork.ServiceRepository.AddAsync(service);
          await  _unitOfWork.SaveChangesAsync();
            var serviceRead = _mapper.Map<Service, ServiceReadDTO>(result);

            return serviceRead;
        }
        public async Task<ServiceReadDTO> Update(string id, ServiceUpdateDTO serviceUpdateDTO)
        {
            var existingService =await _unitOfWork.ServiceRepository.GetByIdAsync(id);

            if (existingService == null)
            {
                return null;
            }
            if (existingService.Id == id)
            {
                _mapper.Map(serviceUpdateDTO, existingService);
                var result =await _unitOfWork.ServiceRepository.UpdateAsync(existingService);

                _unitOfWork.SaveChangesAsync();
                var serviceRead = _mapper.Map<Service, ServiceReadDTO>(result);

                return serviceRead;
            }
            return null;

        }



    }
}
