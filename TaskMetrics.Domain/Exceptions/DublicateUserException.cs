using System.Text.Json.Serialization;

namespace task_api.TaskMetrics.Domain.Exceptions;

public class DublicateUserException : Exception
{
    public DublicateUserException(string message) : base("User already exists"){ }
    public DublicateUserException() : base(){ }
}