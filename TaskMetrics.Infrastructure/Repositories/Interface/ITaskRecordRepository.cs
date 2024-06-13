namespace task_api.TaskMetrics.Infrastructure.Repositories.Interface;

public interface ITaskRecordRepository
{
    Task<IEnumerable<task_api.Domain.TaskRecord>> GetAllTaskRecordsAsync();
    Task<task_api.Domain.TaskRecord> GetTaskRecordByIdAsync(int id);
}