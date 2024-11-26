using CarRentalSystemAPI.Models;
using CarRentalSystemAPI.Repositories;
using CarRentalSystemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace CarRentalSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IUserRepository userRepository;

        public UserController(IUserService userService, IUserRepository userRepository)
        {
            this.userService = userService;
            this.userRepository = userRepository;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(User newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var token = await userService.RegisterUser(newUser);
                return Ok(token);
            }catch (Exception e)
            {
                return BadRequest(new { Message = "Registration failed", Details = e.Message });

            }

        }
        [HttpPost("login")]

        public async Task<IActionResult> LoginUser(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) {
                return BadRequest("Email or password is empty");
            }

            try
            {
                var token = await userService.AuthenticateUser(email, password);
                return Ok(token);

            } catch (Exception e) {
                return Unauthorized(new { Message = "Login failed", Details = e.Message });
            }
        }

    }
}
