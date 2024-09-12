using Microsoft.AspNetCore.Mvc;
using Waddabha.API.ResponseModels;
using Waddabha.BL.DTOs.Services;
using Waddabha.BL.Managers.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAll([FromQuery] string categoryId)
        {
            var services = await _serviceManager.GetAllServicesByCategory(categoryId);
            var response = ApiResponse<IEnumerable<ServiceReadDTO>>.SuccessResponse(services);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var service = await _serviceManager.GetById(id);
            var response = ApiResponse<ServiceReadDTO>.SuccessResponse(service);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            var service = await _serviceManager.GetById(id);
            if (service == null)
            {
                return NotFound();
            }
            await _serviceManager.Delete(service.Id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ServiceAddDTO serviceAddDTO)
        {
            var service = await _serviceManager.Add(serviceAddDTO);
            var response = ApiResponse<ServiceReadDTO>.SuccessResponse(service);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, ServiceUpdateDTO serviceUpdateDTO)
        {
            var service = await _serviceManager.Update(id, serviceUpdateDTO);
            if (service == null)
            {
                return NotFound();
            }
            var response = ApiResponse<ServiceReadDTO>.SuccessResponse(service);
            return Ok(response);
        }
    }
}
