using Microsoft.EntityFrameworkCore;
using task_api.TaskMetrics.Infrastructure;
using task_api.TaskMetrics.Infrastructure.Repositories;

namespace task_api.Domain;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context): base(context)
    {
        _context = context;
    }
   
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }
    
    
    public async Task<User?> GetUserByIdAsync(int userID)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(c => c.Id == userID);
        
        return user;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(c => c.Email == email);
        
        return user;
    }
}