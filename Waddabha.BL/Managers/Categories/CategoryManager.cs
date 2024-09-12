using AutoMapper;
using Waddabha.BL.CustomExceptions;
using Waddabha.BL.DTOs.Categories;
using Waddabha.BL.Managers.UploadImage;
using Waddabha.DAL;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.Managers.Categories
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUploadImage _uploadImage;

        public CategoryManager(IUploadImage uploadImage,IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _uploadImage = uploadImage;
        }

        public async Task<CategoryReadDTO> Add(CategoryAddDTO categoryAddDTO)
        {
            var category = _mapper.Map<CategoryAddDTO, Category>(categoryAddDTO);
            var uploadedImage = await _uploadImage.UploadImageOnCloudinary(categoryAddDTO.Image);
            category.Image = uploadedImage;
            var result = await  _unitOfWork.CategoryRepository.AddAsync(category);
             await _unitOfWork.SaveChangesAsync();
            var categoryRead = _mapper.Map<Category, CategoryReadDTO>(result);
            return categoryRead;
        }
        public async Task Delete(string id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category != null)
            {
                _unitOfWork.CategoryRepository.DeleteAsync(category);
                _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CategoryReadDTO>> GetAll()
        {
            var categories =await _unitOfWork.CategoryRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryReadDTO>>(categories);
            return result;
        }

        public async Task<CategoryReadDTO> GetById(string id)
        {
            var category =await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category is null) throw new RecordNotFoundException("Category not found");
            var result = _mapper.Map<Category, CategoryReadDTO>(category);
            return result;
        }

        public async Task<CategoryReadDTO> Update(string id, CategoryUpdateDTO categoryUpdateDTO)
        {
            var existingCategory = await _unitOfWork.CategoryRepository.GetByIdAsync(id);

            if (existingCategory is null) throw new RecordNotFoundException("Category not found");

            if (existingCategory.Id == id)
            {
                _mapper.Map(categoryUpdateDTO, existingCategory);
                var result = await _unitOfWork.CategoryRepository.UpdateAsync(existingCategory);

                _unitOfWork.SaveChangesAsync();
                var categoryRead = _mapper.Map<Category, CategoryReadDTO>(result);

                return categoryRead;
            }
            return null;
        }
    }
}
