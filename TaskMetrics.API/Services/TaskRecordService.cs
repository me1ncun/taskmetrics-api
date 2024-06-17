using AutoMapper;
using task_api.Domain;
using task_api.TaskMetrics.API.DTOs.TaskItems.DeleteTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.GetTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.UpdateTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskRecord.AddTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.DeleteTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.GetTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.UpdateTaskRecord;
using task_api.TaskMetrics.API.Services.Interfaces;
using task_api.TaskMetrics.Domain.Exceptions;
using task_api.TaskMetrics.Domain.Interfaces;

namespace task_api.TaskMetrics.API.Services;

public class TaskRecordService : BaseService, ITaskRecordService
{
    private readonly IMapper _mapper;
    public TaskRecordService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        _mapper = mapper;
    }

    public async Task<AddTaskRecordResponse> AddAsync(AddTaskRecordRequest request)
    {
        var repository = UnitOfWork.TaskRecordRepository;

        var taskExist = await repository.GetTaskRecordByUserIdAndTaskIdAsync(request.UserId, request.TaskId);
        if (taskExist != null)
        {
            throw new NotFoundException();
        }

        var taskRecord = _mapper.Map<TaskRecord>(request);

        await repository.InsertAsync(taskRecord);
        await UnitOfWork.Save();

        var response = _mapper.Map<AddTaskRecordResponse>(taskRecord);

        return response;
    }
    
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

        var response = _mapper.Map<UpdateTaskRecordResponse>(taskRecord);

        return response;
    }

    public async Task<DeleteTaskRecordResponse> DeleteAsync(int id)
    {
        var repository = UnitOfWork.TaskRecordRepository;

        var taskRecord = await repository.GetTaskRecordByIdAsync(id);
        if (taskRecord is null)
        {
            throw new NotFoundException();
        }

        await repository.DeleteAsync(taskRecord.Id);
        await UnitOfWork.Save();

        var response = _mapper.Map<DeleteTaskRecordResponse>(taskRecord);

        return response;
    }

    public async Task<GetTaskRecordResponse> GetAsync(int id)
    {
        var repository = UnitOfWork.TaskRecordRepository;

        var taskRecord = await repository.GetTaskRecordByIdAsync(id);
        if (taskRecord is null)
        {
            throw new NotFoundException();
        }

        var response = _mapper.Map<GetTaskRecordResponse>(taskRecord);

        return response;
    }
    
    public async Task<GetTaskRecordResponse> GetAsync(int userId, int taskId)
    {
        var repository = UnitOfWork.TaskRecordRepository;

        var taskRecord = await repository.GetTaskRecordByUserIdAndTaskIdAsync(userId, taskId);
        if (taskRecord is null)
        {
            throw new NotFoundException();
        }

        var response = _mapper.Map<GetTaskRecordResponse>(taskRecord);

        return response;
    }

    public async Task<List<GetTaskRecordResponse>> GetAllAsync()
    {
        var repository = UnitOfWork.TaskRecordRepository;

        var taskRecords = await repository.GetAllTaskRecordsAsync();

        var taskDTOs = _mapper.Map<List<GetTaskRecordResponse>>(taskRecords);

        return taskDTOs;
    }

    public async Task<int> GetTaskPriorityByTaskRecords(string priority)
    {
        return await UnitOfWork.TaskRecordRepository.GetTaskPriorityByTaskRecord(priority);
    }
}