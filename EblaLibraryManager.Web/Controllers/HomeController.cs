using AutoMapper;
using EblaLibraryManager.Core.Services.Interfaces;
using EblaLibraryManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EblaLibraryManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;

        public HomeController(
            IMapper mapper,
            IBookService bookService)
        {
            _mapper = mapper;
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetBooksAsync();
            
            var model = _mapper.Map<IEnumerable<BookViewModel>>(books);

            return View(model);
        }
    }
}