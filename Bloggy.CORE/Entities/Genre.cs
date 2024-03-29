﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Interfaces;

namespace Bloggy.CORE.Entities
{
	public class Genre : BaseEntity
	{
		public Genre() 
		{ 
		
		}
		public Genre (string name, string createdBy)
		{
			Name = name;
			CreatedBy = createdBy;
		}

        public Guid Id { get; set; }
		public string Name { get; set; }


        public ICollection<Article> Articles { get; set; }
    }
}
