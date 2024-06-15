using task_api.TaskMetrics.API.DTOs.Users.AddUser;
using task_api.TaskMetrics.API.DTOs.Users.DeleteUser;
using task_api.TaskMetrics.API.DTOs.Users.GetUserList;
using task_api.TaskMetrics.API.DTOs.Users.UpdateUser;

namespace task_api.TaskMetrics.API.Services.Interfaces;

public interface IUserService
{
    Task<AddUserResponse> AddAsync(AddUserRequest request);
    Task<UpdateUserResponse> UpdateAsync(UpdateUserRequest request);
    Task<DeleteUserResponse> DeleteAsync(int id);
    Task<GetUserResponse> GetAsync(int id);
    Task<GetUserResponse> GetAsync(string email);
    Task<List<GetUserResponse>> GetAllAsync();
}