using BasicRestAPI.Attributes;
using BasicRestAPI.Models;
using BasicRestAPI.Services.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var authenticatedUser = await _userService.ValidateUser(user.userName, user.password);
            if (authenticatedUser == null)
            {
                return Unauthorized();
            }

            return Ok("Login successful");
        }
        
        [HttpGet("secure-endpoint")]
        [Authentication]
        public IActionResult SecureEndpoint()
        {
            return Ok("You are authenticated!");
        }
    }
}
