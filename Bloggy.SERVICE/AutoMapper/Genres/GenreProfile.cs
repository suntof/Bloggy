using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bloggy.CORE.Entities;
using Bloggy.SERVICE.DTOs.Genres;

namespace Bloggy.SERVICE.AutoMapper.Genres
{
	public class GenreProfile : Profile
	{
		public GenreProfile() 
		{ 
			CreateMap<GenreDTO, Genre>().ReverseMap();
		}
	}
}
