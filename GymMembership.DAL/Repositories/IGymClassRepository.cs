using GymMembership.DATA;
using GymMembership.DATA.Entities;
using GymMembership.DATA.Infastructures;

namespace GymMembership.DAL.Repositories;

public interface IGymClassRepository : IBaseRepository<GymClass>
{
    
}

public class GymClassRepository : BaseRepository<GymClass>, IGymClassRepository
{
    private readonly GymMembershipDbContext _context;
    
    public GymClassRepository(GymMembershipDbContext context) : base(context)
    {
        _context = context;
    }
    
    
}