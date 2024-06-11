using task_api.TaskMetrics.Domain.Base;
using task_api.TaskMetrics.Domain.Interfaces;
using task_api.TaskMetrics.Infrastructure.Repositories;

namespace task_api.TaskMetrics.Infrastructure;

public class UnitOfWork: IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity
    {
        return new RepositoryBase<T>(_dbContext);
    }

    public Task<int> SaveChangesAsync()
    {
        return _dbContext.SaveChangesAsync();
    }
}