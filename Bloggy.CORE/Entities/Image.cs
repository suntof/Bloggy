using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Interfaces;

namespace Bloggy.CORE.Entities
{
	public class Image : BaseEntity
	{
		public Image()
		{
			
		}
		public Image(string fileName, string fileType, string createdBy)
		{
			FileName = fileName;
			FileType = fileType;
			CreatedBy = createdBy;
		}
		public string FileName { get; set; } = "Undefined";
        public string FileType { get; set; }

        public ICollection<Article> Articles { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
