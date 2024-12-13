using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TrainingDay4.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        // AZIRA = GET: api/<testController>
        [HttpGet]
        public int AdditionofNumbers([FromQuery][Required] int a, [FromQuery][Required] int b)
        {
            return a + b;
        }
    }
}
