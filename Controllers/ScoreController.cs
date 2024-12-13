using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Task1_Score.Model;
using Task1_Score.Services;

namespace Task1_Score.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService _service;

        public ScoreController(IScoreService service)
        {
            _service = service;
        }


        [HttpGet]
        public ActionResult<List<ScoreAppl>> GetScoreAppl([FromQuery][Required] string GRED, [FromQuery][Required] int BINTANG, [FromQuery][Required] int TAHUN)

        {
            return Ok(_service.GetScoreAppl(GRED, BINTANG, TAHUN));
        }
    }
}

