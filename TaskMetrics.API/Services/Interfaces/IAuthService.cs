using task_api.Domain;
using task_api.TaskMetrics.API.DTOs.Auth;
using task_api.TaskMetrics.API.DTOs.Auth.Login;

namespace task_api.TaskMetrics.API.Services.Interfaces;

public interface IAuthService
{
    Task<RegisterUserResponse> RegisterAsync(RegisterUserRequest request);
    Task<LoginUserResponse> LoginAsync(LoginUserRequest request);
    User GetUserById(int id);
}