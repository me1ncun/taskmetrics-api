using task_api.TaskMetrics.Domain.Interfaces;

namespace task_api.Domain;

public interface IUserRepisitory : IGenericRepository<User>
{
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<User?> GetUserByIdAsync(int userID);
}