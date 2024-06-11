using Microsoft.EntityFrameworkCore;
using task_api.Domain;

namespace task_api.TaskMetrics.Infrastructure;

public class ApplicationDbContext: DbContext
{
    private IConfiguration Configuration;

    public ApplicationDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Configuration.GetConnectionString("Database"));
    }

    public DbSet<User> Users { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<TaskRecord> TaskRecords { get; set; }
}