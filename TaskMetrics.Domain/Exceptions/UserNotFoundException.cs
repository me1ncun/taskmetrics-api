namespace task_api.TaskMetrics.Domain.Exceptions;

[Serializable]
public class UserNotFoundException : Exception
{
    public UserNotFoundException(string message) : base(message)
    {
    }

    public UserNotFoundException() : base(String.Format("User not registered in the system"))
    {
    }
}