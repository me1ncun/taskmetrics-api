namespace task_api.Domain;

public class TaskItem
{
    public int Id { get; set; }
    public string Titile { get; set; }
    public string Description { get; set; }
    public enum Priority { Low, Medium, High }
    public DateTime DueDate { get; set; }
    
}