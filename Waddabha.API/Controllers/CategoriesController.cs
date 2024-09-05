using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var categories = _categoryManager.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryManager.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Add(CategoryAddDTO categoryAddDTO)
        {
            var category = _categoryManager.Add(categoryAddDTO); 
            return Ok(category);

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
            return Ok(category);

        }

    }
}
