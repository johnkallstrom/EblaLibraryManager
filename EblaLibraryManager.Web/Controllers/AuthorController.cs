using AutoMapper;
using EblaLibraryManager.Core.Services.Interfaces;
using EblaLibraryManager.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EblaLibraryManager.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAuthorService _authorService;

        public AuthorController(
            IMapper mapper,
            IAuthorService authorService)
        {
            _mapper = mapper;
            _authorService = authorService;
        }


        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AuthorDetails(int authorId)
        {
            var author = await _authorService.GetAuthorByIdAsync(authorId);

            var model = _mapper.Map<AuthorViewModel>(author);

            return View(model);
        }
    }
}
