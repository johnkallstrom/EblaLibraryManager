using AutoMapper;
using EblaLibraryManager.Data.Models;
using EblaLibraryManager.Web.ViewModels;

namespace EblaLibraryManager.Web.Profiles
{
    public class BookMapperProfile : Profile
    {
        public BookMapperProfile()
        {
            CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
        }
    }
}
