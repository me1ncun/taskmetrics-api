using task_api.TaskMetrics.Domain.Interfaces;

namespace task_api.TaskMetrics.API.Services;

// base service for all services
public class BaseService
{
    public BaseService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
    
    protected IUnitOfWork UnitOfWork { get; }
}