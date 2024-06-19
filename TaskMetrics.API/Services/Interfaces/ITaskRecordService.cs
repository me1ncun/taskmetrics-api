using task_api.TaskMetrics.API.DTOs.TaskRecord.AddTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.DeleteTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.GetTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.UpdateTaskRecord;

namespace task_api.TaskMetrics.API.Services.Interfaces;

public interface ITaskRecordService
{
    Task<AddTaskRecordResponse> AddAsync(AddTaskRecordRequest request);
    Task<UpdateTaskRecordResponse> UpdateAsync(UpdateTaskRecordRequest request);
    Task<DeleteTaskRecordResponse> DeleteAsync(int id);
    Task<GetTaskRecordResponse> GetAsync(int id);
    Task<GetTaskRecordResponse> GetAsync(int userId, int taskId);
    Task<List<GetTaskRecordResponse>> GetAllAsync();
    Task<int> GetTaskPriorityByTaskRecords(string priority, DateTime time);
}