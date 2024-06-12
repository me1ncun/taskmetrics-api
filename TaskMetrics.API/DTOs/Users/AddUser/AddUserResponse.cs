namespace task_api.TaskMetrics.API.DTOs.Users.AddUser;

public class AddUserResponse
{
    public AddUserResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
}