using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.SERVICE.DTOs.Genres;

namespace Bloggy.SERVICE.Services.Interfaces
{
	public interface IGenreService
	{
		public Task<List<GenreDTO>> GetAllGenresNonDeleted();
	}
}
