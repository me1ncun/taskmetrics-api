namespace task_api.TaskMetrics.API.DTOs.Users.DeleteUser;

public class DeleteUserResponse
{
    public DeleteUserResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
}