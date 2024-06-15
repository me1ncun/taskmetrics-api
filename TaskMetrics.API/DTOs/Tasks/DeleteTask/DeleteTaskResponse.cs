namespace task_api.TaskMetrics.API.DTOs.TaskItems.DeleteTaskItem;

public class DeleteTaskResponse
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
}