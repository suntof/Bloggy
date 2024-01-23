using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.REPO.Concretes;
using Bloggy.REPO.Context;
using Bloggy.REPO.Interfaces;
using Bloggy.REPO.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bloggy.REPO.Extensions
{
	public static class DataLayerExtensions
	{
		public static IServiceCollection LoadDataLayerExtensions(this IServiceCollection services, IConfiguration config )
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddDbContext<AppDbContext>(x => x.UseSqlServer(config.GetConnectionString("DefaultConnection")));

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			return services;
		}
	}
}
