using AutoMapper;
using EblaLibraryManager.Core.Services.Interfaces;
using EblaLibraryManager.Web.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EblaLibraryManager.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public AccountController(
            IIdentityService identityService,
            IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await _identityService.GetCurrentUserAsync();

            var model = _mapper.Map<ProfileViewModel>(user);
            model.Role = await _identityService.GetUserRoleAsync(user);

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Settings()
        {
            var user = await _identityService.GetCurrentUserAsync();

            var model = _mapper.Map<SettingsViewModel>(user);

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Settings(SettingsViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var user = await _identityService.GetUserByIdAsync(model.UserId);

                _mapper.Map(model, user);

                var result = await _identityService.UpdateUserAsync(user);

                if (result.Succeeded)
                {
                    ViewBag.Success = true;
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task DeleteUser(string userId)
        {
            var user = await _identityService.GetUserByIdAsync(userId);
            
            if (user is not null)
            {
                var result = await _identityService.DeleteUserAsync(user);

                if (result.Succeeded)
                {
                    await _identityService.SignOutUserAsync();
                }
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var result = await _identityService.SignInUserAsync(model.Username, model.Password, model.RememberMe);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _identityService.CreateUserAsync(model.Username, model.Password);

                    if (result.Succeeded)
                    {
                        await _identityService.SignInUserAsync(model.Username, model.Password, false);
                        return RedirectToAction(nameof(HomeController.Index), "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _identityService.SignOutUserAsync();
            return RedirectToAction(nameof(Login), "Account");
        }
    }
}