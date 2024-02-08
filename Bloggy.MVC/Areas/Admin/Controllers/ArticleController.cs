using AutoMapper;
using Bloggy.SERVICE.DTOs.Articles;
using Bloggy.SERVICE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
		private readonly IGenreService _genreService;
		private readonly IMapper _mapper;

		public ArticleController(IArticleService articleService, IGenreService genreService, IMapper mapper)
        {
            _articleService = articleService;
			_genreService = genreService;
			_mapper = mapper;
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
            await _articleService.CreateArticleAsync(articleAddDTO);
            return RedirectToAction("Index", "Article", new {Area = "Admin"});  

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
            await _articleService.UpdateArticleAsync(articleUpdateDTO);

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
