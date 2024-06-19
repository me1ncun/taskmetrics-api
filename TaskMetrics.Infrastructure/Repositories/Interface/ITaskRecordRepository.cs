using task_api.Domain;

namespace task_api.TaskMetrics.Infrastructure.Repositories.Interface;

public interface ITaskRecordRepository
{
    Task<IEnumerable<TaskRecord>> GetAllTaskRecordsAsync();
    Task<TaskRecord> GetTaskRecordByIdAsync(int id);
    Task<TaskRecord> GetTaskRecordByUserIdAndTaskIdAsync(int userId, int taskId);
    Task<int> GetTaskPriorityByTaskRecord(string priority, DateTime date);
}