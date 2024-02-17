using Bloggy.CORE.Entities;
using Bloggy.SERVICE.DTOs.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
           
        }
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            if (ModelState.IsValid) 
            {
                var user = await _userManager.FindByEmailAsync(userLoginDTO.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, userLoginDTO.Password, userLoginDTO.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-Postanızı veya şifrenizi hatalı girdiniz!");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-Postanızı veya şifrenizi hatalı girdiniz!");
                    return View();
                }
                
            }
            else
            {
                return View();
            }
            
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
		[Authorize]
		[HttpGet]
		public async Task<IActionResult> AccessDenied()
		{
            return View();
		}
	}
}
