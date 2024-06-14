﻿using Microsoft.EntityFrameworkCore;
using task_api.Domain;
using task_api.TaskMetrics.Infrastructure.Repositories.Interface;

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
}