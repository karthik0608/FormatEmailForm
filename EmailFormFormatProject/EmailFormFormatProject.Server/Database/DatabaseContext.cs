using EmailFormFormatProject.Server.Database.Model;
using Microsoft.EntityFrameworkCore;

namespace EmailFormFormatProject.Server.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<FormTemplate> FormTemplates { get; set; }
    }
}
