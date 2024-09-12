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
        public IActionResult GetAll()
        {
            //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var categories = _categoryManager.GetAll();
            var response = ApiResponse<IEnumerable<CategoryReadDTO>>.SuccessResponse(categories);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var category = _categoryManager.GetById(id);
            var response = ApiResponse<CategoryReadDTO>.SuccessResponse(category);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDTO categoryAddDTO)
        {
            var category =await _categoryManager.Add(categoryAddDTO);
            var response =  ApiResponse<CategoryReadDTO>.SuccessResponse(category);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _categoryManager.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, CategoryUpdateDTO categoryUpdateDTO)
        {
            var category = _categoryManager.Update(id, categoryUpdateDTO);
            var response = ApiResponse<CategoryReadDTO>.SuccessResponse(category);
            return Ok(response);
        }

    }
}
