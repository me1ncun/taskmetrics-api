using System.ComponentModel.DataAnnotations.Schema;

namespace task_api.Domain;

public class TaskRecord
{
    public int Id { get; set; }
    public DateTime DateCompleted { get; set; }
    public int TimeSpent { get; set; }
    [ForeignKey("TaskItem")]
    public int TaskItemId { get; set; }
    public TaskItem TaskItem { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; }
}