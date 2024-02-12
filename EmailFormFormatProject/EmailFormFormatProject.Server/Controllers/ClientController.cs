using EmailFormFormatProject.Server.Database.Model;
using EmailFormFormatProject.Server.Model;
using EmailFormFormatProject.Server.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailFormFormatProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly ClientRepositories _repo;

        public ClientController(ILogger<ClientController> logger, ClientRepositories repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpPost("create/")]
        public async Task<IActionResult> Post(ClientRequest request)
        {
            if (request == null) return Ok(new ResultResponse(false, "", new { title = "request", message = "Request is null. Kindly contact helpdesk and request assistance from them." }));

            var client = new Client { 
                Address = request.Address,
                Company = request.Company,
                CreatedBy = 0,
                CreatedDate = DateTime.Now,
                DeliveryDate = request.DeliveryDate,
                SKU = request.SKU,
                ImprintColor = request.ImprintColor,
                ImprintLocation = request.ImprintLocation,
                Name = request.Name,
                Phone = request.Phone,
                ProductColor = request.ProductColor,
                Quantity = request.Quantity
            };

            var result = await _repo.Insert(client);
            return Ok(result);
        }

        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _repo.GetAll<Client>();
            return Ok(result);
        }

        [HttpGet("search/")]
        public IActionResult GetById(int request)
        {
            if (request < 0) return Ok(new ResultResponse(false, "", new { title = "request", message = "Request is null. Kindly contact helpdesk and request assistance from them." }));

            var result = _repo.GetByExpression<Client>(s => s.Id == request);
            return Ok(request);
        }

    }
}
