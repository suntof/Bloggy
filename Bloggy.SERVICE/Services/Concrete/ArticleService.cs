using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bloggy.CORE.Entities;
using Bloggy.REPO.UnitOfWorks;
using Bloggy.SERVICE.DTOs.Articles;
using Bloggy.SERVICE.Extensions;
using Bloggy.SERVICE.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Bloggy.SERVICE.Services.Concrete
{
	public class ArticleService : IArticleService
	{
		private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ClaimsPrincipal _user;

		public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
			_unitOfWork = unitOfWork;
            _mapper = mapper;
			_httpContextAccessor = httpContextAccessor;
			_user = httpContextAccessor.HttpContext.User;
		}

		public async Task CreateArticleAsync(ArticleAddDTO articleAddDTO)
		{
			//var userId = Guid.Parse("AE7D6647-4259-4EC0-88C8-DD8A20A5048F");
			var userId = _user.GetLoggedInUserId();
			var userEmail = _user.GetLoggedInEmail();
			var imageId = Guid.Parse("5AA0376E-D526-4FA5-8D48-5DDA2D9CB585");
			var article = new Article( articleAddDTO.Title, articleAddDTO.Content, userId, userEmail, articleAddDTO.GenreId, imageId);
			await _unitOfWork.GetRepository<Article>().AddAsync(article);
			await _unitOfWork.SaveAsync();
		}

		public async Task<List<ArticleDTO>> GetAllArticlesWithCategoryNonDeletedAsync()
		{
			
			var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x=>x.IsDeleted == false, x=>x.Genre);
            var map = _mapper.Map<List<ArticleDTO>>(articles);
            return map;
        }

		public async Task<ArticleDTO> GetArticleWithGenreNonDeletedAsync(Guid articleId)
		{

			var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.Id == articleId, x => x.Genre);
			var map = _mapper.Map<ArticleDTO>(article);
			return map;
		}
		public async Task UpdateArticleAsync(ArticleUpdateDTO articleUpdateDTO)
		{
			var userEmail = _user.GetLoggedInEmail();
			var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.Id == articleUpdateDTO.Id, x => x.Genre);
			article.Title = articleUpdateDTO.Title;
			article.Content = articleUpdateDTO.Content;
			article.GenreId = articleUpdateDTO.GenreId;
			article.UpdatedDate = DateTime.Now;
			article.UpdatedBy = userEmail;
			await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
			await _unitOfWork.SaveAsync();

		}
		public async Task SafeDeleteArticleAsync(Guid articleId)
		{
			var userEmail = _user.GetLoggedInEmail();
			var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

			article.IsDeleted = true;
			article.DeleteDate= DateTime.Now;
			article.DeletedBy = userEmail;
			await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
			await _unitOfWork.SaveAsync();
		}
	}
}
