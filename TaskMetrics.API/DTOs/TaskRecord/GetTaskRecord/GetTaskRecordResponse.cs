namespace task_api.TaskMetrics.API.DTOs.TaskRecord.GetTaskRecord;

public class GetTaskRecordResponse
{
    public GetTaskRecordResponse(int userId, int taskId, DateTime dateCompleted, int timeSpent)
    {
        UserId = userId;
        TaskId = taskId;
        DateCompleted = dateCompleted;
        TimeSpent = timeSpent;
    }

    public GetTaskRecordResponse()
    {
        
    }
    
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TaskId { get; set; }
    public DateTime DateCompleted { get; set; }
    public int TimeSpent { get; set; }
}