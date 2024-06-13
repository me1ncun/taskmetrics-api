namespace task_api.TaskMetrics.API.DTOs.Users.AddUser;

public class AddUserResponse
{
    public AddUserResponse(string name, string email)
    {
        Name = name;
        Email = email;
    }
    
    public string Name { get; set; }
    public string Email { get; set; }
}