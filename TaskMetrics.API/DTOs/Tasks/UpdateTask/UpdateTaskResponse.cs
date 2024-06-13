namespace task_api.TaskMetrics.API.DTOs.TaskItems.UpdateTaskItem;

public class UpdateTaskResponse
{
    public UpdateTaskResponse(string title, string description, DateTime dueDate)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
    }
    
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
}