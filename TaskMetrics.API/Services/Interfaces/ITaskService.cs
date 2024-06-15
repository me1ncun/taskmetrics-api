using task_api.TaskMetrics.API.DTOs.TaskItems.AddTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.DeleteTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.GetTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.UpdateTaskItem;

namespace task_api.TaskMetrics.API.Services.Interfaces;

public interface ITaskService
{
    Task<AddTaskResponse> AddAsync(AddTaskRequest request);
    Task<UpdateTaskResponse> UpdateAsync(UpdateTaskRequest request);
    Task<DeleteTaskResponse> DeleteAsync(int id);
    Task<GetTaskResponse> GetAsync(int id);
    Task<GetTaskResponse> GetAsync(string title);
    Task<List<GetTaskResponse>> GetAllAsync();
}