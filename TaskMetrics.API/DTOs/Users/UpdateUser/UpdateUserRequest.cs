using System.ComponentModel.DataAnnotations;

namespace task_api.TaskMetrics.API.DTOs.Users.UpdateUser;

public class UpdateUserRequest
{
    [Required] public int Id { get; set; }
    [Required] [StringLength(50)] public string Name { get; set; }

    [Required] [StringLength(50)] public string Email { get; set; }

    [Required] [StringLength(125)] public string Password { get; set; }
}