namespace task_api.TaskMetrics.API.DTOs.TaskRecord.AddTaskRecord;

public class AddTaskRecordResponse
{
    public AddTaskRecordResponse(int id, string userName, string taskName, DateTime dateCompleted, int timeSpent)
    {
        Id = id;
        UserName = userName;
        TaskName = taskName;
        DateCompleted = dateCompleted;
        TimeSpent = timeSpent;
    }
    
    public int Id { get; set; }
    public string UserName { get; set; }
    public string TaskName { get; set; }
    public DateTime DateCompleted { get; set; }
    public int TimeSpent { get; set; }
}