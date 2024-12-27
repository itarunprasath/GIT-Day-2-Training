using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingDay4.Model;
using TrainingDay4.Services;

namespace TrainingDay4.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PrjInfoController : ControllerBase
    {
        private readonly IPrjInfoService _prjInfoService;

        public PrjInfoController(IPrjInfoService prjInfoService)
        {
            _prjInfoService = prjInfoService;
        }

        [HttpGet]
        public ActionResult<List<PrjInfo>> GetProjectInfo(string comprefno)
        {
            return _prjInfoService.GetProjectInfo(comprefno);
        }
    }
}
