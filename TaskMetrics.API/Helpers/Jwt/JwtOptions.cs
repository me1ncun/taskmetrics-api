namespace task_api.TaskMetrics.API.Helpers.Jwt;

// secret key and expires hours
public class JwtOptions
{
    public string SecretKey { get; set; } = string.Empty;
    public int ExpiresHours { get; set; }
}