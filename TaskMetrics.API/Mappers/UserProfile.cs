using AutoMapper;
using task_api.Domain;
using task_api.TaskMetrics.API.DTOs.Users.AddUser;
using task_api.TaskMetrics.API.DTOs.Users.DeleteUser;
using task_api.TaskMetrics.API.DTOs.Users.GetUserList;
using task_api.TaskMetrics.API.DTOs.Users.UpdateUser;

namespace task_api.TaskMetrics.API.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<AddUserRequest, User>();
        CreateMap<User, AddUserResponse>();
        CreateMap<User, UpdateUserResponse>();
        CreateMap<User, DeleteUserResponse>();
        CreateMap<User, GetUserResponse>();
    }
}