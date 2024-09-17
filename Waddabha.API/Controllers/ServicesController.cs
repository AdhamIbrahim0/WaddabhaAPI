using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Waddabha.API.ResponseModels;
using Waddabha.BL.DTOs.Services;
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
        public async Task<IActionResult> GetAll([FromQuery] string categoryId)
        {
            var services = await _serviceManager.GetAllServicesByCategory(categoryId);
            var response = ApiResponse<IEnumerable<ServiceReadDTO>>.SuccessResponse(services);
            return Ok(response);
        }

        [Authorize(Roles = "Seller")]
        [HttpGet("myservices")]
        public async Task<IActionResult> GetMyServices()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var services = await _serviceManager.GetMyServices(userId);
            var response = ApiResponse<IEnumerable<ServiceReadDTO>>.SuccessResponse(services);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var service = await _serviceManager.GetByIdWithSeller(id);
            var response = ApiResponse<ServiceReadDTO>.SuccessResponse(service);
            return Ok(response);
        }

        [HttpGet("service-by-userId")]
        public async Task<IActionResult> GetServicesByUserId()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var services = await _serviceManager.GetAllByUserId(userId);

            if (services == null || !services.Any())
            {
                return NotFound("No contracts found for this user.");
            }

            var response = ApiResponse<IEnumerable<ServiceReadDTO>>.SuccessResponse(services);
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
        [Authorize(Roles = "Seller")]
        public async Task<IActionResult> Add(ServiceAddDTO serviceAddDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

/*            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();  // Handle missing user ID
            }*/
            var service = await _serviceManager.Add(serviceAddDTO,userId);
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
