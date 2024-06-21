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
using task_api.TaskMetrics.Infrastructure.Repositories.Base;

namespace task_api.TaskMetrics.API.Services;

// service for TaskRecord
public class TaskRecordService : BaseService, ITaskRecordService
{
    private readonly IMapper _mapper;
    private readonly TaskRecordRepository _taskRecordRepository;
    public TaskRecordService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        _mapper = mapper;
        _taskRecordRepository = UnitOfWork.TaskRecordRepository;
    }

    public async Task<AddTaskRecordResponse> AddAsync(AddTaskRecordRequest request)
    {
        var taskExist = await _taskRecordRepository.GetTaskRecordByUserIdAndTaskIdAsync(request.UserId, request.TaskId);
        if (taskExist != null)
        {
            throw new ThrownException("Task record already exists.");
        }

        var taskRecord = _mapper.Map<TaskRecord>(request);

        await _taskRecordRepository.InsertAsync(taskRecord);
        await UnitOfWork.Save();

        var response = _mapper.Map<AddTaskRecordResponse>(taskRecord);

        return response;
    }
    
    public async Task<UpdateTaskRecordResponse> UpdateAsync(UpdateTaskRecordRequest request)
    {
        var taskRecord = await _taskRecordRepository.GetTaskRecordByUserIdAndTaskIdAsync(request.UserId, request.TaskId);
        if (taskRecord != null)
        {
            throw new NotFoundException();
        }

        taskRecord.TaskId = request.TaskId;
        taskRecord.UserId = request.UserId;
        taskRecord.DateCompleted = request.DateCompleted;
        taskRecord.TimeSpent = request.TimeSpent;

        await _taskRecordRepository.UpdateAsync(taskRecord);
        await UnitOfWork.Save();

        var response = _mapper.Map<UpdateTaskRecordResponse>(taskRecord);

        return response;
    }

    public async Task<DeleteTaskRecordResponse> DeleteAsync(int id)
    {
        var taskRecord = await _taskRecordRepository.GetTaskRecordByIdAsync(id);
        if (taskRecord is null)
        {
            throw new NotFoundException();
        }

        await _taskRecordRepository.DeleteAsync(taskRecord.Id);
        await UnitOfWork.Save();

        var response = _mapper.Map<DeleteTaskRecordResponse>(taskRecord);

        return response;
    }

    public async Task<GetTaskRecordResponse> GetAsync(int id)
    {
        var taskRecord = await _taskRecordRepository.GetTaskRecordByIdAsync(id);
        if (taskRecord is null)
        {
            throw new NotFoundException();
        }

        var response = _mapper.Map<GetTaskRecordResponse>(taskRecord);

        return response;
    }
    
    public async Task<GetTaskRecordResponse> GetAsync(int userId, int taskId)
    {
        var taskRecord = await _taskRecordRepository.GetTaskRecordByUserIdAndTaskIdAsync(userId, taskId);
        if (taskRecord is null)
        {
            throw new NotFoundException();
        }

        var response = _mapper.Map<GetTaskRecordResponse>(taskRecord);

        return response;
    }

    public async Task<List<GetTaskRecordResponse>> GetAllAsync()
    {
        var taskRecords = await _taskRecordRepository.GetAllTaskRecordsAsync();
        if (taskRecords is null)
        {
            throw new NotFoundException();
        }

        var taskDTOs = _mapper.Map<List<GetTaskRecordResponse>>(taskRecords);

        return taskDTOs;
    }

    public async Task<int> GetTaskPriorityByTaskRecords(string priority, DateTime date)
    {
        return await _taskRecordRepository.GetTaskPriorityByTaskRecord(priority, date);
    }
}