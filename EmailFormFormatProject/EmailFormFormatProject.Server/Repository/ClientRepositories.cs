using EmailFormFormatProject.Server.Database;
using EmailFormFormatProject.Server.Database.Model;
using EmailFormFormatProject.Server.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmailFormFormatProject.Server.Repository
{
    public class ClientRepositories
    {
        private readonly ILogger<ClientRepositories> _logger;
        private readonly DatabaseContext _db;

        public ClientRepositories(ILogger<ClientRepositories> logger, DatabaseContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<ResultResponse> Insert(Client model)
        {
            await _db.Clients.AddAsync(model);
            if (await _db.SaveChangesAsync() > 0)
                return new ResultResponse(true, "Record has created", "");
            else
                return new ResultResponse(false, "", new { title = "data", message = "Record Fail. Kindly contact helpdesk and seek their assistance. " });
        }

        public async Task<ResultResponse> GetByExpression<T>(Expression<Func<Client, bool>> expression)
        {
            Client template = new();
            IQueryable<Client> query = _db.Clients.AsNoTracking().AsQueryable();
            if (query == null)
                return new ResultResponse(false, "", new { title = "record", message = "NO DATA" });

            template = await query.SingleOrDefaultAsync(expression);
            return new ResultResponse(true, template, "");
        }

        public async Task<ResultResponse> GetAll<T>(Expression<Func<Client, bool>>? expression = null)
        {
            List<Client> templates = [];
            IQueryable<Client> query = _db.Clients.AsNoTracking().AsQueryable();

            if (query == null)
            {
                return new ResultResponse(
                    false,
                    "",
                    new
                    {
                        title = "record",
                        message = "NO DATA",
                    }
                );
            }

            if (expression == null)
            {
                templates = [.. query];
            }
            else
            {
                templates = [.. query.Where(expression)];
            }
            return new ResultResponse(true, templates, "");
        }

    }
}
