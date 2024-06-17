using task_api.Domain;
using task_api.TaskMetrics.API.Services.Interfaces;

namespace task_api.TaskMetrics.API.Services;

public class AnalyticsService: IAnalyticsService
{
    private readonly ITaskRecordService _taskRecordService;
    
    public AnalyticsService(ITaskRecordService taskRecordService)
    {
        _taskRecordService = taskRecordService;
    }

    public async Task<Analytics> GetAsync(DateTime date)
    {
        var records =  await _taskRecordService.GetAllAsync();
        var sortedRecords = records.Where(x => x.DateCompleted.Date == date);
        var totalTime = sortedRecords.Sum(r => r.TimeSpent);
        var totalTasks = sortedRecords.Count();

        var analytics = new Dictionary<string, int>()
        {
            {"High", await _taskRecordService.GetTaskPriorityByTaskRecords("high")},
            {"Medium", await _taskRecordService.GetTaskPriorityByTaskRecords("medium")},
            {"Low", await _taskRecordService.GetTaskPriorityByTaskRecords("low")},
        };

        return new Analytics
        {
            TotalTasks = totalTasks,
            TimeSpent = totalTime,
            Priority = analytics
        };
    }
}