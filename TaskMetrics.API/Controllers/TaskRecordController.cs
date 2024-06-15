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

    public TaskRecordController(ITaskRecordService taskRecordService,
        ILogger<TaskController> logger)
    {
        _taskRecordService = taskRecordService;
        _logger = logger;
    }

    [HttpPost("/api/task-record/")]
    public async Task<IActionResult> Add([FromBody] AddTaskRecordRequest request)
    {
        var task = await _taskRecordService.AddAsync(request);

        return Ok(task);
    }

    [HttpGet("/api/task-records/")]
    public async Task<IActionResult> Get()
    {
        var tasks = await _taskRecordService.GetAllAsync();

        if (tasks == null)
        {
            return NotFound();
        }

        return Ok(tasks);
    }

    [HttpGet("/api/task-record/{id}")]
    public async Task<IActionResult> Details([FromRoute] int id)
    {
        var task = await _taskRecordService.GetAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    [HttpDelete("/api/task-record/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var task = await _taskRecordService.GetAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        var response = await _taskRecordService.DeleteAsync(id);

        return Ok(response);
    }

    [HttpPut("/api/task-record/update/")]
    public async Task<IActionResult> Update([FromBody] UpdateTaskRecordRequest request)
    {
        var task = await _taskRecordService.GetAsync(request.UserId, request.TaskId);
        if (task == null)
        {
            return NotFound();
        }

        var response = await _taskRecordService.UpdateAsync(request);

        return Ok(response);
    }
}