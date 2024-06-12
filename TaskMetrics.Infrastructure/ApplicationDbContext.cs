using Microsoft.EntityFrameworkCore;
using task_api.Domain;

namespace task_api.TaskMetrics.Infrastructure;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<TaskRecord> TaskRecords { get; set; }
}