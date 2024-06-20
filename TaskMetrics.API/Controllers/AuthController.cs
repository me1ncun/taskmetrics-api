using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using task_api.Domain;
using task_api.TaskMetrics.API.DTOs.Auth;
using task_api.TaskMetrics.API.DTOs.Auth.Login;
using task_api.TaskMetrics.API.Services;
using task_api.TaskMetrics.API.Services.Interfaces;
using task_api.TaskMetrics.Domain.Exceptions;
using task_api.TaskMetrics.Domain.Interfaces;

namespace task_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public AuthController(IAuthService authService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
        }
        
        
        /// <summary>
        /// Register a new user and get token
        /// </summary>
        /// <response code="200">Returns the newly created account with jwt token</response>
        /// <response code="500">If the account already exists or an error has occurred</response>
        [HttpPost("/api/user/register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            try
            {
                var user = await _authService.RegisterAsync(request);

                _httpContextAccessor.HttpContext.Response.Cookies.Append("token", user.Token,  new CookieOptions
                {
                    MaxAge = TimeSpan.FromMinutes(60),
                    HttpOnly = true,
                    Secure = true, 
                    SameSite = SameSiteMode.None 
                });

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
        
        /// <summary>
        /// Login by data and get token
        /// </summary>
        /// <response code="200">Returns the logged account with jwt token</response>
        /// <response code="500">If the account dont exists or an error has occurred</response>
        [HttpPost("/api/user/login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            try
            {
                var user = await _authService.LoginAsync(request);
                
                _httpContextAccessor.HttpContext.Response.Cookies.Append("token", user.Token,  new CookieOptions
                {
                    MaxAge = TimeSpan.FromMinutes(60),
                    HttpOnly = true,
                    Secure = true, 
                    SameSite = SameSiteMode.None 
                });

                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (SecurityTokenException)
            {
                return BadRequest("Invalid credentials");
            }
        }
    }
}