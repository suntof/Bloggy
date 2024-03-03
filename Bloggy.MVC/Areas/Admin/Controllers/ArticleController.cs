using AutoMapper;
using Bloggy.CORE.Entities;
using Bloggy.SERVICE.DTOs.Articles;
using Bloggy.SERVICE.Extensions;
using Bloggy.SERVICE.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Bloggy.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
		private readonly IGenreService _genreService;
		private readonly IMapper _mapper;
        private readonly IValidator<Article> _validator;
		private readonly IToastNotification _toastNotification;

		public ArticleController(IArticleService articleService, IGenreService genreService, IMapper mapper, IValidator<Article> validator, IToastNotification toastNotification)
        {
            _articleService = articleService;
			_genreService = genreService;
			_mapper = mapper;
            _validator = validator;
			_toastNotification = toastNotification;
		}


        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin, User")]
        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesWithGenreNonDeletedAsync();
            return View(articles);
        }
        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> DeletedArticles()
		{
			var articles = await _articleService.GetAllArticlesWithGenreDeletedAsync();
			return View(articles);
		}
		[HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin, User")]
        public async Task<IActionResult> Add()
        {
            var genres = await _genreService.GetAllGenresNonDeleted();
            
            return View(new ArticleAddDTO { Genres = genres } );
        }
		[HttpPost]
        [Authorize(Roles = "SuperAdmin, Admin, User")]
        public async Task<IActionResult> Add(ArticleAddDTO articleAddDTO)
		{
            var map = _mapper.Map<Article>(articleAddDTO);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
				await _articleService.CreateArticleAsync(articleAddDTO);
				_toastNotification.AddSuccessToastMessage("Makaleniz başarı ile eklendi");
				return RedirectToAction("Index", "Article", new { Area = "Admin" });
			}
            else
            {
				result.AddToModelState(this.ModelState);

			}
			var genres = await _genreService.GetAllGenresNonDeleted();
			return View(new ArticleAddDTO { Genres = genres });
		}
        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin, User")]
        public async Task<IActionResult> Update(Guid articleId)
        {
            var article = await _articleService.GetArticleWithGenreNonDeletedAsync(articleId);
            var genres = await _genreService.GetAllGenresNonDeleted();

            var articleUpdateDTO = _mapper.Map<ArticleUpdateDTO>(article);
            articleUpdateDTO.Genres = genres;
            return View(articleUpdateDTO);
        }
        [HttpPost]
        [Authorize(Roles = "SuperAdmin, Admin, User")]
        public async Task<IActionResult> Update (ArticleUpdateDTO articleUpdateDTO)
        {
			var map = _mapper.Map<Article>(articleUpdateDTO);
			var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
				await _articleService.UpdateArticleAsync(articleUpdateDTO);
				_toastNotification.AddSuccessToastMessage("Makaleniz başarı ile güncellendi");
				return RedirectToAction("Index", "Article", new { Area = "Admin" });
			}
            else
            {
				result.AddToModelState(this.ModelState);
			}
            
            var genres = await _genreService.GetAllGenresNonDeleted();
            articleUpdateDTO.Genres = genres;

            return View(articleUpdateDTO);
        }
        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> Delete (Guid articleId)
        {
            await _articleService.SafeDeleteArticleAsync(articleId);
			_toastNotification.AddSuccessToastMessage("Makaleniz başarı ile silindi");
			return RedirectToAction("Index", "Article", new { Area = "Admin" });
		}

        [Authorize(Roles = "SuperAdmin, Admin")]
        public async Task<IActionResult> UndoDelete(Guid articleId)
		{
			await _articleService.UndoDeleteArticleAsync(articleId);
			_toastNotification.AddSuccessToastMessage("Silme işlemi başarıyla geri alındı");
			return RedirectToAction("Index", "Article", new { Area = "Admin" });
		}
	}
}
