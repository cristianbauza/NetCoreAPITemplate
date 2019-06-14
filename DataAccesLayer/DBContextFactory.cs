using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace DataAccesLayer
{
    public class DBContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public IConfiguration Configuration { get; }

        public DBContextFactory(IConfiguration _conf)
        {
            Configuration = _conf;
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(Configuration["ConnectionString:default"]);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
