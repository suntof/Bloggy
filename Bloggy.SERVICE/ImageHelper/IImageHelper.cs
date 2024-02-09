using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.SERVICE.DTOs.Images;
using Microsoft.AspNetCore.Http;

namespace Bloggy.REPO.ImageHelper
{
	public interface IImageHelper
	{
		Task<ImageUploadedDTO> Upload(string name, IFormFile imageFile, string folderName = null);
		void Delete(string imageName);
	}
}
