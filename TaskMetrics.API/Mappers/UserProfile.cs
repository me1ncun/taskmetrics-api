using AutoMapper;
using task_api.Domain;
using task_api.TaskMetrics.API.DTOs.Auth;
using task_api.TaskMetrics.API.DTOs.Auth.Login;

namespace task_api.TaskMetrics.API.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterUserRequest, User>();
        CreateMap<LoginUserRequest, User>();
        CreateMap<User, RegisterUserResponse>();
        CreateMap<User, LoginUserResponse>();
        CreateMap<User, LoginUserRequest>();
    }
}