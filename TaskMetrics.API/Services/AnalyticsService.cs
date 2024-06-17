﻿using task_api.Domain;
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

        return new Analytics
        {
            TotalTasks = totalTasks,
            TimeSpent = totalTime
        };
    }
}