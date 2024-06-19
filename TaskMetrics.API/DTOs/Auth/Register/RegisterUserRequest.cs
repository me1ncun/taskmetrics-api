using System.ComponentModel.DataAnnotations;

namespace task_api.TaskMetrics.API.DTOs.Auth;

public class RegisterUserRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}