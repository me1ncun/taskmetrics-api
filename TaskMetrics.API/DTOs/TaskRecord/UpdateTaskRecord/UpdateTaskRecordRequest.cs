using System.ComponentModel.DataAnnotations;

namespace task_api.TaskMetrics.API.DTOs.TaskRecord.UpdateTaskRecord;

public class UpdateTaskRecordRequest
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public int TaskId { get; set; }
    [Required]
    public DateTime DateCompleted { get; set; }
    [Required]
    public int TimeSpent { get; set; }
}