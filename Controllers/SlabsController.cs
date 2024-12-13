using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TrainingDay4.Model;
using TrainingDay4.Services;

namespace TrainingDay4.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SlabsController : ControllerBase
    {
        private readonly ISlabsServie _slabsServie;

        public SlabsController(ISlabsServie slabsServie)
        {
            _slabsServie = slabsServie;
        }

        [HttpGet]
        public ActionResult<List<Slabs>> Getslabs([FromQuery][Required] int versionid) 
        {
            return Ok(_slabsServie .GetSlabs(versionid));
        }
        [HttpGet]
        public IActionResult AziraWelcomeMessage()
        {
            return Ok("welcome to Azira demo");
        }

    }
}
