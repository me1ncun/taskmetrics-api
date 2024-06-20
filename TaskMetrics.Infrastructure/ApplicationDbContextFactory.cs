using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using task_api.TaskMetrics.Infrastructure;

namespace task_api.TaskMetrics.Domain;

// application db context factory
public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("TaskMetrics.API/appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("Database");
        optionsBuilder.UseNpgsql(connectionString);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}