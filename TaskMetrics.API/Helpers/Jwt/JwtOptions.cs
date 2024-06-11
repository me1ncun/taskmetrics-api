namespace task_api.TaskMetrics.API.Helpers.Jwt;

public class JwtOptions
{
    public string SecretKey { get; set; } = string.Empty;
    public int ExpiresHours { get; set; }
}