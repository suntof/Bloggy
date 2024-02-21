using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Entities;
using Bloggy.SERVICE.DTOs.Users;
using Microsoft.AspNetCore.Identity;

namespace Bloggy.SERVICE.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllUsersWithRoleAsync();
        Task<List<AppRole>> GetAllRolesAsync();
        Task<IdentityResult> CreateUserAsync(UserAddDTO userAddDto);
        Task<IdentityResult> UpdateUserAsync(UserUpdateDTO userUpdateDto);
        Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId);
        Task<AppUser> GetAppUserByIdAsync(Guid userId);
        Task<string> GetUserRoleAsync(AppUser user);
        Task<UserProfileDTO> GetUserProfileAsync();
        Task<bool> UserProfileUpdateAsync(UserProfileDTO userProfileDto);
    }
}
