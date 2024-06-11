namespace task_api.TaskMetrics.Domain.Exceptions;

[Serializable]
public class MappingException: Exception
{
    public MappingException(string message): base(message){ }
    
    public MappingException() : base(String.Format("Mapping failed")){ }
}