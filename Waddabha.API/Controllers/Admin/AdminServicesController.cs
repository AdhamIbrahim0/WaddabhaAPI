using Microsoft.AspNetCore.Mvc;
using Waddabha.API.ResponseModels;
using Waddabha.BL.DTOs.Requests;
using Waddabha.BL.DTOs.Services;
using Waddabha.BL.Managers.Services;
using Waddabha.DAL.Data.Enums;

namespace Waddabha.API.Controllers.Admin
{
    [Route("api/admin/services")]
    [ApiController]
    public class AdminServicesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public AdminServicesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllServicesByCategory([FromQuery] string categoryId)
        //{
        //    var services = await _serviceManager.GetAllServicesByCategory(categoryId);
        //    var response = ApiResponse<IEnumerable<ServiceReadDTO>>.SuccessResponse(services);
        //    return Ok(response);
        //}

        [HttpGet]
        public async Task<IActionResult> GetServicesByStatus([FromQuery] Status status)
        {
            var services = await _serviceManager.GetServicesByStatus(status);
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

        [HttpPost("approve")]
        public async Task<IActionResult> ApproveService([FromBody] IdRequest request)
        {
            await _serviceManager.ApproveService(request.Id);
            var response = ApiResponse<string>.SuccessResponse("Service approved successfully");
            return Ok(response);
        }

        [HttpPost("reject")]
        public async Task<IActionResult> RejectService([FromBody] RejectServiceRequest request)
        {
            await _serviceManager.RejectService(request.Id, request.RejectionMessage);
            var response = ApiResponse<string>.SuccessResponse("Service rejected successfully");
            return Ok(response);
        }
    }
}
