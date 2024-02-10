using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.SERVICE.DTOs.Genres;
using Microsoft.AspNetCore.Http;

namespace Bloggy.SERVICE.DTOs.Articles
{
	public class ArticleAddDTO
	{
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid GenreId { get; set; }

        public IFormFile Photo { get; set; }
        public IList<GenreDTO> Genres { get; set; }
    }
}
