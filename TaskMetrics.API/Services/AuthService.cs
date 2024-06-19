using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using task_api.Domain;
using task_api.TaskMetrics.API.DTOs.Auth;
using task_api.TaskMetrics.API.DTOs.Auth.Login;
using task_api.TaskMetrics.API.Helpers.Jwt;
using task_api.TaskMetrics.API.Services.Interfaces;
using task_api.TaskMetrics.Domain.Exceptions;
using task_api.TaskMetrics.Domain.Interfaces;
using task_api.TaskMetrics.Infrastructure.Repositories;

namespace task_api.TaskMetrics.API.Services;

public class AuthService : BaseService, IAuthService
{
    private readonly IMapper _mapper;
    private readonly JwtProvider _jwtProvider;
    private readonly AuthRepository _authRepository;
    public AuthService(IUnitOfWork unitOfWork, IMapper mapper, JwtProvider jwtProvider) : base(unitOfWork)
    {
        _mapper = mapper;
        _jwtProvider = jwtProvider;
        _authRepository = UnitOfWork.AuthRepository;
    }
    
    public async Task<RegisterUserResponse> RegisterAsync(RegisterUserRequest request)
    {
        var userExist = await _authRepository.GetUserByEmailAsync(request.Email);
        if (userExist != null)
        {
            throw new DublicateUserException();
        }

        var user = _mapper.Map<User>(request);

        await _authRepository.InsertAsync(user);
        await UnitOfWork.Save();
        
        var token = _jwtProvider.GenerateToken(user);
        
        var response = _mapper.Map<RegisterUserResponse>(user);
        response.Token = token;

        return response;
    }

    public async Task<LoginUserResponse> LoginAsync(LoginUserRequest request)
    {
        
        var userExist = await _authRepository.GetUserByEmailAsync(request.Email);
        if (userExist == null)
        {
            throw new NotFoundException();
        }

        var user = _mapper.Map<User>(request);
        
        var token = _jwtProvider.GenerateToken(user);
        
        var response = _mapper.Map<LoginUserResponse>(user);
        response.Token = token;

        return response;
    }
}