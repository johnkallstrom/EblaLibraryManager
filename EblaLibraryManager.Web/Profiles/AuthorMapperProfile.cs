using AutoMapper;
using EblaLibraryManager.Data.Models;
using EblaLibraryManager.Web.ViewModels;

namespace EblaLibraryManager.Web.Profiles
{
    public class AuthorMapperProfile : Profile
    {
        public AuthorMapperProfile()
        {
            CreateMap<Author, AuthorSlimViewModel>();
            CreateMap<Author, AuthorViewModel>();
        }
    }
}
