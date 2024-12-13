using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Task1_CMS.Model;
using Task1_CMS.Service;

namespace Task1_CMS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class cmsController : ControllerBase
    {
        private readonly IcmsServices _services;

        public cmsController(IcmsServices service)
        {
            _services = service;
        }

        [HttpGet]
        public ActionResult<List<CMS>> GetInfocms([FromQuery] string? ICNO = null, [FromQuery] string? TRED = null)

        {
            return Ok(_services.GetInfoCMS(ICNO, TRED));

        }
    }
}

