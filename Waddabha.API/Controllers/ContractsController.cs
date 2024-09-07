using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll()
        {
            var contracts = _contractManager.GetAll();
            var response = ApiResponse<IEnumerable<ContractReadDTO>>.SuccessResponse(contracts);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contract = _contractManager.GetById(id);
            var response = ApiResponse<ContractReadDTO>.SuccessResponse(contract);
            return Ok(response);
        }
    }
}
