using System.ComponentModel.DataAnnotations;

namespace task_api.TaskMetrics.API.DTOs.TaskRecord.DeleteTaskRecord;

public class DeleteTaskRecordResponse
{
    public int UserId { get; set; }
    public int TaskId { get; set; }
    public DateTime DateCompleted { get; set; }
    public int TimeSpent { get; set; }
}