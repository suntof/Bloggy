using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Entities;
using Bloggy.SERVICE.DTOs.Genres;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.SERVICE.Services.Interfaces
{
	public interface IGenreService
	{
		Task<List<GenreDTO>> GetAllGenresNonDeleted();
		Task<List<GenreDTO>> GetAllGenresDeleted();
		Task CreateGenreAsync(GenreAddDTO genreAddDTO);
		Task<Genre> GetGenreByGuid(Guid id);
		Task<string> UpdateGenreAsync(GenreUpdateDTO genreUpdateDTO);
		Task SafeDeleteGenreAsync(Guid genreId);
		Task UndoDeleteGenreAsync(Guid genreId);
	}
}
