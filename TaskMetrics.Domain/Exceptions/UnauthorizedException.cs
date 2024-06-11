namespace task_api.TaskMetrics.Domain.Exceptions;

[Serializable]
public class UnauthorizedException : Exception
{
    public UnauthorizedException(string message) : base(message)
    {
    }

    public UnauthorizedException() : base(String.Format("Unauthorized access denied"))
    {
    }
}