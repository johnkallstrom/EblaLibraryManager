using AutoMapper;
using EblaLibraryManager.Data.Identity;
using EblaLibraryManager.Web.ViewModels.Account;
using EblaLibraryManager.Web.ViewModels.Manage;

namespace EblaLibraryManager.Web.Profiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<ApplicationUser, ProfileViewModel>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName));
            CreateMap<ApplicationUser, SettingsViewModel>();
        }
    }
}
