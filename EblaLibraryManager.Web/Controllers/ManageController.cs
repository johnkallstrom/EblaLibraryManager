using AutoMapper;
using EblaLibraryManager.Data.Identity;
using EblaLibraryManager.Web.ViewModels.Account;
using EblaLibraryManager.Web.ViewModels.Manage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EblaLibraryManager.Web.Controllers
{
    public class ManageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ManageController(
            IMapper mapper,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _mapper = mapper;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            var roles = await _userManager.GetRolesAsync(user);

            var model = _mapper.Map<ProfileViewModel>(user);
            model.Role = roles.First();

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Settings()
        {
            var user = await _userManager.GetUserAsync(User);

            var model = _mapper.Map<SettingsViewModel>(user);

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Settings(SettingsViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (ModelState.IsValid)
            {
                if (user is null)
                {
                    ModelState.AddModelError(string.Empty, "The user you are requesting does not exist.");
                    return View(model);
                }

                if (model.PasswordSettings != null)
                {
                    bool validPass = await _userManager.CheckPasswordAsync(user, model.PasswordSettings.CurrentPassword);

                    if (!validPass)
                    {
                        ModelState.AddModelError(string.Empty, "The current password you entered is not valid.");
                        return View(model);
                    }

                    var changePassResult = await _userManager.ChangePasswordAsync(user, model.PasswordSettings.CurrentPassword, model.PasswordSettings.NewPassword);

                    if (!changePassResult.Succeeded)
                    {
                        foreach (var error in changePassResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }

                        return View(model);
                    }
                }

                _mapper.Map(model, user);

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    ViewBag.Success = true;
                }
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user is not null)
            {
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Count() is not 0)
                {
                    foreach (var role in roles)
                    {
                        await _userManager.RemoveFromRoleAsync(user, role);
                    }
                }
                
                await _userManager.DeleteAsync(user);
                await _signInManager.SignOutAsync();
            }
        }
    }
}
