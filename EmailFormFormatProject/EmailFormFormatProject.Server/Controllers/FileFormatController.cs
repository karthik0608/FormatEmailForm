using EmailFormFormatProject.Server.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailFormFormatProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileFormatController : ControllerBase
    {
        private readonly ILogger<FileFormatController> _logger;
        private readonly FileFormatRepositories _repo;

        public FileFormatController(ILogger<FileFormatController> logger, FileFormatRepositories repo)
        {
            _logger = logger;
            _repo = repo;
        }


        [HttpGet("search/all")]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("search/{id}")]
        public IActionResult GetById(int Id)
        {
            return Ok();
        }

        [HttpPost("create/")]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut("edit/")]
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpDelete("delete/")]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
