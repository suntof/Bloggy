using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Interfaces;
using Bloggy.REPO.Interfaces;

namespace Bloggy.REPO.UnitOfWorks
{
	public interface IUnitOfWork : IAsyncDisposable
	{
		IRepository<T> GetRepository<T>() where T : class, IBaseEntity, new();

		Task<int> SaveAsync();
		int Save();
	}
}
