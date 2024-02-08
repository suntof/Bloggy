using AutoMapper;
using Bloggy.CORE.Entities;
using Bloggy.SERVICE.DTOs.Articles;
using Bloggy.SERVICE.Extensions;
using Bloggy.SERVICE.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
		private readonly IGenreService _genreService;
		private readonly IMapper _mapper;
        private readonly IValidator<Article> _validator;

		public ArticleController(IArticleService articleService, IGenreService genreService, IMapper mapper, IValidator<Article> validator)
        {
            _articleService = articleService;
			_genreService = genreService;
			_mapper = mapper;
            _validator = validator;
		}
        public async Task<IActionResult> Index()
        {
            var articles = await _articleService.GetAllArticlesWithCategoryNonDeletedAsync();
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var genres = await _genreService.GetAllGenresNonDeleted();
            return View(new ArticleAddDTO { Genres = genres } );
        }
		[HttpPost]
		public async Task<IActionResult> Add(ArticleAddDTO articleAddDTO)
		{
            var map = _mapper.Map<Article>(articleAddDTO);
            var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
				await _articleService.CreateArticleAsync(articleAddDTO);
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
        public async Task<IActionResult> Update(Guid articleId)
        {
            var article = await _articleService.GetArticleWithGenreNonDeletedAsync(articleId);
            var genres = await _genreService.GetAllGenresNonDeleted();

            var articleUpdateDTO = _mapper.Map<ArticleUpdateDTO>(article);
            articleUpdateDTO.Genres = genres;
            return View(articleUpdateDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Update (ArticleUpdateDTO articleUpdateDTO)
        {
			var map = _mapper.Map<Article>(articleUpdateDTO);
			var result = await _validator.ValidateAsync(map);

            if (result.IsValid)
            {
				await _articleService.UpdateArticleAsync(articleUpdateDTO);
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
        public async Task<IActionResult> Delete (Guid articleId)
        {
            await _articleService.SafeDeleteArticleAsync(articleId);
            return RedirectToAction("Index", "Article", new { Area = "Admin" });
		}
	}
}
