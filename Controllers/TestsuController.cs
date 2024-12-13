using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingDay4.Model;
using TrainingDay4.Services;

namespace TrainingDay4.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestsuController : ControllerBase
    {
        private readonly ITestsuService _userService;

        public TestsuController(ITestsuService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<TestsuDetails>> GetUserDetails()
        {
            return _userService.GetUserDetails();

        }

        [HttpGet]
        public ActionResult<TestsuDetails> GetUserDetailsByFirstName([FromQuery][Required] string firstName)
        {
            return _userService.GetUserDetails(firstName);

        }

        [HttpGet]
        public ActionResult<TestsuDetails> GetUserDetailsByUserId([FromQuery][Required] string userId)
        {
            return _userService.GetUserDetailsByUserid(userId);

        }
    }
}
