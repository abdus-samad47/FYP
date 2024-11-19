using FYP.DTO_s.UserDTOs;
using FYP.DTO_s;
using FYP.Models;
using AutoMapper;

namespace FYP.Utility
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDTO>();
            CreateMap<CreateUserDTO, User>();
        }
    }
}
