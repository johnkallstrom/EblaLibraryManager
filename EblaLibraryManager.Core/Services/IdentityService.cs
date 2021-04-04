using EblaLibraryManager.Core.Services.Interfaces;
using EblaLibraryManager.Data.Enumerations;
using EblaLibraryManager.Data.Exceptions;
using EblaLibraryManager.Data.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace EblaLibraryManager.Core.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IdentityService(
            IHttpContextAccessor context,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<string> GetUserRoleAsync(ApplicationUser user)
        {
            if (user is null) throw new UserNotFoundException("The user you are requesting does not exist.");

            var roles = await _userManager.GetRolesAsync(user);

            return roles.First();
        }

        public async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(_context.HttpContext.User);

        public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user)
        {
            if (user is null) throw new UserNotFoundException("The user you are trying to update does not exist.");

            var result = await _userManager.UpdateAsync(user);

            return result;
        }

        public async Task<ApplicationUser> GetUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null) throw new UserNotFoundException("The user you are requesting does not exist.");

            return user;
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is null) throw new UserNotFoundException("The user you are requesting does not exist.");

            return user;
        }

        public async Task<SignInResult> SignInUserAsync(string username, string password, bool rememberMe)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user is null) throw new UserNotFoundException("The username you entered does not exist.");

            bool validPass = await _userManager.CheckPasswordAsync(user, password);
            if (!validPass) throw new PasswordNotValidException("The password you entered is not valid.");

            var result = await _signInManager.PasswordSignInAsync(user, password, isPersistent: rememberMe, lockoutOnFailure: false);

            return result;
        }

        public async Task<IdentityResult> CreateUserAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user is not null) throw new UsernameNotAvailableException("The username you entered is not available.");

            var newUser = new ApplicationUser { UserName = username };

            var result = await _userManager.CreateAsync(newUser, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, CustomRoleTypes.Member);
            }

            return result;
        }

        public async Task SignOutUserAsync() => await _signInManager.SignOutAsync();

        public async Task<IdentityResult> DeleteUserAsync(ApplicationUser user)
        {
            if (user is null) throw new UserNotFoundException("The user you are requesting does not exist.");

            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Count() is not 0)
            {
                foreach (var role in roles)
                {
                    await _userManager.RemoveFromRoleAsync(user, role);
                }
            }

            var result = await _userManager.DeleteAsync(user);

            return result;
        }
    }
}
