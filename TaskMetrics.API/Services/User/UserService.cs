using task_api.TaskMetrics.API.DTOs.Users.AddUser;
using task_api.TaskMetrics.API.DTOs.Users.GetUserList;
using task_api.TaskMetrics.Domain.Interfaces;

namespace task_api.TaskMetrics.API.Services.User;

public class UserService: BaseService
{
    public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<AddUserResponse> AddNewAsync(AddUserRequest model)
    {
        var user = new task_api.Domain.User(model.Name,
            model.Email, model.Password);

        var repository = UnitOfWork.AsyncRepository<task_api.Domain.User>();

        await repository.AddAsync(user);
        await UnitOfWork.SaveChangesAsync();

        var response = new AddUserResponse()
        {
            Id = user.Id,
            Name = user.Name,
        };

        return response;
    }

    public async Task<List<GetUserResponse>> SearchAsync(GetUserRequest request)
    {
        var repository = UnitOfWork.AsyncRepository<task_api.Domain.User>();

        var users = await repository.ListAsync(_ => _.Name.Contains(request.Search));

        var userDTOs = users.Select(_ => new GetUserResponse()
        {
            Name = _.Name,
            Id = _.Id,
            Email = _.Email
        })
        .ToList();

        return userDTOs;
    }
}