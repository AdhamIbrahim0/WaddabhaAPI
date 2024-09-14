using Microsoft.AspNetCore.Mvc;
using Waddabha.API.ResponseModels;
using Waddabha.BL.DTOs.Categories;
using Waddabha.BL.Managers.Categories;

namespace Waddabha.API.Controllers.Admin
{
    [Route("api/admin/categories")]
    [ApiController]
    public class AdminCategoriesController : AdminController
    {
        private readonly ICategoryManager _categoryManager;

        public AdminCategoriesController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryManager.GetAll();
            var response = ApiResponse<IEnumerable<CategoryReadDTO>>.SuccessResponse(categories);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryManager.GetById(id);
            var response = ApiResponse<CategoryReadDTO>.SuccessResponse(category);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Add(CategoryAddDTO categoryAddDTO)
        {
            var category = _categoryManager.Add(categoryAddDTO);
            var response = ApiResponse<CategoryReadDTO>.SuccessResponse(category);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryManager.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoryUpdateDTO categoryUpdateDTO)
        {
            var category = _categoryManager.Update(id, categoryUpdateDTO);
            var response = ApiResponse<CategoryReadDTO>.SuccessResponse(category);
            return Ok(response);
        }
    }
}
