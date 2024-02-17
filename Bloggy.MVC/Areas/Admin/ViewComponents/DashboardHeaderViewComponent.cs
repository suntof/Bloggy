using AutoMapper;
using Bloggy.CORE.Entities;
using Bloggy.SERVICE.DTOs.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.MVC.Areas.Admin.ViewComponents
{
    public class DashboardHeaderViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public DashboardHeaderViewComponent(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUser = await _userManager.GetUserAsync(HttpContext.User);
            var map = _mapper.Map<UserDTO>(loggedInUser);

            var role = string.Join("", await _userManager.GetRolesAsync(loggedInUser));
            map.Role = role;

            return View(map);
        }
    }
}
