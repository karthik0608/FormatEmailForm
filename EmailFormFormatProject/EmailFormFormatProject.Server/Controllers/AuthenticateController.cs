using EmailFormFormatProject.Server.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailFormFormatProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ILogger<AuthenticateController> _logger;
        private readonly LoginRepositories _repo;

        public AuthenticateController(ILogger<AuthenticateController> logger, LoginRepositories repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpPost("/login")]
        public IActionResult Login(string username, string password)
        {
            var result = _repo.SignInAccess(username, password);
            return Ok(result);
        }
    }
}
