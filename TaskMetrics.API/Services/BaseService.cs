using task_api.TaskMetrics.Domain.Interfaces;

namespace task_api.TaskMetrics.API.Services;

public class BaseService
{
    public BaseService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    protected internal IUnitOfWork UnitOfWork { get; set; }
}