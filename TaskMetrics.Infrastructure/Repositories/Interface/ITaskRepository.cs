using task_api.TaskMetrics.Domain.Interfaces;
using task_api.Domain;
using Task = task_api.Domain.Task;

namespace task_api.TaskMetrics.Infrastructure.Repositories.TaskItem.Interface;

public interface ITaskRepository: IGenericRepository<task_api.Domain.Task>
{
    Task<IEnumerable<Task>> GetAllTasksAsync();
    Task<Task?> GetTaskByDescriptionAsync(string desciption);
    Task<Task?> GetTaskByTitleAsync(string title);
    Task<Task?> GetTaskByIdAsync(int taskItemID);
    Task<Task?> GetTaskByPriorityAsync(string priority);
}