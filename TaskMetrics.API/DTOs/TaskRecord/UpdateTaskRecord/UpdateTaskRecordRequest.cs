using System.ComponentModel.DataAnnotations;

namespace task_api.TaskMetrics.API.DTOs.TaskRecord.UpdateTaskRecord;

public class UpdateTaskRecordRequest
{
    [Required]
    [MaxLength(50)]
    public string UserName { get; set; }
    [Required]
    [MaxLength(50)]
    public string TaskName { get; set; }
    [Required]
    public DateTime DateCompleted { get; set; }
    [Required]
    public int TimeSpent { get; set; }
}