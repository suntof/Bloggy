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

		public ArticleController(IArticleService articleService, IGenreService genreService)
        {
            _articleService = articleService;
			_genreService = genreService;
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
    }
}
