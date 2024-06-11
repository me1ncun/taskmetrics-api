﻿namespace task_api.TaskMetrics.API.Exceptions;

[Serializable]
public class EntityNotFoundException: Exception
{
    public EntityNotFoundException(string message): base(message){ }
    
    public EntityNotFoundException() : base(String.Format("Entity not found")){ }
}