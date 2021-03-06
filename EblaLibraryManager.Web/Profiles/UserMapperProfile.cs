using AutoMapper;
using EblaLibraryManager.Data.Identity;
using EblaLibraryManager.Web.ViewModels.Account;

namespace EblaLibraryManager.Web.Profiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<ApplicationUser, ProfileViewModel>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserName));
            CreateMap<ApplicationUser, SettingsViewModel>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
            CreateMap<SettingsViewModel, ApplicationUser>();
        }
    }
}
