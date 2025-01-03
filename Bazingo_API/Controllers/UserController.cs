using Bazingo_Application.DTO_s.Identity;
using Bazingo_Core.Domain_Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bazingo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            var result = await _userService.RegisterUser(dto);
            return result ? Ok("User registered successfully") : BadRequest("Registration failed");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _userService.Login(dto);
            if (token == null) return Unauthorized("Invalid credentials");
            return Ok(new { Token = token });
        }

        [Authorize]  // ✅ الحماية باستخدام JWT
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile( )
        {
            var userId = User.FindFirst("id")?.Value;
            var profile = await _userService.GetUserProfile(userId);
            return profile != null ? Ok(profile) : NotFound("User not found");
        }

        [Authorize]
        [HttpPut("profile/update")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserProfileDto dto)
        {
            var userId = User.FindFirst("id")?.Value;
            var result = await _userService.UpdateUserProfile(userId , dto);
            return result ? Ok("Profile updated successfully") : BadRequest("Update failed");
        }
    }
}