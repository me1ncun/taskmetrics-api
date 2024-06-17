using Microsoft.AspNetCore.Mvc;
using task_api.TaskMetrics.API.Services;
using task_api.TaskMetrics.API.Services.Interfaces;

namespace task_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AlanyticsController: ControllerBase
{
    private readonly IAnalyticsService _analyticsService;
    private readonly ILogger<AlanyticsController> _logger;
    
    public AlanyticsController(IAnalyticsService analyticsService,
        ILogger<AlanyticsController> logger)
    {
        _analyticsService = analyticsService;
        _logger = logger;
    }
    
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