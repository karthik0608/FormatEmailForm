using Azure.Core;
using EmailFormFormatProject.Server.Database.Model;
using EmailFormFormatProject.Server.Model;
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
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _repo.GetAll<FormTemplate>();
            return Ok(result);
        }

        [HttpGet("search/")]
        public IActionResult GetById(int request)
        {
            if (request < 0) return Ok(new ResultResponse(false, "", new { title = "request", message = "Request is null. Kindly contact helpdesk and request assistance from them." }));

            var result = _repo.GetByExpression<FormTemplate>(s => s.Id == request);
            return Ok(request);
        }

        [HttpPost("create/")]
        public IActionResult Post(FormTemplateRequest request)
        {
            if (request == null) return Ok(new ResultResponse(false, "", new { title = "request", message = "Request is null. Kindly contact helpdesk and request assistance from them." }));

            var formTemplate = new FormTemplate { 
                Name = request.Description,
                Template = request.HtmlContent,
                IsActive = request.IsActive,
                UploadDate = DateTime.Now,
                CreatedDate = DateTime.Now,
            };

            var result = _repo.Insert(formTemplate);
            return Ok(result);
        }

        [HttpPut("edit/")]
        public IActionResult Put(FormTemplateRequest request)
        {
            if (request == null) return Ok(new ResultResponse(false, "", new { title = "request", message = "Request is empty. Kindly contact helpdesk and request assistance from them." }));

            var formTemplate = new FormTemplate
            {
                Id = request.Id,
                Name = request.Description,
                Template = request.HtmlContent,
                IsActive = request.IsActive,
                UploadDate = DateTime.Now,
                CreatedDate = DateTime.Now,
            };

            var result = _repo.Update(formTemplate);
            return Ok(request);
        }

        [HttpDelete("delete/")]
        public IActionResult Delete(int request)
        {
            if (request < 0) return Ok(new ResultResponse(false, "", new { title = "request", message = "Request is empty. Kindly contact helpdesk and request assistance from them." }));

            var result = _repo.Delete(request);
            return Ok(request);
        }
    }
}
