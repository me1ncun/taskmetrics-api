namespace task_api.TaskMetrics.Infrastructure.Exceptions;

[Serializable]
public class DatabaseException: Exception
{
    public DatabaseException(string message): base(message) { }
    public DatabaseException() : base(String.Format("Database not found")){ }
}