using System.ComponentModel.DataAnnotations;

namespace task_api.TaskMetrics.API.DTOs.Auth.Login;

public class LoginUserRequest
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}