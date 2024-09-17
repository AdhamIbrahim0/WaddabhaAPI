using AutoMapper;
using Waddabha.BL.CustomExceptions;
using Waddabha.BL.DTOs.Categories;
using Waddabha.BL.DTOs.Services;
using Waddabha.BL.DTOs.Users;
using Waddabha.BL.Managers.UploadImage;
using Waddabha.DAL;
using Waddabha.DAL.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Waddabha.DAL.Data.Models;
using System.Collections.Generic;


namespace Waddabha.BL.Managers.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUploadImage _uploadImage;
        private readonly UserManager<User> _userManager;
        public ServiceManager(UserManager<User> userManager,IUploadImage uploadImage, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _uploadImage = uploadImage;
            _userManager = userManager;
        }
        public async Task<IEnumerable<ServiceReadDTO>> GetAllServicesByCategory(string id)
        {
            var services = await _unitOfWork.ServiceRepository.GetAllServicesByCategory(id);
            var result = services.Select(s => new ServiceReadDTO
            {
                Name = s.Name,
                InitialPrice = s.InitialPrice,
                Description = s.Description,
                BuyerInstructions = s.BuyerInstructions,
                Images = s.Images.Select(i => new ImageDto
                {
                    ImageUrl = i.ImageUrl,
                    PublicId = i.PublicId
                }).ToList(),  // Mapping images here
                Status = s.Status.ToString(),
                Category = _mapper.Map<Category, CategoryReadDTO>(s.Category),
                Seller = _mapper.Map<Seller, SellerReadDTO>(s.Seller),
                BuyersCount = s.BuyersCount,
                Rating = s.Rating,
                CategoryId = s.CategoryId,
                Id = s.Id,
                CreatedAt = s.CreatedAt
            });

            return result;
        }

        public async Task<ServiceReadDTO> GetById(string id)
        {
            var service = await _unitOfWork.ServiceRepository.GetByIdAsync(id);
            if (service == null)
            {
                throw new RecordNotFoundException();//handle the error 
            }
            var result = _mapper.Map<Service, ServiceReadDTO>(service);
            return result;
        }
        public async Task Delete(string id)
        {
            var service = await _unitOfWork.ServiceRepository.GetByIdAsync(id);
            if (service == null)
            {
                throw new RecordNotFoundException();
            }
            await _unitOfWork.ServiceRepository.DeleteAsync(service);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<ServiceReadDTO> Add(ServiceAddDTO serviceAddDTO,string SellerId)
        {


            var newService = new Service
            {
                Name = serviceAddDTO.Name,
                InitialPrice = serviceAddDTO.InitialPrice,
                Description = serviceAddDTO.Description,
                BuyerInstructions = serviceAddDTO.BuyerInstructions,
/*                SellerId = serviceAddDTO.SellerId,
*/                CategoryId = serviceAddDTO.CategoryId,
                SellerId= SellerId
            };

            var uploadedImages = await _uploadImage.UploadImagesOnCloudinary(serviceAddDTO.Images);
            newService.Images = uploadedImages;

            var result = await _unitOfWork.ServiceRepository.AddAsync(newService);
            await _unitOfWork.SaveChangesAsync();
            var serviceRead = _mapper.Map<Service, ServiceReadDTO>(result);

            return serviceRead;
        }
        public async Task<ServiceReadDTO> Update(string id, ServiceUpdateDTO serviceUpdateDTO)
        {
            var existingService = await _unitOfWork.ServiceRepository.GetByIdAsync(id);

            if (existingService == null)
            {
                throw new RecordNotFoundException();
            }
            if (existingService.Id == id)
            {
                _mapper.Map(serviceUpdateDTO, existingService);
                var result = await _unitOfWork.ServiceRepository.UpdateAsync(existingService);

                await _unitOfWork.SaveChangesAsync();
                var serviceRead = _mapper.Map<Service, ServiceReadDTO>(result);

                return serviceRead;
            }
            return null;

        }

        public async Task<IEnumerable<ServiceReadDTO>> GetServicesByStatus(Status status)
        {
            var services = await _unitOfWork.ServiceRepository.GetServicesByStatus(status);
            var result = services.Select(s => new ServiceReadDTO
            {
                Name = s.Name,
                InitialPrice = s.InitialPrice,
                Description = s.Description,
                BuyerInstructions = s.BuyerInstructions,
                Images = s.Images.Select(i => new ImageDto
                {
                    ImageUrl = i.ImageUrl,
                    PublicId = i.PublicId
                }).ToList(),  // Mapping images here
                Status = s.Status.ToString(),
                Seller = _mapper.Map<Seller, SellerReadDTO>(s.Seller),
                BuyersCount = s.BuyersCount,
                Rating = s.Rating,
                CategoryId = s.CategoryId,
                Id = s.Id,
                CreatedAt = s.CreatedAt
            });

            return result;
        }
        public async Task<IEnumerable<ServiceReadDTO>> GetAllByUserId(string username)
        {
            var user = await _unitOfWork.UserRepository.FindByUserName(username);
            var services = await _unitOfWork.ServiceRepository.GetServicesByUserId(user.Id);
            var result = _mapper.Map<IEnumerable <Service>, IEnumerable<ServiceReadDTO>>(services);
            return result;
        }
        public async Task<ServiceReadDTO> GetByIdWithSeller(string id)
        {
            var service = await _unitOfWork.ServiceRepository.GetByIdWithSeller(id);
            if (service == null)
            {
                throw new RecordNotFoundException();//handle the error 
            }
            var result = _mapper.Map<Service, ServiceReadDTO>(service);
            return result;
        }


        public async Task ApproveService(string id)
        {
            var existingService = await _unitOfWork.ServiceRepository.GetByIdAsync(id);

            if (existingService == null)
            {
                throw new RecordNotFoundException();
            }

            existingService.Status = Status.Accepted;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RejectService(string id, string rejectionMessage)
        {
            var existingService = await _unitOfWork.ServiceRepository.GetByIdAsync(id);

            if (existingService == null)
            {
                throw new RecordNotFoundException();
            }

            existingService.Status = Status.Rejected;
            existingService.RejectionMessage = rejectionMessage;
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
