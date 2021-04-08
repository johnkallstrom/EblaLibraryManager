using AutoMapper;
using EblaLibraryManager.Data.Models;
using EblaLibraryManager.Web.ViewModels;

namespace EblaLibraryManager.Web.Profiles
{
    public class GenreMapperProfile : Profile
    {
        public GenreMapperProfile()
        {
            CreateMap<Genre, GenreViewModel>();
        }
    }
}
