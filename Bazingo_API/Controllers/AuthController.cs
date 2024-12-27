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
<<<<<<< HEAD
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<User> userManager , IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

=======
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<User> userManager , SignInManager<User> signInManager , IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        // 1. تسجيل مستخدم جديد
>>>>>>> 9cc7e76c9d962376c2daf0a9dd2900b640628596
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
<<<<<<< HEAD
                UserType = model.UserType ?? "Buyer" ,
=======
>>>>>>> 9cc7e76c9d962376c2daf0a9dd2900b640628596
                CreatedAt = DateTime.UtcNow ,
                UpdatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user , model.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

<<<<<<< HEAD
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
=======
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
>>>>>>> 9cc7e76c9d962376c2daf0a9dd2900b640628596
            var creds = new SigningCredentials(key , SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"] ,
                audience: _configuration["Jwt:Audience"] ,
                claims: claims ,
<<<<<<< HEAD
                expires: DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:ExpireHours"])) ,
=======
                expires: DateTime.Now.AddHours(1) ,
>>>>>>> 9cc7e76c9d962376c2daf0a9dd2900b640628596
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
<<<<<<< HEAD


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
=======
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
>>>>>>> 9cc7e76c9d962376c2daf0a9dd2900b640628596
    }

    public class LoginModel
    {
<<<<<<< HEAD
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
=======
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ChangePasswordModel
    {
        public string UserName { get; set; }
        public string CurrentPassword { get; set; }
>>>>>>> 9cc7e76c9d962376c2daf0a9dd2900b640628596
        public string NewPassword { get; set; }
    }
}
