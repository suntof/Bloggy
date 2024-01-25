using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Entities;
using Bloggy.SERVICE.DTOs.Articles;

namespace Bloggy.SERVICE.Services.Interfaces
{
	public interface IArticleService
	{
		Task<List<ArticleDTO>> GetAllArticlesAsync();
	}
}
