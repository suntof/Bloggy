using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bloggy.CORE.Entities;
using Bloggy.CORE.Enums;
using Bloggy.REPO.UnitOfWorks;
using Bloggy.SERVICE.DTOs.Articles;
using Bloggy.SERVICE.Extensions;
using Bloggy.SERVICE.Helpers.Images;
using Bloggy.SERVICE.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Bloggy.SERVICE.Services.Concrete
{
	public class ArticleService : IArticleService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IImageHelper _imageHelper;
		private readonly ClaimsPrincipal _user;

		public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_httpContextAccessor = httpContextAccessor;
			_imageHelper = imageHelper;
			_user = httpContextAccessor.HttpContext.User;
		}

		public async Task<ArticleListDTO> GetAllByPagingAsync(Guid? genreId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
		{
			pageSize = pageSize > 20 ? 20 : pageSize;
			var articles = genreId == null
				? await _unitOfWork.GetRepository<Article>().GetAllAsync(a => !a.IsDeleted, a => a.Genre, i => i.Image, u => u.User)
				: await _unitOfWork.GetRepository<Article>().GetAllAsync(a => a.GenreId == genreId && !a.IsDeleted,
					a => a.Genre, i => i.Image, u => u.User);
			var sortedArticles = isAscending
				? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
				: articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
			return new ArticleListDTO
			{
				Articles = sortedArticles,
				GenreId = genreId == null ? null : genreId.Value,
				CurrentPage = currentPage,
				PageSize = pageSize,
				TotalCount = articles.Count,
				IsAscending = isAscending
			};
		}
		public async Task CreateArticleAsync(ArticleAddDTO articleAddDTO)
		{
			//var userId = Guid.Parse("AE7D6647-4259-4EC0-88C8-DD8A20A5048F");
			var userId = _user.GetLoggedInUserId();
			var userEmail = _user.GetLoggedInEmail();
			var imageUpload = await _imageHelper.Upload(articleAddDTO.Title, articleAddDTO.Photo, ImageType.Post);
			Image image = new(imageUpload.FullName, articleAddDTO.Photo.ContentType, userEmail);
			await _unitOfWork.GetRepository<Image>().AddAsync(image);

			var article = new Article(articleAddDTO.Title, articleAddDTO.Content, userId, userEmail, articleAddDTO.GenreId, image.Id);
			await _unitOfWork.GetRepository<Article>().AddAsync(article);
			await _unitOfWork.SaveAsync();
		}

		public async Task<List<ArticleDTO>> GetAllArticlesWithGenreNonDeletedAsync()
		{

			var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted == false, x => x.Genre);
			var map = _mapper.Map<List<ArticleDTO>>(articles);
			return map;
		}

		public async Task<ArticleDTO> GetArticleWithGenreNonDeletedAsync(Guid articleId)
		{

			var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.Id == articleId, x => x.Genre, x => x.Image, u => u.User);
			var map = _mapper.Map<ArticleDTO>(article);
			return map;
		}
		public async Task UpdateArticleAsync(ArticleUpdateDTO articleUpdateDTO)
		{
			var userEmail = _user.GetLoggedInEmail();
			var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.Id == articleUpdateDTO.Id, x => x.Genre, x => x.Image);

			if (articleUpdateDTO.Photo != null)
			{
				_imageHelper.Delete(article.Image.FileName);

				var imageUpload = await _imageHelper.Upload(articleUpdateDTO.Title, articleUpdateDTO.Photo, ImageType.Post);
				Image image = new(imageUpload.FullName, articleUpdateDTO.Photo.ContentType, userEmail);
				await _unitOfWork.GetRepository<Image>().AddAsync(image);

				article.ImageId = image.Id;
			}
			else
			{
				_mapper.Map(articleUpdateDTO, article);
				//article.Title = articleUpdateDTO.Title;
				//article.Content = articleUpdateDTO.Content;
				//article.GenreId = articleUpdateDTO.GenreId;
				article.UpdatedDate = DateTime.Now;
				article.UpdatedBy = userEmail;

			}
			await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
			await _unitOfWork.SaveAsync();


		}
		public async Task SafeDeleteArticleAsync(Guid articleId)
		{
			var userEmail = _user.GetLoggedInEmail();
			var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

			article.IsDeleted = true;
			article.DeleteDate = DateTime.Now;
			article.DeletedBy = userEmail;
			await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
			await _unitOfWork.SaveAsync();
		}

		public async Task<List<ArticleDTO>> GetAllArticlesWithGenreDeletedAsync()
		{
			var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted == true, x => x.Genre);
			var map = _mapper.Map<List<ArticleDTO>>(articles);
			return map;
		}

		public async Task UndoDeleteArticleAsync(Guid articleId)
		{
			var userEmail = _user.GetLoggedInEmail();
			var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

			article.IsDeleted = false;
			article.DeleteDate = null;
			article.DeletedBy = null;
			await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
			await _unitOfWork.SaveAsync();

		}
		public async Task<ArticleListDTO> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
		{
			pageSize = pageSize > 20 ? 20 : pageSize;
			var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(
				a => !a.IsDeleted && (a.Title.Contains(keyword) || a.Content.Contains(keyword) || a.Genre.Name.Contains(keyword)),
			a => a.Genre, i => i.Image, u => u.User);

			var sortedArticles = isAscending
				? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
				: articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
			return new ArticleListDTO
			{
				Articles = sortedArticles,
				CurrentPage = currentPage,
				PageSize = pageSize,
				TotalCount = articles.Count,
				IsAscending = isAscending
			};
		}
	}
}
