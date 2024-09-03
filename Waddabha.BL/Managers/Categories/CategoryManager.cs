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

        public IEnumerable<CategoryReadDTO> GetAll()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll();
            var result = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryReadDTO>>(categories);
            return result;
        }
    }
}
