using System.ComponentModel.DataAnnotations;

namespace task_api.TaskMetrics.API.DTOs.Users.GetUserList;

public class GetUserRequest
{
    [Required]
    public int Id { get; set; }
}