using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Waddabha.API.ResponseModels;
using Waddabha.BL.DTOs.Contracts;
using Waddabha.BL.Managers.Contracts;

namespace Waddabha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IContractManager _contractManager;

        public ContractsController(IContractManager contractManager)
        {
            _contractManager = contractManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();  
            }
           
            var contracts = await _contractManager.GetAllByUserId(userId);

            if (contracts == null || !contracts.Any())
            {
                return NotFound("No contracts found for this user.");
            }

            var response = ApiResponse<IEnumerable<ContractReadDTO>>.SuccessResponse(contracts);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var contract = await _contractManager.GetById(id);
            var response = ApiResponse<ContractReadDTO>.SuccessResponse(contract);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ContractAddDTO contractAddDTO)
        {
            var contract = await _contractManager.Add(contractAddDTO);
            var response = ApiResponse<ContractAddDTO>.SuccessResponse(contract);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _contractManager.Delete(id);
            return NoContent();
        }

    }
}
