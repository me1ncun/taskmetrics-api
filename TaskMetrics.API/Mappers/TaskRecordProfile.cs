using AutoMapper;
using task_api.Domain;
using task_api.TaskMetrics.API.DTOs.TaskRecord.AddTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.DeleteTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.GetTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.UpdateTaskRecord;

namespace task_api.TaskMetrics.API.Mappers;

public class TaskRecordProfile: Profile
{
    public TaskRecordProfile()
    {
        CreateMap<AddTaskRecordRequest, TaskRecord>();
        CreateMap<TaskRecord, AddTaskRecordResponse>();
        CreateMap<TaskRecord, UpdateTaskRecordResponse>();
        CreateMap<TaskRecord, DeleteTaskRecordResponse>();
        CreateMap<TaskRecord, GetTaskRecordResponse>();
    }
}