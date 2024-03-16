using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Entities;
using FluentValidation;

namespace Bloggy.SERVICE.FluentValidations
{
	public class ArticleValidator : AbstractValidator<Article>
	{
		public ArticleValidator()
		{
			RuleFor(x => x.Title)
				.NotEmpty()
				.NotNull()
				.MinimumLength(3)
				.MaximumLength(150)
				.WithName("Başlık");

			RuleFor(x => x.Content)
				.NotEmpty()
				.NotNull()
				.MinimumLength(3)
				.MaximumLength(2000)
				.WithName("İçerik");
		}
	}
}
