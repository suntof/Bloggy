﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Entities;

namespace Bloggy.SERVICE.DTOs.Articles
{
    public class ArticleListDTO
    {
        public IList<Article> Articles { get; set; }
        public Guid? GenreId { get; set; }
        public virtual int CurrentPage { get; set; } = 1;
        public virtual int PageSize { get; set; } = 3;
        public virtual int TotalCount { get; set; }
        public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize));
        public virtual bool ShowPrevious => CurrentPage > 1;
        public virtual bool ShowNext => CurrentPage < TotalPages;
        public virtual bool IsAscending { get; set; } = false;

    }
}
