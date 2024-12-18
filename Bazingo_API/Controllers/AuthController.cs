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
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<User> userManager , IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

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
                UserType = model.UserType ?? "Buyer" ,
                CreatedAt = DateTime.UtcNow ,
                UpdatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user , model.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { message = "User registered successfully!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !(await _userManager.CheckPasswordAsync(user , model.Password)))
                return Unauthorized("Invalid email or password!");

            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // الحصول على التوكن والـ userId
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer " , "");
            if (string.IsNullOrEmpty(token))
                return Unauthorized(new { message = "Token is missing" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                return Unauthorized(new { message = "User ID not found in token claims" });

            // جلب المستخدم
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return Unauthorized(new { message = "User not found" });

            // محاولة تغيير كلمة المرور
            var result = await _userManager.ChangePasswordAsync(user , model.CurrentPassword , model.NewPassword);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return BadRequest(new { message = "Failed to change password" , errors });
            }

            return Ok(new { message = "Password changed successfully!" });
        }


        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser( )
        {
            // الحصول على التوكن من الهيدر
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer " , "");
            if (string.IsNullOrEmpty(token))
                return Unauthorized(new { message = "Token is missing" });

            try
            {
                // فك وتحليل التوكن
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);

                // استخراج الـ userId من الـ claims
                var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized(new { message = "User ID not found in token claims" });

                // جلب بيانات المستخدم من قاعدة البيانات
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    return Unauthorized(new { message = "User not found in database" });

                return Ok(new
                {
                    id = user.Id ,
                    firstName = user.FirstName ,
                    lastName = user.LastName ,
                    email = user.Email ,
                    phoneNumber = user.PhoneNumber ,
                    userType = user.UserType ,
                    createdAt = user.CreatedAt ,
                    updatedAt = user.UpdatedAt
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Invalid token" , details = ex.Message });
            }
        }


        private string GenerateJwtToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key , SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"] ,
                audience: _configuration["Jwt:Audience"] ,
                claims: claims ,
                expires: DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:ExpireHours"])) ,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }

    public class RegisterModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserType { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class ChangePasswordModel
    {
        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
