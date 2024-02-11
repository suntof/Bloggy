using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Entities;
using FluentValidation;

namespace Bloggy.SERVICE.FluentValidations
{
	public class GenreValidator : AbstractValidator<Genre>
	{
        public GenreValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .NotNull()
               .MinimumLength(3)
               .MaximumLength(20)
               .WithName("Yazı Türü Adı");
           
        }
    }
}
