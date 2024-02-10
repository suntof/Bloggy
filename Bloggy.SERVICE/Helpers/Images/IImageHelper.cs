using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Enums;
using Bloggy.SERVICE.DTOs.Images;
using Microsoft.AspNetCore.Http;

namespace Bloggy.SERVICE.Helpers.Images
{
	public interface IImageHelper
	{
		Task<ImageUploadedDTO> Upload(string name, IFormFile imageFile, ImageType imageType, string folderName = null);
		void Delete(string imageName);
	}
}
