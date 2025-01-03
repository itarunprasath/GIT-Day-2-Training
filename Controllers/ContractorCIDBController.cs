using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Task1_ContractorV1.Model;
using Task1_ContractorV1.Services;

namespace Task1_ContractorV1.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContractorCIDBController : ControllerBase

    {
        private readonly IContractorService _contractorService;

        public ContractorCIDBController(IContractorService contractorService)
        {
            _contractorService = contractorService;
        }
        [HttpGet]
        //public ActionResult<List<Contractor>> GetContractorInfo([FromQuery][Required] string CIDBNO, [FromQuery][Required] string SSMNO, [FromQuery][Required]  string NAMASYARIKAT)

        public ActionResult<List<Contractor>> GetContractorInfo([FromQuery][Required] string CIDBNO, [FromQuery]  string? SSMNO = null, [FromQuery] string? NAMASYARIKAT = null)
        {
            return Ok(_contractorService.GetContractorInfo(CIDBNO, SSMNO, NAMASYARIKAT));
        }

       
    }
}

