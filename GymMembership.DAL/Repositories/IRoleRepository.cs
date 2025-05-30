using GymMembership.DATA;
using GymMembership.DATA.Entities;
using GymMembership.DATA.Infastructures;

namespace GymMembership.DAL.Repositories;

public interface IRoleRepository : IBaseRepository<Role>
{
    
}

public class RoleRepository : BaseRepository<Role>, IRoleRepository  
{
    private readonly GymMembershipDbContext _context;
    public RoleRepository(GymMembershipDbContext context) : base(context)
    {
        _context = context;
    }
}