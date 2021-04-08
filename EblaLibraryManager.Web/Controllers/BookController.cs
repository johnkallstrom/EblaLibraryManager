using AutoMapper;
using EblaLibraryManager.Core.Parameters;
using EblaLibraryManager.Core.Services.Interfaces;
using EblaLibraryManager.Web.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EblaLibraryManager.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGenreService _genreService;
        private readonly IBookService _bookService;

        public BookController(
            IMapper mapper,
            IGenreService genreService,
            IBookService bookService)
        {
            _mapper = mapper;
            _genreService = genreService;
            _bookService = bookService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetBooksAsync();

            var model = new BookListViewModel();
            model.Books = _mapper.Map<IEnumerable<BookSlimViewModel>>(books);

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> SearchBooks(string searchTerm)
        {
            var books = await _bookService.GetBooksAsync(new BookQueryParameters { SearchTerm = searchTerm });

            return ViewComponent("BookTable", _mapper.Map<IEnumerable<BookSlimViewModel>>(books));
        }

        [HttpGet]
        [Authorize(Roles = "Librarian")]
        public async Task<IActionResult> CreateBook()
        {
            var model = new CreateBookViewModel();

            model.GenreOptions = await GetGenreOptions();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Librarian")]
        public async Task<IActionResult> CreateBook(CreateBookViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            return View();
        }

        private async Task<List<SelectListItem>> GetGenreOptions()
        {
            var genres = await _genreService.GetGenresAsync();
            var genreOptions = new List<SelectListItem>();

            genreOptions = genres.Select(g => new SelectListItem(g.Name, g.Id.ToString())).OrderBy(i => i.Text).ToList();
            genreOptions.Insert(0, new SelectListItem("Choose genre", "0", true, true));

            return genreOptions;
        }
    }
}
