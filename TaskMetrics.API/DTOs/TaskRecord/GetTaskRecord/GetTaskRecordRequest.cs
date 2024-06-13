using System.ComponentModel.DataAnnotations;

namespace task_api.TaskMetrics.API.DTOs.TaskRecord.GetTaskRecord;

public class GetTaskRecordRequest
{
    [Required]
    public int Id { get; set; }
}