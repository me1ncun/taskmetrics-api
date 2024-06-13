using System.ComponentModel.DataAnnotations;

namespace task_api.TaskMetrics.API.DTOs.TaskRecord.DeleteTaskRecord;

public class DeleteTaskRecordResponse
{
    public DeleteTaskRecordResponse(string userName, string taskName, DateTime dateCompleted, int timeSpent)
    {
        UserName = userName;
        TaskName = taskName;
        DateCompleted = dateCompleted;
        TimeSpent = timeSpent;
    }
    
    public string UserName { get; set; }
    public string TaskName { get; set; }
    public DateTime DateCompleted { get; set; }
    public int TimeSpent { get; set; }
}