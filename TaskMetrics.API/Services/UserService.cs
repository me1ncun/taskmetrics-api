using task_api.Domain;
using task_api.TaskMetrics.API.DTOs.Users.AddUser;
using task_api.TaskMetrics.API.DTOs.Users.DeleteUser;
using task_api.TaskMetrics.API.DTOs.Users.GetUserList;
using task_api.TaskMetrics.API.DTOs.Users.UpdateUser;
using task_api.TaskMetrics.Domain.Exceptions;
using task_api.TaskMetrics.Domain.Interfaces;
using task_api.TaskMetrics.Infrastructure.Repositories;

namespace task_api.TaskMetrics.API.Services;

public class UserService : BaseService
{
    public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {

    }

    public async Task<AddUserResponse> AddAsync(AddUserRequest request)
    {
        var repository = UnitOfWork.UserRepository;

        var userExist = await repository.GetUserByEmailAsync(request.Email);
        if (userExist != null)
        {
            throw new NotFoundException();
        }

        var user = new User(
            request.Name,
            request.Email,
            request.Password);

        await repository.InsertAsync(user);
        await UnitOfWork.Save();

        return new AddUserResponse(user.Name, user.Email);
    }

    public async Task<UpdateUserResponse> UpdateAsync(UpdateUserRequest request)
    {
        var repository = UnitOfWork.UserRepository;

        var user = await repository.GetUserByEmailAsync(request.Email);
        if (user == null)
        {
            throw new NotFoundException();
        }

        user.Name = request.Name;
        user.Email = request.Email;
        user.Password = request.Password;

        await repository.UpdateAsync(user);
        await UnitOfWork.Save();

        return new UpdateUserResponse(user.Id, user.Name);
    }

    public async Task<DeleteUserResponse> DeleteAsync(int id)
    {
        var repository = UnitOfWork.UserRepository;

        var user = await repository.GetUserByIdAsync(id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        await repository.DeleteAsync(user.Id);
        await UnitOfWork.Save();

        return new DeleteUserResponse(user.Id, user.Name);
    }

    public async Task<GetUserResponse> GetAsync(int id)
    {
        var repository = UnitOfWork.UserRepository;

        var user = await repository.GetUserByIdAsync(id);
        if (user == null)
        {
            throw new NotFoundException();
        }

        return new GetUserResponse(user.Id, user.Name, user.Email);
    }
    
    public async Task<GetUserResponse> GetAsync(string email)
    {
        var repository = UnitOfWork.UserRepository;

        var user = await repository.GetUserByEmailAsync(email);
        if (user == null)
        {
            throw new NotFoundException();
        }

        return new GetUserResponse(user.Id, user.Name, user.Email);
    }

    public async Task<List<GetUserResponse>> GetAllAsync()
    {
        var repository = UnitOfWork.UserRepository;

        var users = await repository.GetAllUsersAsync();
        
        var userDTOs = users.Select(_ => new GetUserResponse()
            {
                Id = _.Id,
                Name = _.Name,
                Email = _.Email
            })
            .ToList();

        return userDTOs;
    }
}