using GymMembership.DATA;
using GymMembership.DATA.Entities;
using GymMembership.DATA.Infastructures;

namespace GymMembership.DAL.Repositories;

public interface IGymClassRepository : IBaseRepository<GymClass>
{
    Task<bool> AssignToGymClassesAsync(int userId,List<int > gymClassIds);
    List<GymClass> GetGymClassesByUserAsync(int userld);
}

public class GymClassRepository : BaseRepository<GymClass>, IGymClassRepository
{
    private readonly GymMembershipDbContext _context;
    
    public GymClassRepository(GymMembershipDbContext context) : base(context)
    {
        _context = context;
    }


    public Task<bool> AssignToGymClassesAsync(int userId, List<int> gymClassIds)
    {
        throw new NotImplementedException();
    }

    public List<GymClass> GetGymClassesByUserAsync(int userld)
    {
        throw new NotImplementedException();
    }
}