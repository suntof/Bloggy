using System.Data;
using AutoMapper;
using Bloggy.CORE.Entities;
using Bloggy.SERVICE.DTOs.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace Bloggy.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;
		private readonly RoleManager<AppRole> _roleManager;
		private readonly IToastNotification _toastNotification;

		public UserController(UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, IToastNotification toastNotification)
		{
			_userManager = userManager;
			_mapper = mapper;
			_roleManager = roleManager;
			_toastNotification = toastNotification;
		}
		public async Task<IActionResult> Index()
		{
			var users = await _userManager.Users.ToListAsync();
			var map = _mapper.Map<List<UserDTO>>(users);

			foreach (var item in map)
			{
				var findUser = await _userManager.FindByIdAsync(item.Id.ToString());
				var role = string.Join("", await _userManager.GetRolesAsync(findUser));

				item.Role = role;

			}

			return View(map);
		}
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var roles = await _roleManager.Roles.ToListAsync();
			return View(new UserAddDTO { Roles = roles });

		}
		[HttpPost]
		public async Task<IActionResult> Add(UserAddDTO userAddDTO)
		{
			var map = _mapper.Map<AppUser>(userAddDTO);
			var roles = await _roleManager.Roles.ToListAsync();

			if (ModelState.IsValid)
			{
				map.UserName = userAddDTO.Email;
				var result = await _userManager.CreateAsync(map, userAddDTO.Password);
				if (result.Succeeded)
				{
					var findRole = await _roleManager.FindByIdAsync(userAddDTO.RoleId.ToString());
					await _userManager.AddToRoleAsync(map, findRole.ToString());
					_toastNotification.AddSuccessToastMessage("Kullanıcı başarı ile eklendi");
					return RedirectToAction("Index", "User", new { Area = "Admin" });
				}
				else
				{
					foreach (var errors in result.Errors)
					{
						ModelState.AddModelError("", errors.Description);
						return View(new UserAddDTO { Roles = roles });
					}
				}
			}
			return View(new UserAddDTO { Roles = roles });
		}
		[HttpGet]
		public async Task<IActionResult> Update (Guid userId)
		{
			var user = await _userManager.FindByIdAsync(userId.ToString());
			var roles = await _roleManager.Roles.ToListAsync();

			var map = _mapper.Map<UserUpdateDTO>(user);
			map.Roles= roles;

			return View(map);
		}
		[HttpPost]
		public async Task<IActionResult> Update ( UserUpdateDTO userUpdateDTO)
		{
			var user = await _userManager.FindByIdAsync(userUpdateDTO.Id.ToString());
			if (user != null)
			{
				var userRole = string.Join("", await _userManager.GetRolesAsync(user));
				var roles = await _roleManager.Roles.ToListAsync();
				if (ModelState.IsValid)
				{
					_mapper.Map(userUpdateDTO, user);
					user.UserName = userUpdateDTO.Email;
					user.SecurityStamp = Guid.NewGuid().ToString();
					var result = await _userManager.UpdateAsync(user);
					if (result.Succeeded)
					{
						await _userManager.RemoveFromRoleAsync(user, userRole);
						var findRole = await _roleManager.FindByIdAsync(userUpdateDTO.RoleId.ToString());
						await _userManager.AddToRoleAsync(user, findRole.Name);
						_toastNotification.AddSuccessToastMessage("Kullanıcı başarı ile güncellendi");
						return RedirectToAction("Index", "User", new { Area = "Admin" });
					}
					else
					{
						foreach (var errors in result.Errors)
						{
							ModelState.AddModelError("", errors.Description);
							return View(new UserUpdateDTO { Roles = roles });
						}
					}
				}
			}
			return View();		
		}


		public async Task<IActionResult> Delete (Guid userId)
		{
			var user = await _userManager.FindByIdAsync(userId.ToString());
			var result = await _userManager.DeleteAsync(user);
			if (result.Succeeded)
			{
				_toastNotification.AddSuccessToastMessage("Kullanıcı başarı ile silindi");
				return RedirectToAction("Index", "User", new { Area = "Admin" });
			}
			else
			{
				foreach (var errors in result.Errors)
				{
					ModelState.AddModelError("", errors.Description);
				}
			}
			return View();
		}
	}
}
