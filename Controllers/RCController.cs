using Microsoft.AspNetCore.Mvc;
using TrainingDay4.Model;
using TrainingDay4.Services;

namespace TrainingDay4.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class RCController : ControllerBase
    {
        private readonly IRCService _RCService;
        public RCController(IRCService RCService)
        {
            _RCService = RCService;
        }
        [HttpGet]
        public ActionResult<List<RC>> GetRCs(string cidbregno, string ssmno, string comname)
        {
            return _RCService.GetRCs(cidbregno, ssmno, comname);
        }
    }
}
