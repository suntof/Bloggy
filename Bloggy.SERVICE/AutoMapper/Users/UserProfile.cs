using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bloggy.CORE.Entities;
using Bloggy.SERVICE.DTOs.Users;

namespace Bloggy.SERVICE.AutoMapper.Users
{
	public class UserProfile : Profile
	{
        public UserProfile()
        {
            CreateMap<AppUser, UserDTO>().ReverseMap();
            CreateMap<AppUser, UserAddDTO>().ReverseMap();
            CreateMap<AppUser, UserUpdateDTO>().ReverseMap();
            CreateMap<AppUser, UserProfileDTO>().ReverseMap();
        }
    }
}
