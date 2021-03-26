using AutoMapper;
using EblaLibraryManager.Data.Models;
using EblaLibraryManager.Web.ViewModels;

namespace EblaLibraryManager.Web.Profiles
{
    public class BookMapperProfile : Profile
    {
        public BookMapperProfile()
        {
            CreateMap<Book, BookViewModel>();
        }
    }
}
