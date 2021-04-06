﻿using AutoMapper;
using EblaLibraryManager.Core.Services.Interfaces;
using EblaLibraryManager.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EblaLibraryManager.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;

        public BookController(
            IMapper mapper,
            IBookService bookService)
        {
            _mapper = mapper;
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
    }
}
