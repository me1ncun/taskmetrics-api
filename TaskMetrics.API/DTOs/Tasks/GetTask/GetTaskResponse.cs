namespace task_api.TaskMetrics.API.DTOs.TaskItems.GetTaskItem;

public class GetTaskResponse
{
    public GetTaskResponse(string title, string description, DateTime dueDate)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
    }
    public GetTaskResponse(int id, string title, string description, DateTime dueDate)
    {
        Id = id;
        Title = title;
        Description = description;
        DueDate = dueDate;
    }
    
    public GetTaskResponse()
    {
    }
    
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
}