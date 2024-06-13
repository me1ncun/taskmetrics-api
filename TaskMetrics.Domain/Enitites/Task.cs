namespace task_api.Domain;

public class Task
{
    public Task(string titile, string description, DateTime dueDate)
    {
        this.Titile = titile;
        this.Description = description;
        this.DueDate = dueDate;
    }
    public int Id { get; set; }
    public string Titile { get; set; }
    public string Description { get; set; }
    /*public string Priority { get; set; }*/
    public DateTime DueDate { get; set; }
    
}