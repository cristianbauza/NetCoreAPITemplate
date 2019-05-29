using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DataAccesLayer
{
    public class DBContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(GetConnectionString());

            return new ApplicationDbContext(optionsBuilder.Options);
        }

        private static string GetConnectionString()
        {
            const string databaseHost = "localhost";
            const string databaseName = "tdw2019";
            const string databaseUser = "root";
            const string databasePass = "tdw2019";

            return $"Server={databaseHost};" +
                    $"database={databaseName};" +
                    $"uid={databaseUser};" +
                    $"pwd={databasePass};" +
                    $"pooling=true;";
        }
    }
}
