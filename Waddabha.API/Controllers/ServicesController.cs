using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Waddabha.BL.Managers.Services;

namespace Waddabha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ServicesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var service = _serviceManager.GetAll();
            return Ok(service);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var service = _serviceManager.GetById(id);
            return Ok(service);
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            var service = _serviceManager.GetById(id);
            _serviceManager.Delete(service.Id);
            return NoContent();
        }

    }
}
