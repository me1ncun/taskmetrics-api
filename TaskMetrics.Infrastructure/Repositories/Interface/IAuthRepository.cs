using task_api.TaskMetrics.Domain.Interfaces;

namespace task_api.Domain;

// auth repository interface
public interface IAuthRepository : IGenericRepository<User>
{
    Task<User?> GetUserByEmailAsync(string email);
}