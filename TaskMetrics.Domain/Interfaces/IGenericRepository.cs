﻿namespace task_api.TaskMetrics.Domain.Interfaces;

// generic repository interface
public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(object Id);
    Task InsertAsync(T Entity);
    Task UpdateAsync(T Entity);
    Task DeleteAsync(object Id);
    Task SaveAsync();
}