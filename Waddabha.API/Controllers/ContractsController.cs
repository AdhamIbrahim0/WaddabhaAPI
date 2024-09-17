using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Waddabha.API.ResponseModels;
using Waddabha.BL.DTOs.Contracts;
using Waddabha.BL.DTOs.Requests;
using Waddabha.BL.Managers.Contracts;

namespace Waddabha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [Authorize(Roles ="Buyer")]
        public async Task<IActionResult> Add([FromBody] ContractAddDTO contractAddDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var contract = await _contractManager.Add(contractAddDTO, userId);
            var response = ApiResponse<ContractAddDTO>.SuccessResponse(contract);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _contractManager.Delete(id);
            return NoContent();
        }
        [HttpPost("accept")]
        public async Task<IActionResult> AcceptContract([FromBody] IdRequest request)
        {
            await _contractManager.AcceptContract(request.Id);
            var response = ApiResponse<string>.SuccessResponse("Contract accepted successfully");
            return Ok(response);
        }

        [HttpPost("reject")]
        public async Task<IActionResult> RejectContract([FromBody] IdRequest request)
        {
            await _contractManager.RejectContract(request.Id);
            var response = ApiResponse<string>.SuccessResponse("Contract rejected successfully");
            return Ok(response);
        }
    }
}
