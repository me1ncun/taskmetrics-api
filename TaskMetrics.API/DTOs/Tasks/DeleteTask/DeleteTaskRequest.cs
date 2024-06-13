using System.ComponentModel.DataAnnotations;

namespace task_api.TaskMetrics.API.DTOs.TaskItems.DeleteTaskItem;

public class DeleteTaskRequest
{
    [Required]
    public int Id { get; set; }
}