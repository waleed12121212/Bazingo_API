using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Domain_Logic.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUser(RegisterUserDto dto);
        Task<string> Login(LoginDto dto);
        Task<UserProfileDto> GetUserProfile(string userId);
        Task<bool> UpdateUserProfile(string userId , UpdateUserProfileDto dto);
        Task<bool> ChangePassword(string userId , ChangePasswordDto dto);
        Task<bool> EnableTwoFactorAuthentication(string userId);
        Task<bool> AdminBlockUser(AdminBlockUserDto dto);
        Task<IEnumerable<UserProfileDto>> GetAllUsers( );
    }
}
