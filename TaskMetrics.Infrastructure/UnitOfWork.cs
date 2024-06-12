using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using task_api.Domain;
using task_api.TaskMetrics.Domain.Interfaces;
using task_api.TaskMetrics.Infrastructure.Repositories;

namespace task_api.TaskMetrics.Infrastructure;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    public ApplicationDbContext Context;
    private IDbContextTransaction? _objTran = null;
    public UserRepisotory Users { get; private set; }

    public UnitOfWork(ApplicationDbContext _Context)
    {
        Context = _Context;
        Users = new UserRepisotory(Context);
    }

    public void CreateTransaction()
    {
        _objTran = Context.Database.BeginTransaction();
    }

    public void Commit()
    {
        _objTran?.Commit();
    }

    public void Rollback()
    {
        _objTran?.Rollback();

        _objTran?.Dispose();
    }

    public async Task Save()
    {
        try
        {
            await Context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}