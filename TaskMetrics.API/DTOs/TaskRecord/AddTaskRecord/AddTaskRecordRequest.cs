using System.ComponentModel.DataAnnotations;

namespace task_api.TaskMetrics.API.DTOs.TaskRecord.AddTaskRecord;

public class AddTaskRecordRequest
{
    [Required]
    [MaxLength(50)]
    public int UserId { get; set; }
    [Required]
    [MaxLength(50)]
    public int TaskId { get; set; }
    [Required]
    public DateTime DateCompleted { get; set; }
    [Required]
    public int TimeSpent { get; set; }
}