using EblaLibraryManager.Data.Enumerations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EblaLibraryManager.Web.ViewModels.Book
{
    public class EditBookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public List<SelectListItem> LanguageOptions { get; set; }
        public string Publisher { get; set; }
        public int TotalPages { get; set; }
        public int GenreId { get; set; }
        public List<SelectListItem> GenreOptions { get; set; }
        public int AuthorId { get; set; }
        public List<SelectListItem> AuthorOptions { get; set; }
        public int AvailabilityStatusId { get; set; }
        public List<SelectListItem> AvailabilityStatusOptions { get; set; }


        public EditBookViewModel()
        {
            GenreOptions = new List<SelectListItem>();
            AuthorOptions = new List<SelectListItem>();

            AvailabilityStatusOptions = new List<SelectListItem>
            {
                new SelectListItem($"{AvailabilityStatusTypes.Available}", $"{(int)AvailabilityStatusTypes.Available}"),
                new SelectListItem($"{AvailabilityStatusTypes.Reserved}", $"{(int)AvailabilityStatusTypes.Reserved}"),
                new SelectListItem($"{AvailabilityStatusTypes.Loaned}", $"{(int)AvailabilityStatusTypes.Loaned}"),
                new SelectListItem($"{AvailabilityStatusTypes.None}", $"{(int)AvailabilityStatusTypes.None}")
            };

            LanguageOptions = new List<SelectListItem>
            {
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
