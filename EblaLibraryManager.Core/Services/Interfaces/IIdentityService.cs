using EblaLibraryManager.Data.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EblaLibraryManager.Core.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserRoleAsync(ApplicationUser user);
        Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
        Task<ApplicationUser> GetCurrentUserAsync();
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<IdentityResult> DeleteUserAsync(ApplicationUser user);
        Task SignOutUserAsync();
        Task<SignInResult> SignInUserAsync(string username, string password, bool rememberMe);
        Task<IdentityResult> CreateUserAsync(string username, string password);
    }
}
