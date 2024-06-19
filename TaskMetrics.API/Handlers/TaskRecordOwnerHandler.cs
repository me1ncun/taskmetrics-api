using System.Xml.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using task_api.Domain;
using Task = System.Threading.Tasks.Task;

namespace task_api.TaskMetrics.API.Handlers;

public class TaskRecordOwnerRequirement : IAuthorizationRequirement
{
}

public class TaskRecordOwnerHandler : AuthorizationHandler<TaskRecordOwnerRequirement, TaskRecord>
{
    private readonly UserManager<User> _userManager;

    public TaskRecordOwnerHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TaskRecordOwnerRequirement requirement, TaskRecord resource)
    {
        var userId = int.Parse(_userManager.GetUserId(context.User));

        if (resource.UserId == userId)
        {
            context.Succeed(requirement);
        }
        
        return Task.CompletedTask;
    }
}