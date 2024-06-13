namespace task_api.TaskMetrics.API.DTOs.TaskItems.DeleteTaskItem;

public class DeleteTaskResponse
{
    public DeleteTaskResponse(string title, string description, DateTime dueDate)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
    }
    
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
}