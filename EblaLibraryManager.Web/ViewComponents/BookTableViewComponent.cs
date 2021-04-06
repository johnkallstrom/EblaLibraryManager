using EblaLibraryManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EblaLibraryManager.Web.ViewComponents
{
    public class BookTableViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<BookSlimViewModel> books)
        {
            return View("Default", books);
        }
    }
}