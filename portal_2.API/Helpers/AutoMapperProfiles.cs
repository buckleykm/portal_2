using AutoMapper;
using portal_2.API.Dtos;
using portal_2.API.Models;

namespace portal_2.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailedDto>();
        }
    }
}