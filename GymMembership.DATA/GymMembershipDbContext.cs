using GymMembership.DATA.Configurations;
using GymMembership.DATA.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymMembership.DATA;

public class GymMembershipDbContext : DbContext
{
    public DbSet<GymClass>GymClasses { get; set; }
    public DbSet<GymClassUsers>GymClassUsers { get; set; }
    public DbSet<Membership> Memberships { get; set; }
    public DbSet<MembershipType>MembershipTypes { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User>Users { get; set; }

    public GymMembershipDbContext()
    {
        
    }

    public GymMembershipDbContext(DbContextOptions<GymMembershipDbContext> context) : base(context)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new GymClassConfiguration());
        modelBuilder.ApplyConfiguration(new MembershipConfiguration());
        modelBuilder.ApplyConfiguration(new PersonConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        //Role Seeding
        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                RoleId = 1,
                RoleName = "Admin",
            },
            new Role
            {
                RoleId = 2,
                RoleName = "Member",
            },
            new Role
            {
                RoleId = 3,
                RoleName = "Trainer"
            });

        //GymClass Seeding
        modelBuilder.Entity<GymClass>().HasData(
            new GymClass
            {
                GymClassId = 1,
                GymClassName = "Wrestling",
            },
            new GymClass
            {
                GymClassId = 2,
                GymClassName = "Judo",
            },
            new GymClass
            {
                GymClassId = 3,
                GymClassName = "Karate",
            },
            new GymClass
            {
                GymClassId = 4,
                GymClassName = "Boxing"
            });
        
        //MembershipType Seeding
        modelBuilder.Entity<MembershipType>().HasData(
                new MembershipType
                {
                    MembershipTypeId = 1,
                    MembershipTypeName = "Monthly"
                },
                new MembershipType
                {
                    MembershipTypeId = 2,
                    MembershipTypeName = "Yearly"
                },
                new MembershipType
                {
                    MembershipTypeId = 3,
                    MembershipTypeName = "VIP"
                });
        
        //Person Seeding
        modelBuilder.Entity<Person>().HasData(
            new Person
            {
                PersonId = 1,
                FirstName = "Saba",
                LastName = "Burduli",
                Phone ="599553263",
                Address = "StBarbare Tbilisi,Georgia"
            },
            new Person
            {
                PersonId = 2,
                FirstName = "Lali",
                LastName = "Razmadze",
                Phone ="595753264",
                Address = "Racha,Ambrolauri st 183"
            }
            );
        
    }
}