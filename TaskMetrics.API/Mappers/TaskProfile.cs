using AutoMapper;
using task_api.Domain;
using task_api.TaskMetrics.API.DTOs.TaskItems.AddTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.DeleteTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.GetTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.UpdateTaskItem;
using Task = task_api.Domain.Task;

namespace task_api.TaskMetrics.API.Mappers;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<AddTaskRequest, Task>();
        CreateMap<Task, AddTaskResponse>();
        CreateMap<Task, UpdateTaskResponse>();
        CreateMap<Task, DeleteTaskResponse>();
        CreateMap<Task, GetTaskResponse>();
    }
}