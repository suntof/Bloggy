using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bloggy.CORE.Entities;
using Bloggy.REPO.UnitOfWorks;
using Bloggy.SERVICE.DTOs.Genres;
using Bloggy.SERVICE.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bloggy.SERVICE.Services.Concrete
{
	public class GenreService : IGenreService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<List<GenreDTO>> GetAllGenresNonDeleted()
		{
			var genres = await _unitOfWork.GetRepository<Genre>().GetAllAsync(x => x.IsDeleted == false);
			var map = _mapper.Map<List<GenreDTO>>(genres);
			return map;
		}
	}
}
