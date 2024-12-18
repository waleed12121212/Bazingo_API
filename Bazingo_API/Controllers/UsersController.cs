using Bazingo_Application.DTO_s;
using Bazingo_Core.Models;
using Bazingo_Infrastructure.Data;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bazingo_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize] // حماية الـ Endpoints
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers( )
        {
            var users = await _context.Users.ToListAsync();
            var userDtos = users.Adapt<IEnumerable<UserResponseDTO>>();
            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            var userDto = user.Adapt<UserResponseDTO>();
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDTO userCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = userCreateDto.Adapt<User>();
            user.CreatedAt = DateTime.UtcNow;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var userResponseDto = user.Adapt<UserResponseDTO>();
            return CreatedAtAction(nameof(GetUser) , new { id = userResponseDto.Id } , userResponseDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id , [FromBody] UserUpdateDTO userUpdateDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            userUpdateDto.Adapt(user);
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
