namespace task_api.TaskMetrics.Domain.Exceptions;

[Serializable]
public class EntityValidationException: Exception
{
    public EntityValidationException(string message): base(message){ }
    
    public EntityValidationException() : base(String.Format("Some errors occurred while checking the entity")){ }
}