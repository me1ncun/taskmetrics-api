using task_api.Domain;

namespace task_api.TaskMetrics.API.Services.Interfaces;

public interface IAnalyticsService
{
    Task<Analytics> GetAsync(DateTime date);
}