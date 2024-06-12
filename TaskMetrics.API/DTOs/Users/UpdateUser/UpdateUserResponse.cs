namespace task_api.TaskMetrics.API.DTOs.Users.UpdateUser;

public class UpdateUserResponse
{
    public UpdateUserResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
}