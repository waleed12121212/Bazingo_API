using Bazingo_Core.Domain_Logic.Interfaces;
using Bazingo_Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<AppUser> userManager , SignInManager<AppUser> signInManager , IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<string> Login(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null) return null;

            var result = await _signInManager.CheckPasswordSignInAsync(user , dto.Password , false);
            if (!result.Succeeded) return null;

            // ✅ توليد الـ JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.UserType)
                }) ,
                Expires = DateTime.UtcNow.AddHours(2) ,
                Issuer = _configuration["Jwt:Issuer"] ,
                Audience = _configuration["Jwt:Audience"] ,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key) , SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}