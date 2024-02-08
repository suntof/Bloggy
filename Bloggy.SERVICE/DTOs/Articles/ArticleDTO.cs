using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.SERVICE.DTOs.Genres;

namespace Bloggy.SERVICE.DTOs.Articles
{
    public class ArticleDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public GenreDTO Genre { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
