namespace task_api.TaskMetrics.API.DTOs.TaskRecord.AddTaskRecord;

public class AddTaskRecordResponse
{
    public AddTaskRecordResponse(int userId, int taskId, DateTime dateCompleted, int timeSpent)
    {
        UserId = userId;
        TaskId = taskId;
        DateCompleted = dateCompleted;
        TimeSpent = timeSpent;
    }
    
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TaskId { get; set; }
    public DateTime DateCompleted { get; set; }
    public int TimeSpent { get; set; }
}