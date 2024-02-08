using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bloggy.CORE.Entities;
using Bloggy.REPO.UnitOfWorks;
using Bloggy.SERVICE.DTOs.Articles;
using Bloggy.SERVICE.Services.Interfaces;

namespace Bloggy.SERVICE.Services.Concrete
{
	public class ArticleService : IArticleService
	{
		private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
            _mapper = mapper;
        }

		public async Task CreateArticleAsync(ArticleAddDTO articleAddDTO)
		{
			var userId = Guid.Parse("AE7D6647-4259-4EC0-88C8-DD8A20A5048F");
			var article = new Article
			{
				Title = articleAddDTO.Title,
				Content = articleAddDTO.Content,
				GenreId = articleAddDTO.GenreId,
				UserId = userId,
			};
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
			var article = await _unitOfWork.GetRepository<Article>().GetAsync(x => x.IsDeleted == false && x.Id == articleUpdateDTO.Id, x => x.Genre);
			article.Title = articleUpdateDTO.Title;
			article.Content = articleUpdateDTO.Content;
			article.GenreId = articleUpdateDTO.GenreId;
			await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
			await _unitOfWork.SaveAsync();

		}
		public async Task SafeDeleteArticleAsync(Guid articleId)
		{
			var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);

			article.IsDeleted = true;
			article.DeleteDate= DateTime.Now;
			await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
			await _unitOfWork.SaveAsync();
		}
	}
}
