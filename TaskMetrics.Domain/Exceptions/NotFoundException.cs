namespace task_api.TaskMetrics.Domain.Exceptions;

[Serializable]
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException() : base(String.Format("Object not found"))
    {
    }
}