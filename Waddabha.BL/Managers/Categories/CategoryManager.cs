using AutoMapper;
using Waddabha.BL.DTOs.Categories;
using Waddabha.DAL;
using Waddabha.DAL.Data.Models;

namespace Waddabha.BL.Managers.Categories
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public CategoryReadDTO Add(CategoryAddDTO categoryAddDTO)
        {
            var category = _mapper.Map<CategoryAddDTO ,Category>(categoryAddDTO);
            var result = _unitOfWork.CategoryRepository.Add(category);
            _unitOfWork.SaveChanges();
            var categoryRead= _mapper.Map<Category, CategoryReadDTO>(result);

            return categoryRead;


        }

        public void Delete(int id)
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

        public CategoryReadDTO GetById(int id)
        {
            var category =_unitOfWork.CategoryRepository.GetById(id);
            var result=_mapper.Map<Category,CategoryReadDTO>(category);
            return result;
        }

        public CategoryReadDTO Update(int id, CategoryUpdateDTO categoryUpdateDTO)
        { 
            var existingCategory = _unitOfWork.CategoryRepository.GetById(id);

            if (existingCategory == null)
            {
                return null; 
            }
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
