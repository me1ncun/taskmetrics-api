namespace task_api.TaskMetrics.Domain.Exceptions;

[Serializable]
public class SomethingWrongException : Exception
{
    public SomethingWrongException(string message) : base(message)
    {
    }

    public SomethingWrongException() : base(String.Format("Something went wrong"))
    {
    }
}