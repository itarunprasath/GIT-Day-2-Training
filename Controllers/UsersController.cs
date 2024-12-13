using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingDay4.Model;
using TrainingDay4.Services;

namespace TrainingDay4.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]

        public ActionResult<List<Users>> GetUsers()
        {
            return _usersService.GetUsers();
        }

    }
}
