using task_api.Domain;

namespace task_api.TaskMetrics.Infrastructure.Repositories;

public class UserRepository: RepositoryBase<User>,
    IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        
    }
}