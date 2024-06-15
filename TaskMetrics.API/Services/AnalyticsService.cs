using task_api.Domain;

namespace task_api.TaskMetrics.API.Services;

public class AnalyticsService
{
    private readonly TaskRecordService _taskRecordService;
    
    public AnalyticsService(TaskRecordService taskRecordService)
    {
        _taskRecordService = taskRecordService;
    }

    public async Task<Analytics> GetAsync(DateTime date)
    {
        var records =  await _taskRecordService.GetAllAsync();
        var sortedRecords = records.Where(x => x.DateCompleted.Date == date);
        var totalTime = sortedRecords.Sum(r => r.TimeSpent);
        var totalTasks = sortedRecords.Count();

        return new Analytics
        {
            TotalTasks = totalTasks,
            TimeSpent = totalTime
        };
    }
}