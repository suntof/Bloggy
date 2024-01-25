using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bloggy.CORE.Entities;
using Bloggy.REPO.UnitOfWorks;
using Bloggy.SERVICE.DTOs.Articles;
using Bloggy.SERVICE.Services.Interfaces;

namespace Bloggy.SERVICE.Services.Concrete
{
	public class ArticleService : IArticleService
	{
		private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ArticleDTO>> GetAllArticlesAsync()
		{
			
			var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync();
            var map = _mapper.Map<List<ArticleDTO>>(articles);
            return map;
        }
	}
}
