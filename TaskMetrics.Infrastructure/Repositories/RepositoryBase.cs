using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using task_api.TaskMetrics.Domain.Base;
using task_api.TaskMetrics.Domain.Interfaces;

namespace task_api.TaskMetrics.Infrastructure.Repositories;

public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet;

    public RepositoryBase(ApplicationDbContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public Task<bool> DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return Task.FromResult(true);
    }

    public Task<T> GetAsync(Expression<Func<T, bool>> expression)
    {
        return _dbSet.FirstOrDefaultAsync(expression);
    }

    public Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression).ToListAsync();
    }

    public Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return Task.FromResult(entity);
    }
}