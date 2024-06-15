namespace task_api.TaskMetrics.API.DTOs.TaskItems.UpdateTaskItem;

public class UpdateTaskResponse
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
}