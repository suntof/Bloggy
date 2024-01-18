using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bloggy.REPO.Context
{
	public class AppDbContext : DbContext
	{
		protected AppDbContext()
		{

		}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
		{
			
		}

		public DbSet<Article> Articles { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Image> Images { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
