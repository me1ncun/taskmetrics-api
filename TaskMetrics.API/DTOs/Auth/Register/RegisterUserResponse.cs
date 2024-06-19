namespace task_api.TaskMetrics.API.DTOs.Auth;

public class RegisterUserResponse
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}