using Bazingo_Application.DTO_s;
using Bazingo_Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Bazingo_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<User> userManager , SignInManager<User> signInManager , IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        // 1. تسجيل مستخدم جديد
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new User
            {
                FirstName = model.FirstName ,
                LastName = model.LastName ,
                Email = model.Email ,
                UserName = model.Username ,
                PhoneNumber = model.PhoneNumber ,
                CreatedAt = DateTime.UtcNow ,
                UpdatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user , model.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { Message = "User registered successfully!" });
        }

        // 2. تسجيل الدخول وإرجاع JWT
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
                return Unauthorized("Invalid username or password!");

            var result = await _signInManager.CheckPasswordSignInAsync(user , model.Password , false);
            if (!result.Succeeded)
                return Unauthorized("Invalid username or password!");

            var token = GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        // 3. تحديث كلمة المرور
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
                return NotFound("User not found!");

            var result = await _userManager.ChangePasswordAsync(user , model.CurrentPassword , model.NewPassword);
            if (result.Succeeded)
                return Ok(new { Message = "Password updated successfully!" });

            return BadRequest(result.Errors);
        }

        // 4. إرجاع بيانات المستخدم الحالي
        [HttpGet("current-user")]
        public async Task<IActionResult> GetCurrentUser( )
        {
            var userName = User?.Identity?.Name;
            if (string.IsNullOrEmpty(userName))
                return Unauthorized("User not logged in!");

            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
                return NotFound("User not found!");

            return Ok(new { user.UserName , user.Email });
        }

        // توليد الـ JWT
        private string GenerateJwtToken(User user)
        {
            var jwtKey = _configuration["Jwt:Key"];
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key , SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"] ,
                audience: _configuration["Jwt:Audience"] ,
                claims: claims ,
                expires: DateTime.Now.AddHours(1) ,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    // موديلات المساعدة
    public class RegisterModel
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6 , ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }

        public string? PhoneNumber { get; set; }
    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ChangePasswordModel
    {
        public string UserName { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
