using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EblaLibraryManager.Web.ViewModels.Book
{
    public class CreateBookViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public List<SelectListItem> LanguageOptions { get; set; }
        public int TotalPages { get; set; }
        public int GenreId { get; set; }
        public List<SelectListItem> GenreOptions { get; set; }

        public CreateBookViewModel()
        {
            GenreOptions = new List<SelectListItem>();

            LanguageOptions = new List<SelectListItem>
            {
                new SelectListItem("Choose language", "0", true, true),
                new SelectListItem("Arabic", "Arabic"),
                new SelectListItem("Chinese", "Chinese"),
                new SelectListItem("English", "English"),
                new SelectListItem("French", "French"),
                new SelectListItem("German", "German"),
                new SelectListItem("Italian", "Italian"),
                new SelectListItem("Russian", "Russian"),
                new SelectListItem("Swedish", "Swedish"),
                new SelectListItem("Spanish", "Spanish"),
            };
        }
    }
}
