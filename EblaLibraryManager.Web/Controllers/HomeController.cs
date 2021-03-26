using Microsoft.AspNetCore.Mvc;

namespace EblaLibraryManager.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
