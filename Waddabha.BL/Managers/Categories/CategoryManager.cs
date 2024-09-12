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
            //category.Image = uploadedImage;
            var result = await  _unitOfWork.CategoryRepository.AddAsync(category);
             await _unitOfWork.SaveChangesAsync();
            var categoryRead = _mapper.Map<Category, CategoryReadDTO>(result);
            return categoryRead;
        }
        public void Delete(string id)
        {
            var category = _unitOfWork.CategoryRepository.GetById(id);
            if (category != null)
            {
                _unitOfWork.CategoryRepository.Delete(category);
                _unitOfWork.SaveChanges();
            }
        }

        public IEnumerable<CategoryReadDTO> GetAll()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll();
            var result = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryReadDTO>>(categories);
            return result;
        }

        public CategoryReadDTO GetById(string id)
        {
            var category = _unitOfWork.CategoryRepository.GetById(id);
            if (category is null) throw new RecordNotFoundException("Category not found");
            var result = _mapper.Map<Category, CategoryReadDTO>(category);
            return result;
        }

        public CategoryReadDTO Update(string id, CategoryUpdateDTO categoryUpdateDTO)
        {
            var existingCategory = _unitOfWork.CategoryRepository.GetById(id);

            if (existingCategory is null) throw new RecordNotFoundException("Category not found");

            if (existingCategory.Id == id)
            {
                _mapper.Map(categoryUpdateDTO, existingCategory);
                var result = _unitOfWork.CategoryRepository.Update(existingCategory);

                _unitOfWork.SaveChanges();
                var categoryRead = _mapper.Map<Category, CategoryReadDTO>(result);

                return categoryRead;
            }
            return null;
        }
    }
}
