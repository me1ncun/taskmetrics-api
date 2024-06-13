using Microsoft.EntityFrameworkCore;
using task_api.TaskMetrics.Infrastructure.Repositories.Interface;

namespace task_api.TaskMetrics.Infrastructure.Repositories.Base;

public class TaskRecordRepository : GenericRepository<task_api.Domain.TaskRecord>, ITaskRecordRepository
{
    public TaskRecordRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<task_api.Domain.TaskRecord>> GetAllTaskRecordsAsync()
    {
        return await _context.TaskRecords.ToListAsync();
    }
    
    public async Task<task_api.Domain.TaskRecord> GetTaskRecordByIdAsync(int id)
    {
        return await _context.TaskRecords.FirstOrDefaultAsync(x => x.Id == id);
    }
    
}