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
}