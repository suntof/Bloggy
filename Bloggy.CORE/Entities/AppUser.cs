using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Bloggy.CORE.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid ImageId { get; set; } = Guid.Parse("5AA0376E-D526-4FA5-8D48-5DDA2D9CB585");

		public Image Image { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
