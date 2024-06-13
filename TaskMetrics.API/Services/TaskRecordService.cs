using task_api.TaskMetrics.API.DTOs.TaskItems.DeleteTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.GetTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.UpdateTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskRecord.AddTaskRecord;
using task_api.TaskMetrics.Domain.Exceptions;
using task_api.TaskMetrics.Domain.Interfaces;

namespace task_api.TaskMetrics.API.Services;

public class TaskRecordService: BaseService
{
    public TaskRecordService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
    
     public async Task<AddTaskRecordResponse> AddAsync(AddTaskRecordRequest request)
    {
        var repository = UnitOfWork.TaskRecordRepository;

        var taskExist = await repository.(request.Title);
        if (taskExist != null)
        {
            throw new NotFoundException();
        }

        var task = new Task(
            request.Title,
            request.Description,
            request.DueDate);

        await repository.InsertAsync(task);
        await UnitOfWork.Save();

        return new AddTaskRecordResponse(task.Titile, task.Description, task.DueDate);
    }

    public async Task<UpdateTaskResponse> UpdateAsync(UpdateTaskRequest request)
    {
        var repository = UnitOfWork.TaskRepository;

        var task = await repository.GetTaskByTitleAsync(request.Title);
        if (task == null)
        {
            throw new NotFoundException();
        }

        task.Titile = request.Title;
        task.Description = request.Description;
        task.DueDate = request.DueDate;

        await repository.UpdateAsync(task);
        await UnitOfWork.Save();

        return new UpdateTaskResponse(task.Titile, task.Description, task.DueDate);
    }

    public async Task<DeleteTaskResponse> DeleteAsync(DeleteTaskRequest request)
    {
        var repository = UnitOfWork.TaskRepository;

        var task = await repository.GetTaskByIdAsync(request.Id);
        if (task == null)
        {
            throw new NotFoundException();
        }

        await repository.DeleteAsync(task.Id);
        await UnitOfWork.Save();

        return new DeleteTaskResponse(task.Titile, task.Description, task.DueDate);
    }

    public async Task<GetTaskResponse> GetAsync(int id)
    {
        var repository = UnitOfWork.TaskRepository;

        var task = await repository.GetTaskByIdAsync(id);
        if (task == null)
        {
            throw new NotFoundException();
        }

        return new GetTaskResponse(task.Id, task.Titile, task.Description, task.DueDate);
    }
    
    public async Task<GetTaskResponse> GetAsync(string title)
    {
        var repository = UnitOfWork.TaskRepository;

        var task = await repository.GetTaskByTitleAsync(title);
        if (task == null)
        {
            throw new NotFoundException();
        }

        return new GetTaskResponse(task.Titile, task.Description, task.DueDate);
    }

    public async Task<List<GetTaskResponse>> GetAllAsync()
    {
        var repository = UnitOfWork.TaskRepository;

        var tasks = await repository.GetAllTasksAsync();
        
        var taskDTOs = tasks.Select(_ => new GetTaskResponse()
            {
                Id = _.Id,
                Title = _.Titile,
                Description = _.Description,
                DueDate = _.DueDate
            })
            .ToList();

        return taskDTOs;
    }
}