using Microsoft.AspNetCore.Mvc;
using task_api.TaskMetrics.API.DTOs.TaskItems.AddTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.DeleteTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.GetTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.UpdateTaskItem;
using task_api.TaskMetrics.API.Services;

namespace task_api.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly TaskService _taskService;
    private readonly ILogger<TaskController> _logger;

    public TaskController(TaskService taskService,
        ILogger<TaskController> logger)
    {
        _taskService = taskService;
        _logger = logger;
    }

    [HttpPost("/api/task/")]
    public async Task<IActionResult> Add([FromBody] AddTaskRequest request)
    {
        var task = await _taskService.AddAsync(request);

        return Ok(task);
    }

    [HttpGet("/api/tasks/")]
    public async Task<IActionResult> Get()
    {
        var tasks = await _taskService.GetAllAsync();

        if (tasks == null)
        {
            return NotFound();
        }

        return Ok(tasks);
    }

    [HttpGet("/api/task/")]
    public async Task<IActionResult> Details([FromQuery] GetTaskRequest request)
    {
        var task = await _taskService.GetAsync(request.Id);
        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    [HttpDelete("/api/task/delete/")]
    public async Task<IActionResult> Delete([FromBody] DeleteTaskRequest request)
    {
        var task = await _taskService.GetAsync(request.Id);
        if (task == null)
        {
            return NotFound();
        }

        var response = await _taskService.DeleteAsync(request);

        return Ok(response);
    }

    [HttpPost("/api/task/update/")]
    public async Task<IActionResult> Update([FromBody] UpdateTaskRequest request)
    {
        var task = await _taskService.GetAsync(request.Title);
        if (task == null)
        {
            return NotFound();
        }

        var response = await _taskService.UpdateAsync(request);

        return Ok(response);
    }
}