using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EblaLibraryManager.Web.ViewModels.Book
{
    public class CreateBookViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Status { get; set; }
        public string Language { get; set; }
        public int TotalPages { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }

        public List<SelectListItem> GenreOptions { get; set; }
        public List<SelectListItem> AuthorOptions { get; set; }
        public List<SelectListItem> LanguageOptions { get; set; }
        public List<SelectListItem> StatusOptions { get; set; }
    }
}
