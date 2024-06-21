using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using task_api.TaskMetrics.API.DTOs.TaskRecord.AddTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.DeleteTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.GetTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.UpdateTaskRecord;
using task_api.TaskMetrics.API.Services;
using task_api.TaskMetrics.API.Services.Interfaces;
using task_api.TaskMetrics.Domain.Exceptions;

namespace task_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskRecordController: ControllerBase
{
    private readonly ITaskRecordService _taskRecordService;
    private readonly ILogger<TaskController> _logger;

    public TaskRecordController(ITaskRecordService taskRecordService,
        ILogger<TaskController> logger)
    {
        _taskRecordService = taskRecordService;
        _logger = logger;
    }

    /// <summary>
    /// Create a new task-record
    /// </summary>
    /// <response code="200">Returns the newly created item</response>
    /// <response code="400">If the task record already exist</response>
    [Authorize]
    [HttpPost("/api/task-record/")]
    public async Task<IActionResult> Add([FromBody] AddTaskRecordRequest request)
    {
        try
        {
            var taskRecord = await _taskRecordService.AddAsync(request);
        
            return Ok(taskRecord);
        }
        catch (ThrownException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    /// <summary>
    /// Get all task-records
    /// </summary>
    /// <response code="200">Returns the list of task-records</response>
    /// <response code="404">If the list of task-records not found</response>
    [Authorize]
    [HttpGet("/api/task-records/")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var taskRecords = await _taskRecordService.GetAllAsync();

            return Ok(taskRecords);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Get task-record by id
    /// </summary>
    /// <response code="200">Returns the details of task-record by id</response>
    /// <response code="404">If the task-record not found</response>
    [Authorize]
    [HttpGet("/api/task-record/{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        try
        {
            var taskRecord = await _taskRecordService.GetAsync(id);

            return Ok(taskRecord);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Delete task-record by id
    /// </summary>
    /// <response code="200">Returns the deleted task-record</response>
    /// <response code="404">If the task-record not found</response>
    [Authorize]
    [HttpDelete("/api/task-record/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            var response = await _taskRecordService.DeleteAsync(id);

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Update task-record
    /// </summary>
    /// <response code="200">Returns the updated task-record</response>
    /// <response code="404">If the task-record not found</response>
    [Authorize]
    [HttpPut("/api/task-record/update/")]
    public async Task<IActionResult> Update([FromBody] UpdateTaskRecordRequest request)
    {
        try
        {
            var response = await _taskRecordService.UpdateAsync(request);

            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}