namespace task_api.TaskMetrics.Domain.Exceptions;

[Serializable]
public class TypeConverterException : Exception
{
    public TypeConverterException(string message) : base(message)
    {
    }

    public TypeConverterException() : base(String.Format("Invalid cast exception"))
    {
    }
}