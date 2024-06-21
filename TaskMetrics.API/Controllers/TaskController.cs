using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using task_api.TaskMetrics.API.DTOs.TaskItems.AddTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.DeleteTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.GetTaskItem;
using task_api.TaskMetrics.API.DTOs.TaskItems.UpdateTaskItem;
using task_api.TaskMetrics.API.Services;
using task_api.TaskMetrics.API.Services.Interfaces;
using task_api.TaskMetrics.Domain.Exceptions;

namespace task_api.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    private readonly ILogger<TaskController> _logger;

    public TaskController(ITaskService taskService,
        ILogger<TaskController> logger)
    {
        _taskService = taskService;
        _logger = logger;
    }

    /// <summary>
    /// Create a new task
    /// </summary>
    /// <response code="200">Returns the newly created item</response>
    /// <response code="404">If the task not found</response>
    [HttpPost("/api/task/")]
    public async Task<IActionResult> Add([FromBody] AddTaskRequest request)
    {
        try
        {
            var task = await _taskService.AddAsync(request);
            
            return Ok(task);
        }
        catch (ThrownException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Get all tasks
    /// </summary>
    /// <response code="200">Returns the list of tasks</response>
    /// <response code="400">If the list is null</response>
    [HttpGet("/api/tasks/")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var tasks = await _taskService.GetAllAsync();

            return Ok(tasks);
        }
        catch (ThrownException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Get task by id
    /// </summary>
    /// <response code="200">Returns the special task by id</response>
    /// <response code="404">If the task not found</response>
    [HttpGet("/api/task/{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        try
        {
            var task = await _taskService.GetAsync(id);

            return Ok(task);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Delete task by id
    /// </summary>
    /// <response code="200">Returns the deleted task</response>
    /// <response code="404">If the task not found</response>
    [HttpDelete("/api/task/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            var response = await _taskService.DeleteAsync(id);

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Update task
    /// </summary>
    /// <response code="200">Returns the updated task</response>
    /// <response code="404">If the task not found</response>
    [HttpPut("/api/task/update/")]
    public async Task<IActionResult> Update([FromBody] UpdateTaskRequest request)
    {
        try
        {
            var response = await _taskService.UpdateAsync(request);

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}