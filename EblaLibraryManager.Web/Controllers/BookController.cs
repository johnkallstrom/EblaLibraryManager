using AutoMapper;
using EblaLibraryManager.Core.Parameters;
using EblaLibraryManager.Core.Services.Interfaces;
using EblaLibraryManager.Data.Models;
using EblaLibraryManager.Web.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EblaLibraryManager.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;
        private readonly IGenreService _genreService;
        private readonly IBookService _bookService;

        public BookController(
            IMapper mapper,
            IAuthorService authorService,
            IGenreService genreService,
            IBookService bookService)
        {
            _mapper = mapper;
            _authorService = authorService;
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

            model.GenreOptions = await GetGenreSelectOptions();
            model.AuthorOptions = await GetAuthorSelectOptions();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Librarian")]
        public async Task<IActionResult> CreateBook(CreateBookViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var book = _mapper.Map<Book>(model);

                await _bookService.CreateBookAsync(book);

                return RedirectToAction(nameof(BookController.Index), "Book");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> BookDetails(int bookId)
        {
            var book = await _bookService.GetBookByIdAsync(bookId);

            var model = _mapper.Map<BookViewModel>(book);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Librarian")]
        public async Task<IActionResult> EditBook(int bookId)
        {
            var book = await _bookService.GetBookByIdAsync(bookId);

            var model = _mapper.Map<EditBookViewModel>(book);
            model.GenreOptions = await GetGenreSelectOptions();
            model.AuthorOptions = await GetAuthorSelectOptions();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Librarian")]
        public async Task<IActionResult> EditBook(EditBookViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                var book = await _bookService.GetBookByIdAsync(model.BookId);

                _mapper.Map(model, book);
                
                _bookService.UpdateBook(book);

                return RedirectToAction(nameof(BookController.Index), "Book");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Librarian")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            var book = await _bookService.GetBookByIdAsync(bookId);
            
            _bookService.DeleteBook(book);

            var bookList = await _bookService.GetBooksAsync();
            
            return ViewComponent("BookTable", _mapper.Map<IEnumerable<BookSlimViewModel>>(bookList));
        }

        #region Private Methods
        private async Task<List<SelectListItem>> GetAuthorSelectOptions()
        {
            var authors = await _authorService.GetAuthorsAsync();
            var authorOptions = new List<SelectListItem>();

            authorOptions = authors.Select(g => new SelectListItem(g.Name, g.Id.ToString())).OrderBy(i => i.Text).ToList();

            return authorOptions;
        }

        private async Task<List<SelectListItem>> GetGenreSelectOptions()
        {
            var genres = await _genreService.GetGenresAsync();
            var genreOptions = new List<SelectListItem>();

            genreOptions = genres.Select(g => new SelectListItem(g.Name, g.Id.ToString())).OrderBy(i => i.Text).ToList();

            return genreOptions;
        }
        #endregion
    }
}
