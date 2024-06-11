using System.ComponentModel.DataAnnotations;

namespace task_api.TaskMetrics.API.DTOs.Users.AddUser;

public class AddUserRequest
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    [Required]
    [StringLength(50)]
    public string Email { get; set; }
    [Required]
    [StringLength(125)]
    public string Password { get; set; }
}