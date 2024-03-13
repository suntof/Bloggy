using Bloggy.SERVICE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.MVC.ViewComponents
{
    public class HomeGenresViewComponent : ViewComponent
    {
        private readonly IGenreService _genreService;

        public HomeGenresViewComponent(IGenreService genreService)
        {
            _genreService = genreService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres = await _genreService.GetAllGenresNonDeletedTake24();
            return View(genres);
        }
    }
}
