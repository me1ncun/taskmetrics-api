using AutoMapper;
using task_api.Domain;
using task_api.TaskMetrics.API.DTOs.TaskItems.AddTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.DeleteTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.GetTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.UpdateTaskItem;
using task_api.TaskMetrics.API.Services.Interfaces;
using task_api.TaskMetrics.Domain.Exceptions;
using task_api.TaskMetrics.Domain.Interfaces;
using Task = task_api.Domain.Task;

namespace task_api.TaskMetrics.API.Services;

public class TaskService : BaseService, ITaskService
{
    private readonly IMapper _mapper;
    public TaskService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        _mapper = mapper;
    }
    
    public async Task<AddTaskResponse> AddAsync(AddTaskRequest request)
    {
        var repository = UnitOfWork.TaskRepository;

        var taskExist = await repository.GetTaskByTitleAsync(request.Title);
        if (taskExist != null)
        {
            throw new NotFoundException();
        }

        var task = _mapper.Map<Task>(request);

        await repository.InsertAsync(task);
        await UnitOfWork.Save();

        var response = _mapper.Map<AddTaskResponse>(task);
        
        return response;
    }

    public async Task<UpdateTaskResponse> UpdateAsync(UpdateTaskRequest request)
    {
        var repository = UnitOfWork.TaskRepository;

        var task = await repository.GetTaskByTitleAsync(request.Title);
        if (task == null)
        {
            throw new NotFoundException();
        }

        task.Title = request.Title;
        task.Description = request.Description;
        task.DueDate = request.DueDate;

        await repository.UpdateAsync(task);
        await UnitOfWork.Save();

        var response = _mapper.Map<UpdateTaskResponse>(task);

        return response;
    }

    public async Task<DeleteTaskResponse> DeleteAsync(int id)
    {
        var repository = UnitOfWork.TaskRepository;

        var task = await repository.GetTaskByIdAsync(id);
        if (task == null)
        {
            throw new NotFoundException();
        }

        await repository.DeleteAsync(task.Id);
        await UnitOfWork.Save();

        var response = _mapper.Map<DeleteTaskResponse>(task);
        
        return response;
    }

    public async Task<GetTaskResponse> GetAsync(int id)
    {
        var repository = UnitOfWork.TaskRepository;

        var task = await repository.GetTaskByIdAsync(id);
        if (task == null)
        {
            throw new NotFoundException();
        }

        var response = _mapper.Map<GetTaskResponse>(task);

        return response;
    }
    
    public async Task<GetTaskResponse> GetAsync(string title)
    {
        var repository = UnitOfWork.TaskRepository;

        var task = await repository.GetTaskByTitleAsync(title);
        if (task == null)
        {
            throw new NotFoundException();
        }

        var response = _mapper.Map<GetTaskResponse>(task);
        
        return response;
    }

    public async Task<List<GetTaskResponse>> GetAllAsync()
    {
        var repository = UnitOfWork.TaskRepository;

        var tasks = await repository.GetAllTasksAsync();
        
        var taskDTOs = _mapper.Map<List<GetTaskResponse>>(tasks);

        return taskDTOs;
    }
}