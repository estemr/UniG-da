using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Entity.Entities.Identity;

namespace TTS.Data.Mappings
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
                UserId = Guid.Parse("B497F1B4-3299-4CB9-94AF-E3A1A6C7AC8E"),
                RoleId = Guid.Parse("3DE5D956-82D9-4A56-8DE5-7D440EB4216F"),

            },
            new AppUserRole
            {
                UserId = Guid.Parse("989AFD35-55A6-40A2-92B7-725A9B0E8822"),
                RoleId = Guid.Parse("B270AE59-5D7A-4AE8-BCA1-2BF521AF61CD"),
            });
        }
    }
}
