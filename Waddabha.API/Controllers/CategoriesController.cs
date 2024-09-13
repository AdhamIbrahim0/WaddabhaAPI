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
        public IActionResult GetAll()
        {
            //var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
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

    }
}
