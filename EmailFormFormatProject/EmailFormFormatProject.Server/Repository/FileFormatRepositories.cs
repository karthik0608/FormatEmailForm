using EmailFormFormatProject.Server.Database;
using EmailFormFormatProject.Server.Database.Model;
using EmailFormFormatProject.Server.Model;
using Microsoft.EntityFrameworkCore;
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
        
        public async Task<ResultResponse> GetAll<T>(Expression<Func<FormTemplate, bool>>? expression = null)
        {
            List<FormTemplate> templates = [];
            IQueryable<FormTemplate> query = _db.FormTemplates.AsNoTracking().AsQueryable();

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
            IQueryable<FormTemplate> query = _db.FormTemplates.AsNoTracking().AsQueryable();
            if (query == null)
                return new ResultResponse(false, "", new { title = "record", message = "NO DATA" });

            template = query.SingleOrDefault(expression);
            return new ResultResponse(true, template, "");
        }

        public async Task<ResultResponse> Insert(FormTemplate template)
        {
            await _db.FormTemplates.AddAsync(template);
            if(await _db.SaveChangesAsync() > 0)
                return new ResultResponse(true, "Record has created", "");
            else
                return new ResultResponse(false, "", new { title = "data", message = "Record Fail. Kindly contact helpdesk and seek their assistance. " });
        }

        public async Task<ResultResponse> Update(FormTemplate template)
        {
            var data = await _db.FormTemplates.SingleOrDefaultAsync(s => s.Id == template.Id);
            if(data == null) return new ResultResponse(false, "", new { title = "data", message = "Data not found. Kindly contact helpesk and seek their assistance. " });

            _db.FormTemplates.Update(template);
            if (await _db.SaveChangesAsync() > 0)
                return new ResultResponse(true, "Record has updated", "");
            else
                return new ResultResponse(false, "", new { title = "data", message = "Record Fail. Kindly contact helpdesk and seek their assistance. " });
        }

        public async Task<ResultResponse> Delete(int Id)
        {
            var data = await _db.FormTemplates.SingleOrDefaultAsync(s => s.Id == Id);

            if (data == null) return new ResultResponse(false, "", new { title = "data", message = "Data not found. Kindly contact helpesk and seek their assistance. " });

            _db.FormTemplates.Remove(data);
            if (await _db.SaveChangesAsync() > 0)
                return new ResultResponse(true, "Record has deleted", "");
            else
                return new ResultResponse(false, "", new { title = "data", message = "Record Fail. Kindly contact helpdesk and seek their assistance. " });
        }
    }
}
