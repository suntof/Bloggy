using Bloggy.CORE.Entities;
using Bloggy.REPO.Context;
using Bloggy.REPO.Extensions;
using Bloggy.SERVICE.Extensions;
using Microsoft.AspNetCore.Identity;
using NToastNotify;

namespace Bloggy.MVC
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.LoadDataLayerExtensions(builder.Configuration);
			builder.Services.LoadServiceLayerExtensions();
			builder.Services.AddSession();

			// Add services to the container.
			builder.Services.AddControllersWithViews()
				.AddNToastNotifyToastr( new ToastrOptions()
				{
					PositionClass = ToastPositions.TopCenter,
					TimeOut = 3000,
				});


			builder.Services.AddIdentity<AppUser, AppRole>(x =>
			{
				x.Password.RequireNonAlphanumeric = false;
				x.Password.RequireLowercase = false;
				x.Password.RequireUppercase = false;
			})
				.AddRoleManager<RoleManager<AppRole>>()
				.AddEntityFrameworkStores<AppDbContext>()
				.AddDefaultTokenProviders();

			builder.Services.ConfigureApplicationCookie(config =>
			{
				config.LoginPath = new PathString("/Admin/Auth/Login");
				config.LogoutPath = new PathString("/Admin/Auth/Logout");
				config.Cookie = new CookieBuilder
				{
					Name = "Bloggy",
					HttpOnly = true,
					SameSite = SameSiteMode.Strict,
					SecurePolicy = CookieSecurePolicy.SameAsRequest //canlýya çýkýnca SameAsRequest yerine Always'i seç
				};
				config.SlidingExpiration = true;
				config.ExpireTimeSpan = TimeSpan.FromDays(3);
				config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");

			});
			

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseNToastNotify();
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseSession();
			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
					endpoints.MapAreaControllerRoute(
					name: "Admin",
					areaName: "Admin",
					pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
					);
					endpoints.MapDefaultControllerRoute();
			});

			app.Run();
		}
	}
}