using task_api.TaskMetrics.API.DTOs.TaskItems.GetTaskItem;

namespace task_api.Domain;

// analytics entity
public class Analytics
{
    public int TotalTasks { get; set; }
    public int TimeSpent { get; set; }
    public Dictionary<string, int> Priority { get; set; }
}