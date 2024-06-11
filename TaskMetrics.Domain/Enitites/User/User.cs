using task_api.TaskMetrics.Domain.Base;

namespace task_api.Domain;

public class User: BaseEntity<int>
{
    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}