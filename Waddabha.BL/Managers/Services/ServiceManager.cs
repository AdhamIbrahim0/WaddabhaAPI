using AutoMapper;
using Waddabha.BL.DTOs.Services;
using Waddabha.BL.DTOs.Users;
using Waddabha.BL.Managers.UploadImage;
using Waddabha.DAL;
using Waddabha.DAL.Data.Models;
using Waddabha.DAL.Data.Enums;
using Microsoft.AspNetCore.Identity;

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
                Status=s.Status,
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
                throw new Exception();//handle the error 
            }
            var result = _mapper.Map<Service, ServiceReadDTO>(service);
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
        public async Task<ServiceReadDTO> Add(ServiceAddDTO serviceAddDTO,string SellerId)
        {
            var seller = await _unitOfWork.UserRepository.FindByUserName(SellerId);

            var roles = await _userManager.GetRolesAsync(seller);

            if (!roles.Contains("Seller"))
            {
                throw new UnauthorizedAccessException("User is not authorized to add a service.");
            }

            var newService = new Service
            {
                Name = serviceAddDTO.Name,
                InitialPrice = serviceAddDTO.InitialPrice,
                Description = serviceAddDTO.Description,
                BuyerInstructions = serviceAddDTO.BuyerInstructions,
/*                SellerId = serviceAddDTO.SellerId,
*/                CategoryId = serviceAddDTO.CategoryId,
                SellerId= seller.Id
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
                return null;
            }
            if (existingService.Id == id)
            {
                _mapper.Map(serviceUpdateDTO, existingService);
                var result = await _unitOfWork.ServiceRepository.UpdateAsync(existingService);

                _unitOfWork.SaveChangesAsync();
                var serviceRead = _mapper.Map<Service, ServiceReadDTO>(result);

                return serviceRead;
            }
            return null;

        }



    }
}
