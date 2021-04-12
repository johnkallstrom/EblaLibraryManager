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
            CreateMap<EditBookViewModel, Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookId));

            CreateMap<CreateBookViewModel, Book>();

            CreateMap<Book, BookSlimViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Book, BookViewModel>();
        }
    }
}
