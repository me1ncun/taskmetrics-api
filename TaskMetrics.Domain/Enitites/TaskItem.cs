namespace task_api.Domain;

public class TaskItem
{
    public int Id { get; set; }
    public string Titile { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
    public DateTime DueDate { get; set; }
    
}