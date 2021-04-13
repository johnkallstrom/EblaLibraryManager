using AutoMapper;
using EblaLibraryManager.Data.Models;
using EblaLibraryManager.Web.ViewModels.Book;

namespace EblaLibraryManager.Web.Profiles
{
    public class BookMapperProfile : Profile
    {
        public BookMapperProfile()
        {
            CreateMap<Book, EditBookViewModel>();
            CreateMap<EditBookViewModel, Book>();
            CreateMap<CreateBookViewModel, Book>();
            CreateMap<Book, BookViewModel>();

            CreateMap<Book, BookSlimViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
        }
    }
}
