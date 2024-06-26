﻿using Microsoft.EntityFrameworkCore;
using task_api.TaskMetrics.Infrastructure;
using task_api.TaskMetrics.Infrastructure.Repositories;

namespace task_api.Domain;

// auth repository
public class AuthRepository : GenericRepository<User>, IAuthRepository
{
    private readonly ApplicationDbContext _context;
    
    public AuthRepository(ApplicationDbContext context): base(context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(c => c.Email == email);
        
        return user;
    }
    
    public User GetUserByIdAsync(int id)
    {
        var user = _context.Users
            .FirstOrDefault(c => c.Id == id);
        
        return user;
    }
}