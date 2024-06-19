using System.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using task_api.Domain;
using task_api.TaskMetrics.Domain;
using task_api.TaskMetrics.Infrastructure.Repositories.Interface;
using Task = task_api.Domain.Task;

namespace task_api.TaskMetrics.Infrastructure.Repositories.Base;

public class TaskRecordRepository : GenericRepository<TaskRecord>, ITaskRecordRepository
{
    public TaskRecordRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<TaskRecord>> GetAllTaskRecordsAsync()
    {
        return await _context.TaskRecords.ToListAsync();
    }
    
    public async Task<TaskRecord> GetTaskRecordByIdAsync(int id)
    {
        return await _context.TaskRecords.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<TaskRecord> GetTaskRecordByUserIdAndTaskIdAsync(int userId, int taskId)
    {
        return await _context.TaskRecords.FirstOrDefaultAsync(x => x.UserId == userId && x.TaskId == taskId);
    }

    public async Task<int> GetTaskPriorityByTaskRecord(string priority, DateTime date)
    {
        var connection = _context.Database.GetDbConnection();
        
        var sql = @"
        SELECT Count(*) as PriorityCount
        FROM ""TaskRecords"" tr
        JOIN ""Tasks"" t ON tr.""TaskId"" = t.""Id""
        WHERE t.""Priority""= @priority AND tr.""DateCompleted"" = @date
        GROUP BY t.""Priority"";";
    
        return await connection.QueryFirstOrDefaultAsync<int>(sql, new {priority, date});
    }
}