using task_api.TaskMetrics.Domain.Interfaces;

namespace task_api.TaskMetrics.Infrastructure.Repositories.TaskItem.Interface;

public interface ITaskRepository: IGenericRepository<task_api.Domain.Task>
{
    Task<IEnumerable<task_api.Domain.Task>> GetAllTasksAsync();
    Task<task_api.Domain.Task?> GetTaskByDescriptionAsync(string desciption);
    Task<task_api.Domain.Task?> GetTaskByTitleAsync(string title);
    Task<task_api.Domain.Task?> GetTaskByIdAsync(int taskItemID);
}