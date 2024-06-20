using task_api.Domain;
using task_api.TaskMetrics.Infrastructure.Repositories.Base;
using task_api.TaskMetrics.Infrastructure.Repositories.TaskItem.Base;
using Task = System.Threading.Tasks.Task;

namespace task_api.TaskMetrics.Domain.Interfaces;

// unit of work interface
public interface IUnitOfWork
{
    AuthRepository AuthRepository { get; }
    TaskRepository TaskRepository { get; }
    TaskRecordRepository TaskRecordRepository { get; }
    void CreateTransaction();
    void Commit();
    void Rollback();
    Task Save();
}