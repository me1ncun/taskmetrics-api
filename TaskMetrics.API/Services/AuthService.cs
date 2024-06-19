using AutoMapper;
using task_api.Domain;
using task_api.TaskMetrics.API.DTOs.Auth;
using task_api.TaskMetrics.API.DTOs.Auth.Login;
using task_api.TaskMetrics.API.Services.Interfaces;
using task_api.TaskMetrics.Domain.Exceptions;
using task_api.TaskMetrics.Domain.Interfaces;
using task_api.TaskMetrics.Infrastructure.Repositories;

namespace task_api.TaskMetrics.API.Services;

public class AuthService : BaseService, IAuthService
{
    private readonly IMapper _mapper;
    public AuthService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        _mapper = mapper;
    }
    
    public async Task<RegisterUserResponse> RegisterAsync(RegisterUserRequest request)
    {
        var repository = UnitOfWork.AuthRepository;

        var userExist = await repository.GetUserByEmailAsync(request.Email);
        if (userExist != null)
        {
            throw new DublicateUserException();
        }

        var user = _mapper.Map<User>(request);

        await repository.InsertAsync(user);
        await UnitOfWork.Save();
        
        var response = _mapper.Map<RegisterUserResponse>(user);

        return response;
    }

    public async Task<LoginUserResponse> LoginAsync(LoginUserRequest request)
    {
        var repository = UnitOfWork.AuthRepository;

        var userExist = await repository.GetUserByEmailAsync(request.Email);
        if (userExist == null)
        {
            throw new NotFoundException();
        }

        var user = _mapper.Map<User>(request);
        
        var response = _mapper.Map<LoginUserResponse>(user);

        return response;
    }
}