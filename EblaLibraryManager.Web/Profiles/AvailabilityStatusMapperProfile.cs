using AutoMapper;
using EblaLibraryManager.Data.Models;
using EblaLibraryManager.Web.ViewModels;

namespace EblaLibraryManager.Web.Profiles
{
    public class AvailabilityStatusMapperProfile : Profile
    {
        public AvailabilityStatusMapperProfile()
        {
            CreateMap<AvailabilityStatus, AvailabilityStatusViewModel>();
        }
    }
}
