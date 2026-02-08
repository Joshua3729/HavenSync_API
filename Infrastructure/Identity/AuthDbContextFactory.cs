using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HavenSync_api.Infrastructure.Identity
{
    public class AuthDbContextFactory
        : IDesignTimeDbContextFactory<AuthDbContext>
    {
        public AuthDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AuthDbContext>();

            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuration.GetConnectionString("AuthDb");

            optionsBuilder.UseSqlServer(
                connectionString
            );

            return new AuthDbContext(optionsBuilder.Options);
        }
    }
}
