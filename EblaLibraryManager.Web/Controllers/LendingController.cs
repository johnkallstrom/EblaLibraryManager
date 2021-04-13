using EblaLibraryManager.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EblaLibraryManager.Web.Controllers
{
    public class LendingController : Controller
    {
        private readonly ILendingService _lendingService;
        private readonly IIdentityService _identityService;

        public LendingController(
            ILendingService lendingService,
            IIdentityService identityService)
        {
            _lendingService = lendingService;
            _identityService = identityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task CreateLending(int bookId)
        {
            var user = await _identityService.GetCurrentUserAsync();

            if (user is not null)
            {
                await _lendingService.CreateLendingAsync(bookId, user);
                ViewBag.DisplayMessage = true;
            }
        }
    }
}
