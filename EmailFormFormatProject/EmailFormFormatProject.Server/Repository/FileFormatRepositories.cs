using EmailFormFormatProject.Server.Database;
using EmailFormFormatProject.Server.Database.Model;
using EmailFormFormatProject.Server.Model;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmailFormFormatProject.Server.Repository
{
    public class FileFormatRepositories
    {
        private readonly ILogger<FileFormatRepositories> _logger;
        private readonly DatabaseContext _db;

        public FileFormatRepositories(ILogger<FileFormatRepositories> logger,  DatabaseContext db)
        {
            _logger = logger;
            _db = db;
        }
        
        public async Task<ResultResponse> GetAll<T>(Expression<Func<FormTemplate, bool>> expression = null)
        {
            List<FormTemplate> templates = [];
            IQueryable<FormTemplate> query = _db.FormTemplates.AsQueryable();

            if(query == null)
            {
                return new ResultResponse(
                    false, 
                    "", 
                    new { 
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

        public async Task<ResultResponse> GetByExpression<T>(Expression<Func<FormTemplate, bool>> expression)
        {
            FormTemplate template = new();
            IQueryable<FormTemplate> query = _db.FormTemplates.AsQueryable();
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

            template = query.SingleOrDefault(expression);

            return new ResultResponse(true, template, "");
        }

        public async Task<ResultResponse> Insert()
        {

        }
    }
}
