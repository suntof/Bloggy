using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloggy.REPO.Mappings
{
	public class ArticleMap : IEntityTypeConfiguration<Article>
	{
		public void Configure(EntityTypeBuilder<Article> builder)
		{
			builder.HasData(new Article
			{
				Id = Guid.Parse("15FD39A8-A3FC-46A1-B40B-5AE6825B4C5A"),
				Title = "Deneme",
				Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed ac varius augue. Phasellus molestie felis at ex aliquet mollis. Aliquam consectetur leo sit amet eros malesuada, vel elementum ante feugiat. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Curabitur fringilla dui nec tincidunt consequat. Proin eros.",
				ViewCount = 15,
				GenreId = Guid.Parse("15FD39A8-A3FC-46A1-B40B-5AE6825B4C5A"),
				ImageId = Guid.Parse("5AA0376E-D526-4FA5-8D48-5DDA2D9CB585"),
				CreatedBy= "Admin Test",
				CreatedDate = DateTime.Now,
				IsDeleted = false,
				UserId = Guid.Parse("AE7D6647-4259-4EC0-88C8-DD8A20A5048F")
            });
		}
	}
}
