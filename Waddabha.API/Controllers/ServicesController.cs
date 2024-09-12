using Microsoft.AspNetCore.Mvc;
using Waddabha.API.ResponseModels;
using Waddabha.BL.DTOs.Services;
using Waddabha.BL.Managers.Services;
using Waddabha.DAL.Data.Models;

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
        public IActionResult GetAll([FromQuery] string categoryId)
        {
            var services = _serviceManager.GetAllServicesByCategory(categoryId);
            var response = ApiResponse<IEnumerable< ServiceReadDTO>>.SuccessResponse(services);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var service = _serviceManager.GetById(id);
            var response = ApiResponse<ServiceReadDTO>.SuccessResponse(service);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult DeleteById(string id)
        {
            var service = _serviceManager.GetById(id);
            _serviceManager.Delete(service.Id);
            return NoContent();
        }
        [HttpPost]
        public IActionResult Add(ServiceAddDTO serviceAddDTO)
        {
            var service = _serviceManager.Add(serviceAddDTO);
            var response = ApiResponse<ServiceReadDTO>.SuccessResponse(service);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id,ServiceUpdateDTO serviceUpdateDTO)
        {
            var service = _serviceManager.Update(id, serviceUpdateDTO);
            var response = ApiResponse<ServiceReadDTO>.SuccessResponse(service);
            return Ok(response);
        }
    }
}
