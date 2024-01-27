using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloggy.REPO.Mappings
{
    public class UserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            var superAdmin = new AppUser
            {
                Id = Guid.Parse("AE7D6647-4259-4EC0-88C8-DD8A20A5048F"),
                UserName = "mustafasand@hotmail.com",
                NormalizedUserName = "MUSTAFASAND@HOTMAIL.COM",
                Email = "mustafasand@hotmail.com",
                NormalizedEmail = "MUSTAFASAND@HOTMAIL.COM",
                PhoneNumber = "+905067600769",
                FirstName = "Mustafa",
                LastName = "SANDIKCILAR",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ImageId = Guid.Parse("5AA0376E-D526-4FA5-8D48-5DDA2D9CB585")
            };
            superAdmin.PasswordHash = CreatePasswordHash(superAdmin, "123");

            var admin = new AppUser
            {
                Id = Guid.Parse("84266068-1635-4A04-AA64-0780E4C1087A"),
                UserName = "admin@hotmail.com",
                NormalizedUserName = "ADMIN@HOTMAIL.COM",
                Email = "admin@hotmail.com",
                NormalizedEmail = "ADMIN@HOTMAIL.COM",
                PhoneNumber = "+905069999999",
                FirstName = "Admin",
                LastName = "User",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                ImageId = Guid.Parse("5AA0376E-D526-4FA5-8D48-5DDA2D9CB585")
            };
            admin.PasswordHash = CreatePasswordHash(admin, "123");
            
            builder.HasData(superAdmin, admin);
        }
        private string CreatePasswordHash(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }

    }
}

