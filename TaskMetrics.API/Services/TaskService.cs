using AutoMapper;
using task_api.Domain;
using task_api.TaskMetrics.API.DTOs.TaskItems.AddTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.DeleteTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.GetTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.UpdateTaskItem;
using task_api.TaskMetrics.API.Services.Interfaces;
using task_api.TaskMetrics.Domain.Exceptions;
using task_api.TaskMetrics.Domain.Interfaces;
using task_api.TaskMetrics.Infrastructure.Repositories.TaskItem.Base;
using Xunit.Sdk;
using Task = task_api.Domain.Task;

namespace task_api.TaskMetrics.API.Services;

// service for Task
public class TaskService : BaseService, ITaskService
{
    private readonly IMapper _mapper;
    private readonly TaskRepository _taskRepository;
    public TaskService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        _mapper = mapper;
        _taskRepository = UnitOfWork.TaskRepository;
    }
    
    public async Task<AddTaskResponse> AddAsync(AddTaskRequest request)
    {
        var taskExist = await _taskRepository.GetTaskByTitleAsync(request.Title);
        if (taskExist != null)
        {
            throw new ThrownException("Task already exists");
        }

        var task = _mapper.Map<Task>(request);

        await _taskRepository.InsertAsync(task);
        await UnitOfWork.Save();

        var response = _mapper.Map<AddTaskResponse>(task);
        
        return response;
    }

    public async Task<UpdateTaskResponse> UpdateAsync(UpdateTaskRequest request)
    {
        var task = await _taskRepository.GetTaskByTitleAsync(request.Title);
        if (task is null)
        {
            throw new NotFoundException();
        }

        task.Title = request.Title;
        task.Description = request.Description;
        task.DueDate = request.DueDate;
        task.Priority = request.Priority;

        await _taskRepository.UpdateAsync(task);
        await UnitOfWork.Save();

        var response = _mapper.Map<UpdateTaskResponse>(task);

        return response;
    }

    public async Task<DeleteTaskResponse> DeleteAsync(int id)
    {
        var task = await _taskRepository.GetTaskByIdAsync(id);
        if (task is null)
        {
            throw new NotFoundException();
        }

        await _taskRepository.DeleteAsync(task.Id);
        await UnitOfWork.Save();

        var response = _mapper.Map<DeleteTaskResponse>(task);
        
        return response;
    }

    public async Task<GetTaskResponse> GetAsync(int id)
    {
        var task = await _taskRepository.GetTaskByIdAsync(id);
        if (task is null)
        {
            throw new NotFoundException();
        }

        var response = _mapper.Map<GetTaskResponse>(task);

        return response;
    }
    
    public async Task<GetTaskResponse> GetAsync(string title)
    {
        var task = await _taskRepository.GetTaskByTitleAsync(title);
        if (task is null)
        {
            throw new NotFoundException();
        }

        var response = _mapper.Map<GetTaskResponse>(task);
        
        return response;
    }

    public async Task<List<GetTaskResponse>> GetAllAsync()
    {
        var tasks = await _taskRepository.GetAllTasksAsync();

        if (tasks is null)
        {
            throw new ThrownException("List is null");
        }
        
        var taskDTOs = _mapper.Map<List<GetTaskResponse>>(tasks);

        return taskDTOs;
    }
}