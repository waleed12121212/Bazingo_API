using Bazingo_Core.Interfaces;
using Bazingo_Core.Models;
using Bazingo_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string role)
        {
            return await _context.Users
                .Where(u => u.UserType == role)
                .ToListAsync();
        }

        public async Task<bool> IsUserVerifiedAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            return user?.IsVerified ?? false;
        }
    }
}
