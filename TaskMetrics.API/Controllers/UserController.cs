using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using task_api.Domain;
using task_api.TaskMetrics.API.DTOs.Users;
using task_api.TaskMetrics.API.DTOs.Users.AddUser;
using task_api.TaskMetrics.API.DTOs.Users.DeleteUser;
using task_api.TaskMetrics.API.DTOs.Users.GetUserList;
using task_api.TaskMetrics.API.DTOs.Users.UpdateUser;
using task_api.TaskMetrics.Domain.Interfaces;

namespace task_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpPost("/api/user/")]
        public async Task<IActionResult> AddUser(AddUserRequest request)
        {
            var userExist = await _unitOfWork.Users.GetUserByEmailAsync(request.Email);
            if (userExist != null)
            {
                return BadRequest("User already exists");
            }
            
            var user = new User(
                request.Name,
                request.Email,
                request.Password);
            
            await _unitOfWork.Users.InsertAsync(user);
            await _unitOfWork.Save();
            
            var response = new AddUserResponse(user.Id, user.Name);
            
            return Ok(response);
        }
        
        [HttpGet("/api/users/")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _unitOfWork.Users.GetAllUsersAsync();

            if (users.IsNullOrEmpty())
            {
                return NotFound();
            }
            
            return Ok(users);
        }
        
        [HttpGet("/api/user/{id}/")]
        public async Task<IActionResult> Details(int id)
        {
            var user = await _unitOfWork.Users.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            
            var response = new GetUserResponse(user.Id, user.Name, user.Email);
            
            return Ok(response);
        }
        
        [HttpDelete("/api/user/delete/")]
        public async Task<IActionResult> Delete(DeleteUserRequest request)
        {
            var user = await _unitOfWork.Users.GetUserByIdAsync(request.Id);
            if (user == null)
            {
                return NotFound();
            }
            
            await _unitOfWork.Users.DeleteAsync(user.Id);
            await _unitOfWork.Save();
            
            var response = new DeleteUserResponse(user.Id, user.Name);
            
            return Ok(response);
        }
        
        [HttpPost("/api/user/update/")]
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {
            var user = await _unitOfWork.Users.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                return NotFound();
            }

            user = new User(
                request.Name,
                request.Email,
                request.Password);
            
            await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.Save();
            
            var response = new UpdateUserResponse(user.Id, user.Name);
            
            return Ok(response);
        }
    }
}
