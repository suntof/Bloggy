﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloggy.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloggy.REPO.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("AE7D6647-4259-4EC0-88C8-DD8A20A5048F"),
                RoleId = Guid.Parse("E14438CC-D73B-4A83-A9CE-A2B8AE7A5D5A")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("84266068-1635-4A04-AA64-0780E4C1087A"),
                RoleId = Guid.Parse("871F34EE-D9CC-4CEF-A7EB-CDEEC5FEE1FF")
            });
        }
    }
}
