using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymMembership.DATA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMembership.DATA.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {                    //Fluent API Better 
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Roles)
                .WithMany(u => u.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "RoleUser",
                    left => left.HasOne<Role>()
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade),
                    right => right.HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade));
        }
    }
}
        