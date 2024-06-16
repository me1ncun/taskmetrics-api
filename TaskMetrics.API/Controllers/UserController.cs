using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using task_api.Domain;
using task_api.TaskMetrics.API.DTOs.Users;
using task_api.TaskMetrics.API.DTOs.Users.AddUser;
using task_api.TaskMetrics.API.DTOs.Users.DeleteUser;
using task_api.TaskMetrics.API.DTOs.Users.GetUserList;
using task_api.TaskMetrics.API.DTOs.Users.UpdateUser;
using task_api.TaskMetrics.API.Services;
using task_api.TaskMetrics.API.Services.Interfaces;
using task_api.TaskMetrics.Domain.Exceptions;
using task_api.TaskMetrics.Domain.Interfaces;

namespace task_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService,
            ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/api/user/")]
        public async Task<IActionResult> Add([FromBody] AddUserRequest request)
        {
            try
            {
                var user = await _userService.AddAsync(request);

                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DublicateUserException)
            {
                return BadRequest("User already exists");
            }
        }

        [HttpGet("/api/users/")]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpGet("/api/user/{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var user = await _userService.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpDelete("/api/user/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var user = await _userService.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var response = await _userService.DeleteAsync(id);

            return Ok(response);
        }

        [HttpPut("/api/user/update/")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request)
        {
            var user = await _userService.GetAsync(request.Email);
            if (user == null)
            {
                return NotFound();
            }

            var response = await _userService.UpdateAsync(request);

            return Ok(response);
        }
    }
}