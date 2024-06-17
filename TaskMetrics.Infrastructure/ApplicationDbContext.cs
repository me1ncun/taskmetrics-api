using Microsoft.EntityFrameworkCore;
using task_api.Domain;
using Task = task_api.Domain.Task;

namespace task_api.TaskMetrics.Infrastructure;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<TaskRecord> TaskRecords { get; set; }
    
}