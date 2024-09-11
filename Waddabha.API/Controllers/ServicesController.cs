using Microsoft.AspNetCore.Mvc;
using Waddabha.API.ResponseModels;
using Waddabha.BL.DTOs.Categories;
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
        public IActionResult GetAll()
        {
            var services = _serviceManager.GetAll();
            return Ok(services);
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
        [HttpPost]
        public IActionResult Add(ServiceAddDTO serviceAddDTO)
        {
            var service = _serviceManager.Add(serviceAddDTO);
            var response = ApiResponse<ServiceReadDTO>.SuccessResponse(service);
            return Ok(response);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,ServiceUpdateDTO serviceUpdateDTO)
        {
            var service = _serviceManager.Update(id, serviceUpdateDTO);
            var response = ApiResponse<ServiceReadDTO>.SuccessResponse(service);
            return Ok(response);
        }
    }
}
