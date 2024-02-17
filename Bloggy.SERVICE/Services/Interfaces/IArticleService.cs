﻿using System;
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
		Task<List<ArticleDTO>> GetAllArticlesWithCategoryNonDeletedAsync();
		Task<List<ArticleDTO>> GetAllArticlesWithGenreDeletedAsync();
		Task<ArticleDTO> GetArticleWithGenreNonDeletedAsync(Guid articleId);
		Task CreateArticleAsync(ArticleAddDTO articleAddDTO);
		Task UpdateArticleAsync(ArticleUpdateDTO articleUpdateDTO);
		Task SafeDeleteArticleAsync(Guid articleId);
		Task UndoDeleteArticleAsync(Guid articleId);
	}
}
