using System.ComponentModel.DataAnnotations.Schema;

namespace task_api.Domain;

public class TaskRecord
{
    public int Id { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; }
    [ForeignKey("Task")]
    public int TaskId { get; set; }
    public Task Task { get; set; }
    public DateTime DateCompleted { get; set; }
    public int TimeSpent { get; set; }
}