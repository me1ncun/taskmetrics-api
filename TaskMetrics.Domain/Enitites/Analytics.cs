using task_api.TaskMetrics.API.DTOs.TaskItems.GetTaskItem;

namespace task_api.Domain;

public class Analytics
{
    public int TotalTasks { get; set; }
    public int TimeSpent { get; set; }
    public enum Priority
    {
        Low,
        Medium,
        High
    }
}