using Microsoft.AspNetCore.Mvc;
using task_api.TaskMetrics.API.Services;
using task_api.TaskMetrics.API.Services.Interfaces;

namespace task_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AnalyticsController: ControllerBase
{
    private readonly IAnalyticsService _analyticsService;
    private readonly ILogger<AnalyticsController> _logger;
    
    public AnalyticsController(IAnalyticsService analyticsService,
        ILogger<AnalyticsController> logger)
    {
        _analyticsService = analyticsService;
        _logger = logger;
    }
    
    /// <summary>
    /// Get analytics by done task-records
    /// </summary>
    /// <response code="200">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [HttpGet("/api/summary/analytics/")]
    public async Task<IActionResult> Get(DateTime? date)
    {
        var actualDate = date ?? DateTime.Today;
        
        var analytics = await _analyticsService.GetAsync(actualDate);
        
        if (analytics is null)
        {
            return NotFound();
        }
        
        return Ok(analytics);
    }
    
}