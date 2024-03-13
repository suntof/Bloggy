using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Interfaces;

namespace Bloggy.CORE.Entities
{
	public class Article : BaseEntity 
	{
		public Article()
		{

		}
		public Article(string title, string content, Guid userId, string createdBy, Guid genreId, Guid imageId)
		{
			Title = title;
			Content = content;
			UserId = userId;
			GenreId = genreId ;
			ImageId = imageId;
			CreatedBy = createdBy;
		}
		public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;

        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }

        public Guid? ImageId { get; set; }
        public Image Image { get; set; }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public ICollection<ArticleVisitor> ArticleVisitors { get; set; }
    }
}
