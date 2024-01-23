using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Entities;
using Bloggy.REPO.UnitOfWorks;
using Bloggy.SERVICE.Services.Interfaces;

namespace Bloggy.SERVICE.Services.Concrete
{
	public class ArticleService : IArticleService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ArticleService(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}
        public async Task<List<Article>> GetAllArticlesAsync()
		{
			return await _unitOfWork.GetRepository<Article>().GetAllAsync();
		}
	}
}
