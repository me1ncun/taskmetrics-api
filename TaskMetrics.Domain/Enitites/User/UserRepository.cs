using Microsoft.EntityFrameworkCore;
using task_api.TaskMetrics.Infrastructure;
using task_api.TaskMetrics.Infrastructure.Repositories;

namespace task_api.Domain;

public class UserRepisotory : GenericRepository<User>, IUserRepisitory
{
    private readonly ApplicationDbContext _context;
    public UserRepisotory(ApplicationDbContext context): base(context)
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

    
}