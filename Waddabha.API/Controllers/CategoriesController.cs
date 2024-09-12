using Microsoft.AspNetCore.Mvc;
using Waddabha.API.ResponseModels;
using Waddabha.BL.DTOs.Categories;
using Waddabha.BL.Managers.Categories;

namespace Waddabha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;

        public CategoriesController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryManager.GetAll();
            var response = ApiResponse<IEnumerable<CategoryReadDTO>>.SuccessResponse(categories);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await _categoryManager.GetById(id);
            var response = ApiResponse<CategoryReadDTO>.SuccessResponse(category);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDTO categoryAddDTO)
        {
            var category = await _categoryManager.Add(categoryAddDTO);
            var response = ApiResponse<CategoryReadDTO>.SuccessResponse(category);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _categoryManager.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, CategoryUpdateDTO categoryUpdateDTO)
        {
            var category = await _categoryManager.Update(id, categoryUpdateDTO);
            var response = ApiResponse<CategoryReadDTO>.SuccessResponse(category);
            return Ok(response);
        }
    }
}
