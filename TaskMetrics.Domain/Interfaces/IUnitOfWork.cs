using task_api.TaskMetrics.Domain.Base;

namespace task_api.TaskMetrics.Domain.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    IAsyncRepository<T> AsyncRepository<T>() where T : BaseEntity;
}