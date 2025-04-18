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
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasOne(p => p.User)
                .WithOne(u => u.Person);
            
            builder.Property(p=>p.FirstName).IsRequired().HasMaxLength(20);
            builder.Property(p=>p.LastName).IsRequired().HasMaxLength(30);   
            builder.Property(p=>p.Address).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(20);
            
        }
    }
}
