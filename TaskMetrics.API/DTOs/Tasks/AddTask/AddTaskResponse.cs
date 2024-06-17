namespace task_api.TaskMetrics.API.DTOs.TaskItems.AddTaskItem;

public class AddTaskResponse
{
    public string Title { get; set; }
    public string Description { get; set; }    
    public string Priority { get; set; }
    public DateTime DueDate { get; set; }
}