using AutoMapper;
using Bloggy.CORE.Entities;
using Bloggy.SERVICE.DTOs.Articles;
using Bloggy.SERVICE.DTOs.Genres;
using Bloggy.SERVICE.Extensions;
using Bloggy.SERVICE.Services.Concrete;
using Bloggy.SERVICE.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Bloggy.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class GenreController : Controller
	{
		private readonly IGenreService _genreService;
		private readonly IValidator<Genre> _validator;
		private readonly IMapper _mapper;
		private readonly IToastNotification _toastNotification;

		public GenreController(IGenreService genreService, IValidator<Genre> validator, IMapper mapper, IToastNotification toastNotification)
        {
			_genreService = genreService;
			_validator = validator;
			_mapper = mapper;
			_toastNotification = toastNotification;
		}
        public async Task<IActionResult> Index()
		{
			var genres = await _genreService.GetAllGenresNonDeleted();
			return View(genres);
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(GenreAddDTO genreAddDTO)
		{
			var map = _mapper.Map<Genre>(genreAddDTO);
			var result = await _validator.ValidateAsync(map);


			if (result.IsValid)
			{
				await _genreService.CreateGenreAsync(genreAddDTO);
				_toastNotification.AddSuccessToastMessage("Makale türünüz başarı ile eklendi");
				return RedirectToAction("Index", "Genre", new { Area = "Admin" });
			}
			result.AddToModelState(this.ModelState);
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> Update(Guid genreId)
		{
			var genre = await _genreService.GetGenreByGuid(genreId);
			var map = _mapper.Map<Genre, GenreUpdateDTO>(genre);
			return View(map);
		}
		[HttpPost]
		public async Task<IActionResult> Update(GenreUpdateDTO genreUpdateDTO)
		{
			var map = _mapper.Map<Genre>(genreUpdateDTO);
			var result = await _validator.ValidateAsync(map);

			if (result.IsValid)
			{
				var name = await _genreService.UpdateGenreAsync(genreUpdateDTO);
				_toastNotification.AddSuccessToastMessage("Yazı türünüz başarıyla güncellendi");
				return RedirectToAction("Index", "Genre", new { Area = "Admin" });
			}
			result.AddToModelState(this.ModelState);
			return View(genreUpdateDTO);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid genreId)
		{
			await _genreService.SafeDeleteGenreAsync(genreId);
			_toastNotification.AddSuccessToastMessage("Makale türü başarı ile silindi");
			return RedirectToAction("Index", "Genre", new { Area = "Admin" });
		}
	}
}
