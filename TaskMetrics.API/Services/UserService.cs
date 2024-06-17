using AutoMapper;
using task_api.Domain;
using task_api.TaskMetrics.API.DTOs.Users.AddUser;
using task_api.TaskMetrics.API.DTOs.Users.DeleteUser;
using task_api.TaskMetrics.API.DTOs.Users.GetUserList;
using task_api.TaskMetrics.API.DTOs.Users.UpdateUser;
using task_api.TaskMetrics.API.Services.Interfaces;
using task_api.TaskMetrics.Domain.Exceptions;
using task_api.TaskMetrics.Domain.Interfaces;
using task_api.TaskMetrics.Infrastructure.Repositories;

namespace task_api.TaskMetrics.API.Services;

public class UserService : BaseService, IUserService
{
    private readonly IMapper _mapper;
    public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        _mapper = mapper;
    }
    
    public async Task<AddUserResponse> AddAsync(AddUserRequest request)
    {
        var repository = UnitOfWork.UserRepository;

        var userExist = await repository.GetUserByEmailAsync(request.Email);
        if (userExist != null)
        {
            throw new DublicateUserException();
        }

        var user = _mapper.Map<User>(request);

        await repository.InsertAsync(user);
        await UnitOfWork.Save();
        
        var response = _mapper.Map<AddUserResponse>(user);

        return response;
    }

    public async Task<UpdateUserResponse> UpdateAsync(UpdateUserRequest request)
    {
        var repository = UnitOfWork.UserRepository;

        var user = await repository.GetUserByEmailAsync(request.Email);
        if (user is null)
        {
            throw new NotFoundException();
        }

        user.Name = request.Name;
        user.Email = request.Email;
        user.Password = request.Password;

        await repository.UpdateAsync(user);
        await UnitOfWork.Save();
        
        var response = _mapper.Map<UpdateUserResponse>(user);

        return response;
    }

    public async Task<DeleteUserResponse> DeleteAsync(int id)
    {
        var repository = UnitOfWork.UserRepository;

        var user = await repository.GetUserByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundException();
        }

        await repository.DeleteAsync(user.Id);
        await UnitOfWork.Save();

        var response = _mapper.Map<DeleteUserResponse>(user);
        
        return response;
    }

    public async Task<GetUserResponse> GetAsync(int id)
    {
        var repository = UnitOfWork.UserRepository;

        var user = await repository.GetUserByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundException();
        }

        var response = _mapper.Map<GetUserResponse>(user);

        return response;
    }
    
    public async Task<GetUserResponse> GetAsync(string email)
    {
        var repository = UnitOfWork.UserRepository;

        var user = await repository.GetUserByEmailAsync(email);
        if (user is null)
        {
            throw new NotFoundException();
        }

        var response = _mapper.Map<GetUserResponse>(user);

        return response;
    }

    public async Task<List<GetUserResponse>> GetAllAsync()
    {
        var repository = UnitOfWork.UserRepository;

        var users = await repository.GetAllUsersAsync();
        if (users is null)
        {
            throw new NotFoundException();
        }
        
        var userDTOs = _mapper.Map<List<GetUserResponse>>(users);

        return userDTOs;
    }
}