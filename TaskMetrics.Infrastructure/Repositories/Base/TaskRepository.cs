using Microsoft.EntityFrameworkCore;
using task_api.TaskMetrics.Infrastructure.Repositories.TaskItem.Interface;

namespace task_api.TaskMetrics.Infrastructure.Repositories.TaskItem.Base;

public class TaskRepository : GenericRepository<task_api.Domain.Task>, ITaskRepository
{
    private readonly ApplicationDbContext _context;
    
    public TaskRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<task_api.Domain.Task>> GetAllTasksAsync()
    {
        return await _context.Tasks.ToListAsync();
    }
    
    public async Task<task_api.Domain.Task?> GetTaskByIdAsync(int taskId)
    {
        var taskItem = await _context.Tasks
            .FirstOrDefaultAsync(c => c.Id == taskId);
        
        return taskItem;
    }
    
    public async Task<task_api.Domain.Task?> GetTaskByTitleAsync(string title)
    {
        var taskItem = await _context.Tasks
            .FirstOrDefaultAsync(c => c.Titile == title);
        
        return taskItem;
    }
    
    public async Task<task_api.Domain.Task?> GetTaskByDescriptionAsync(string description)
    {
        var taskItem = await _context.Tasks
            .FirstOrDefaultAsync(c => c.Description == description);
        
        return taskItem;
    }
}