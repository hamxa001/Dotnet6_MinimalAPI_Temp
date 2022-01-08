using AutoMapper;
using WebApplication1.DTOs.UserDTOs;

namespace WebApplication1
{
    public class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<AspNetUsers, AddUserDto>()
            .ForMember(x => x.UserName, c => c.MapFrom(x => x.UserName))
            .ForMember(x => x.NormalizedUserName, c => c.MapFrom(x => x.NormalizedUserName))
            .ForMember(x => x.Email, c => c.MapFrom(x => x.Email))
            .ForMember(x => x.NormalizedEmail, c => c.MapFrom(x => x.NormalizedEmail))
            .ForMember(x => x.PasswordHash, c => c.MapFrom(x => x.PasswordHash))
            .ForMember(x => x.PhoneNumber, c => c.MapFrom(x => x.PhoneNumber)).ReverseMap();
        }
    }
}
