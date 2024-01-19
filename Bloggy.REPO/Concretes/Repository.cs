using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Interfaces;
using Bloggy.REPO.Context;
using Microsoft.EntityFrameworkCore;

namespace Bloggy.REPO.Concretes
{
	public class Repository<T> where T : class, IBaseEntity, new()
	{
        private readonly AppDbContext _dbContext;
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

		private DbSet<T> Table { get => _dbContext.Set<T>(); }

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }



	}
}
