using task_api.Domain;
using task_api.TaskMetrics.API.DTOs.TaskItems.DeleteTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.GetTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.UpdateTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskRecord.AddTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.DeleteTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.GetTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.UpdateTaskRecord;
using task_api.TaskMetrics.Domain.Exceptions;
using task_api.TaskMetrics.Domain.Interfaces;

namespace task_api.TaskMetrics.API.Services;

public class TaskRecordService : BaseService
{
    public TaskRecordService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<AddTaskRecordResponse> AddAsync(AddTaskRecordRequest request)
    {
        var repository = UnitOfWork.TaskRecordRepository;

        var taskExist = await repository.GetTaskRecordByUserIdAndTaskIdAsync(request.UserId, request.TaskId);
        if (taskExist != null)
        {
            throw new NotFoundException();
        }

        var taskRecord = new TaskRecord(
            request.TaskId,
            request.UserId,
            request.DateCompleted,
            request.TimeSpent);

        await repository.InsertAsync(taskRecord);
        await UnitOfWork.Save();

        return new AddTaskRecordResponse(taskRecord.UserId, taskRecord.TaskId, taskRecord.DateCompleted,
            taskRecord.TimeSpent);
    }

    //
    public async Task<UpdateTaskRecordResponse> UpdateAsync(UpdateTaskRecordRequest request)
    {
        var repository = UnitOfWork.TaskRecordRepository;

        var taskRecord = await repository.GetTaskRecordByUserIdAndTaskIdAsync(request.UserId, request.TaskId);
        if (taskRecord != null)
        {
            throw new NotFoundException();
        }

        taskRecord.TaskId = request.TaskId;
        taskRecord.UserId = request.UserId;
        taskRecord.DateCompleted = request.DateCompleted;
        taskRecord.TimeSpent = request.TimeSpent;

        await repository.UpdateAsync(taskRecord);
        await UnitOfWork.Save();

        return new UpdateTaskRecordResponse(taskRecord.UserId, taskRecord.TaskId, taskRecord.DateCompleted,
            taskRecord.TimeSpent);
    }

    public async Task<DeleteTaskRecordResponse> DeleteAsync(int id)
    {
        var repository = UnitOfWork.TaskRecordRepository;

        var taskRecord = await repository.GetTaskRecordByIdAsync(id);
        if (taskRecord == null)
        {
            throw new NotFoundException();
        }

        await repository.DeleteAsync(taskRecord.Id);
        await UnitOfWork.Save();

        return new DeleteTaskRecordResponse(taskRecord.UserId, taskRecord.TaskId, taskRecord.DateCompleted,
            taskRecord.TimeSpent);
    }

    public async Task<GetTaskRecordResponse> GetAsync(int id)
    {
        var repository = UnitOfWork.TaskRecordRepository;

        var taskRecord = await repository.GetTaskRecordByIdAsync(id);
        if (taskRecord == null)
        {
            throw new NotFoundException();
        }

        return new GetTaskRecordResponse(taskRecord.UserId, taskRecord.TaskId, taskRecord.DateCompleted,
            taskRecord.TimeSpent);
    }
    
    public async Task<GetTaskRecordResponse> GetAsync(int userId, int taskId)
    {
        var repository = UnitOfWork.TaskRecordRepository;

        var taskRecord = await repository.GetTaskRecordByUserIdAndTaskIdAsync(userId, taskId);
        if (taskRecord == null)
        {
            throw new NotFoundException();
        }

        return new GetTaskRecordResponse(taskRecord.UserId, taskRecord.TaskId, taskRecord.DateCompleted,
            taskRecord.TimeSpent);
    }

    public async Task<List<GetTaskRecordResponse>> GetAllAsync()
    {
        var repository = UnitOfWork.TaskRecordRepository;

        var taskRecords = await repository.GetAllTaskRecordsAsync();

        var taskDTOs = taskRecords.Select(_ => new GetTaskRecordResponse()
            {
                Id = _.Id,
                UserId = _.UserId,
                TaskId = _.TaskId,
                DateCompleted = _.DateCompleted,
                TimeSpent = _.TimeSpent,
            })
            .ToList();

        return taskDTOs;
    }
}