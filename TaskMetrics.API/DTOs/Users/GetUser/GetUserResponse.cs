namespace task_api.TaskMetrics.API.DTOs.Users.GetUserList;

public class GetUserResponse
{
    public GetUserResponse(int id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public GetUserResponse()
    {
        
    }
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}