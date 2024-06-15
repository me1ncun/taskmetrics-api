using Microsoft.EntityFrameworkCore;
using task_api.Domain;
using task_api.TaskMetrics.Infrastructure.Repositories.TaskItem.Interface;
using Task = task_api.Domain.Task;

namespace task_api.TaskMetrics.Infrastructure.Repositories.TaskItem.Base;

public class TaskRepository : GenericRepository<Task>, ITaskRepository
{
    private readonly ApplicationDbContext _context;
    
    public TaskRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Task>> GetAllTasksAsync()
    {
        return await _context.Tasks.ToListAsync();
    }
    
    public async Task<Task?> GetTaskByIdAsync(int taskId)
    {
        var taskItem = await _context.Tasks
            .FirstOrDefaultAsync(c => c.Id == taskId);
        
        return taskItem;
    }
    
    public async Task<Task?> GetTaskByTitleAsync(string title)
    {
        var taskItem = await _context.Tasks
            .FirstOrDefaultAsync(c => c.Title == title);
        
        return taskItem;
    }
    
    public async Task<Task?> GetTaskByDescriptionAsync(string description)
    {
        var taskItem = await _context.Tasks
            .FirstOrDefaultAsync(c => c.Description == description);
        
        return taskItem;
    }
}