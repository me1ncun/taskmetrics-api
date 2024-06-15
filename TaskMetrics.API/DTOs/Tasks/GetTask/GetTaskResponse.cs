namespace task_api.TaskMetrics.API.DTOs.TaskItems.GetTaskItem;

public class GetTaskResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
}