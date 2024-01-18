using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Interfaces;

namespace Bloggy.CORE.Entities
{
	public class Genre : BaseEntity
	{
        public Guid Id { get; set; }
		public string Name { get; set; }


        public ICollection<Article> Articles { get; set; }
    }
}
