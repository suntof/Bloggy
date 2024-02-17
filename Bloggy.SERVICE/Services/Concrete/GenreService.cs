using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bloggy.CORE.Entities;
using Bloggy.REPO.UnitOfWorks;
using Bloggy.SERVICE.DTOs.Genres;
using Bloggy.SERVICE.Extensions;
using Bloggy.SERVICE.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bloggy.SERVICE.Services.Concrete
{
	public class GenreService : IGenreService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpcontextAccessor;
		private readonly ClaimsPrincipal _user;

		public GenreService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_httpcontextAccessor = httpContextAccessor;
			_user = _httpcontextAccessor.HttpContext.User;
		}
        public async Task<List<GenreDTO>> GetAllGenresNonDeleted()
		{
			var genres = await _unitOfWork.GetRepository<Genre>().GetAllAsync(x => x.IsDeleted == false);
			var map = _mapper.Map<List<GenreDTO>>(genres);
			return map;
		}
		public async Task CreateGenreAsync(GenreAddDTO genreAddDTO)
		{
			var userEmail = _user.GetLoggedInEmail();
			Genre genre = new(genreAddDTO.Name, userEmail);
			await _unitOfWork.GetRepository<Genre>().AddAsync(genre);
			await _unitOfWork.SaveAsync();

		}
		public async Task<Genre> GetGenreByGuid(Guid id)
		{
			var genre = await _unitOfWork.GetRepository<Genre>().GetByGuidAsync(id);
			return genre;
		}

		public async Task<string> UpdateGenreAsync(GenreUpdateDTO genreUpdateDTO)
		{
			var userMail = _user.GetLoggedInEmail();
			var genre = await _unitOfWork.GetRepository<Genre>().GetAsync(x=>x.IsDeleted == false && x.Id == genreUpdateDTO.Id);

			genre.Name = genreUpdateDTO.Name;
			genre.UpdatedDate = DateTime.Now;
			genre.CreatedBy = userMail;
			
			await _unitOfWork.GetRepository<Genre>().UpdateAsync(genre);
			await _unitOfWork.SaveAsync();
		
			return genre.Name;
		}
		public async Task SafeDeleteGenreAsync(Guid genreId)
		{
			var userEmail = _user.GetLoggedInEmail();
			var genre = await _unitOfWork.GetRepository<Genre>().GetByGuidAsync(genreId);

			genre.IsDeleted = true;
			genre.DeleteDate = DateTime.Now;
			genre.DeletedBy = userEmail;
			await _unitOfWork.GetRepository<Genre>().UpdateAsync(genre);
			await _unitOfWork.SaveAsync();
		}

		public async Task<List<GenreDTO>> GetAllGenresDeleted()
		{
			var genres = await _unitOfWork.GetRepository<Genre>().GetAllAsync(x => x.IsDeleted == true);
			var map = _mapper.Map<List<GenreDTO>>(genres);
			return map;
		}

		public async Task UndoDeleteGenreAsync(Guid genreId)
		{
			var userEmail = _user.GetLoggedInEmail();
			var genre = await _unitOfWork.GetRepository<Genre>().GetByGuidAsync(genreId);

			genre.IsDeleted = false;
			genre.DeleteDate = null;
			genre.DeletedBy = userEmail;
			await _unitOfWork.GetRepository<Genre>().UpdateAsync(genre);
			await _unitOfWork.SaveAsync();
		}
	}
}
