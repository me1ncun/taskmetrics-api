using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using task_api.TaskMetrics.API.DTOs.TaskRecord.AddTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.DeleteTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.GetTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.UpdateTaskRecord;
using task_api.TaskMetrics.API.Services;
using task_api.TaskMetrics.API.Services.Interfaces;

namespace task_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskRecordController: ControllerBase
{
    private readonly ITaskRecordService _taskRecordService;
    private readonly ILogger<TaskController> _logger;
    private readonly IAuthorizationService _authorizationService;

    public TaskRecordController(ITaskRecordService taskRecordService,
        ILogger<TaskController> logger,
        IAuthorizationService authorizationService)
    {
        _taskRecordService = taskRecordService;
        _logger = logger;
        _authorizationService = authorizationService;
    }

    [Authorize]
    [HttpPost("/api/task-record/")]
    public async Task<IActionResult> Add([FromBody] AddTaskRecordRequest request)
    {
        var taskRecord = await _taskRecordService.AddAsync(request);
        
        // AuthorizationHandler will automatically check ownership
        var authorizationResult = await _authorizationService.AuthorizeAsync(User, taskRecord, "TaskRecordOwnerPolicy");

        if (!authorizationResult.Succeeded)
        {
            return Forbid();
        }
        
        return Ok(taskRecord);
    }
    
    [Authorize]
    [HttpGet("/api/task-records/")]
    public async Task<IActionResult> Get()
    {
        var taskRecords = await _taskRecordService.GetAllAsync();
        if (taskRecords is null)
        {
            return NotFound();
        }

        return Ok(taskRecords);
    }

    [Authorize]
    [HttpGet("/api/task-record/{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var taskRecord = await _taskRecordService.GetAsync(id);
        if (taskRecord is null)
        {
            return NotFound();
        }

        return Ok(taskRecord);
    }

    [Authorize]
    [HttpDelete("/api/task-record/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var taskRecord = await _taskRecordService.GetAsync(id);
        if (taskRecord is null)
        {
            return NotFound();
        }

        var response = await _taskRecordService.DeleteAsync(id);

        return Ok(response);
    }

    [Authorize]
    [HttpPut("/api/task-record/update/")]
    public async Task<IActionResult> Update([FromBody] UpdateTaskRecordRequest request)
    {
        var taskRecord = await _taskRecordService.GetAsync(request.UserId, request.TaskId);
        if (taskRecord is null)
        {
            return NotFound();
        }

        var response = await _taskRecordService.UpdateAsync(request);

        return Ok(response);
    }
}