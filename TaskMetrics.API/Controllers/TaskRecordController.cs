using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using task_api.TaskMetrics.API.DTOs.TaskRecord.AddTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.DeleteTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.GetTaskRecord;
using task_api.TaskMetrics.API.DTOs.TaskRecord.UpdateTaskRecord;
using task_api.TaskMetrics.API.Helpers.Jwt;
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
    private readonly JwtProvider _jwtProvider;

    public TaskRecordController(ITaskRecordService taskRecordService,
        ILogger<TaskController> logger,
        JwtProvider jwtProvider)
    {
        _taskRecordService = taskRecordService;
        _logger = logger;
        _jwtProvider = jwtProvider;
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
            
            var token = HttpContext.Request.Cookies["token"];
            
            var claimsPrincipal = _jwtProvider.ValidateJwtToken(token);
            
            if (claimsPrincipal?.Identity?.IsAuthenticated != true)
            {
                return Unauthorized("Token has expired.");
            }
            
            int userId = int.Parse(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            
            if (userId == taskRecord.UserId)
            {
                return Ok(taskRecord);
            }
            else
            {
                throw new NotFoundException("User not found or it is not your task-record.");
            }
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (SecurityTokenExpiredException)
        {
            return Unauthorized("Token has expired.");
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
            
            var token = HttpContext.Request.Cookies["token"];
            
            var claimsPrincipal = _jwtProvider.ValidateJwtToken(token);
            
            if (claimsPrincipal?.Identity?.IsAuthenticated != true)
            {
                return Unauthorized("Token has expired.");
            }
            
            int userId = int.Parse(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            
            if (userId == response.UserId)
            {
                return Ok(response);
            }
            else
            {
                throw new NotFoundException("User not found or it is not your task-record.");
            }
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (SecurityTokenExpiredException)
        {
            return Unauthorized("Token has expired.");
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
            
            var token = HttpContext.Request.Cookies["token"];
            
            var claimsPrincipal = _jwtProvider.ValidateJwtToken(token);
            
            if (claimsPrincipal?.Identity?.IsAuthenticated != true)
            {
                return Unauthorized("Token has expired.");
            }
            
            int userId = int.Parse(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
            
            if (userId == response.UserId)
            {
                return Ok(response);
            }
            else
            {
                throw new NotFoundException("User not found or it is not your task-record.");
            }
            
            return Ok(response);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (SecurityTokenExpiredException)
        {
            return Unauthorized("Token has expired.");
        }
    }
}