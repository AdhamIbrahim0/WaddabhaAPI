using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var contract = _contractManager.GetAll();
            return Ok(contract);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var contract = _contractManager.GetById(id);
            return Ok(contract);
        }

    }
}
