using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using task_api.TaskMetrics.API.Exceptions;

namespace task_api.TaskMetrics.API.Handlers;

public class GlobalExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var statusCode = context.Exception switch
        {
            EntityNotFoundException => StatusCodes.Status404NotFound,
            
            ValidationException => StatusCodes.Status400BadRequest,

            UnauthorizedAccessException => StatusCodes.Status401Unauthorized,

            _ => StatusCodes.Status500InternalServerError
        };

        context.Result = new ObjectResult(new
        {
            error = context.Exception.Message,
            stackTrace = context.Exception.StackTrace
        })
        {
            StatusCode = statusCode
        };
    }
}