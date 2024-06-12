﻿using task_api.Domain;

namespace task_api.TaskMetrics.Domain.Interfaces;

public interface IUnitOfWork
{
    UserRepisotory Users { get; }
    void CreateTransaction();
    void Commit();
    void Rollback();
    Task Save();
}