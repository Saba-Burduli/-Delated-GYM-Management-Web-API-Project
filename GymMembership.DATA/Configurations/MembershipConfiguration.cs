using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GymMembership.DATA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMembership.DATA.Configurations
{
    public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
         builder.HasKey(m=>m.MembershipTypeId);
         builder.HasOne<User>(u => u.User)
             .WithMany(m => m.Memberships)
             .HasForeignKey("UserId")
             .OnDelete(DeleteBehavior.Cascade);
         builder.Property(m=>m.StartDate);
         builder.Property(m=>m.EndDate);
         builder.Property(m => m.IsActive);
         builder.Property(m => m.Price);
         
        }
    }
}
