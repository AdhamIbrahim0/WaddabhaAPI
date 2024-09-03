using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [Authorize]
        public IActionResult GetAll()
        {
            var categories = _categoryManager.GetAll();
            return Ok(categories);
        }
    }
}
