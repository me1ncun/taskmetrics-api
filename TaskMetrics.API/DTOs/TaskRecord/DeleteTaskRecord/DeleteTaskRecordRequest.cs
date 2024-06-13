using System.ComponentModel.DataAnnotations;

namespace task_api.TaskMetrics.API.DTOs.TaskRecord.DeleteTaskRecord;

public class DeleteTaskRecordRequest
{
    [Required]
    public int Id { get; set; }
}