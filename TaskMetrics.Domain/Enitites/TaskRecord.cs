using System.ComponentModel.DataAnnotations.Schema;

namespace task_api.Domain;

public class TaskRecord
{
    public TaskRecord(int taskItemId, int userId, DateTime dateCompleted, int timeSpent)
    {
        TaskItemId = taskItemId;
        UserId = userId;
        DateCompleted = dateCompleted;
        TimeSpent = timeSpent;
    }
    
    public int Id { get; set; }
    public DateTime DateCompleted { get; set; }
    public int TimeSpent { get; set; }
    [ForeignKey("TaskItem")]
    public int TaskItemId { get; set; }
    public Task Task { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; }
}