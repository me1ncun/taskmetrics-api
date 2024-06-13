using System.ComponentModel.DataAnnotations;

namespace task_api.TaskMetrics.API.DTOs.TaskItems.GetTaskItem;

public class GetTaskRequest
{
    [Required]
    public int Id { get; set; }
}