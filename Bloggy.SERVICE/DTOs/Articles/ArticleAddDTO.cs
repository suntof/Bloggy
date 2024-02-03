using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.SERVICE.DTOs.Genres;

namespace Bloggy.SERVICE.DTOs.Articles
{
	public class ArticleAddDTO
	{
        public string Title { get; set; }
        public string Content { get; set; }
        public string GenreId { get; set; }
        public IList<GenreDTO> Genres { get; set; }
    }
}
