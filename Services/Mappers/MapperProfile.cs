using AutoMapper;
using Domain.Entities;
using WebApplication2.Models.DTOs;

namespace Services.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateUserDto, User>()
                .ForMember(x => x.FullName, w => w.MapFrom(y => y.Name));
            CreateMap<User, UserDto>();
            CreateMap<User, UserDetailsDto>();
        }
    }
}