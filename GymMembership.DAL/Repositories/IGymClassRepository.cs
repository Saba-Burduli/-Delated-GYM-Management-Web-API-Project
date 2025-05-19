using GymMembership.DATA;
using GymMembership.DATA.Entities;
using GymMembership.DATA.Infastructures;
using Microsoft.EntityFrameworkCore;

namespace GymMembership.DAL.Repositories;

public interface IGymClassRepository : IBaseRepository<GymClass>
{
    Task<bool> AssignToGymClassesAsync(int userId,List<int > gymClassIds);
    Task<List<GymClass>> GetGymClassesByUserAsync(int userld);
}

public class GymClassRepository : BaseRepository<GymClass>, IGymClassRepository
{
    private readonly GymMembershipDbContext _context;
    
    public GymClassRepository(GymMembershipDbContext context) : base(context)
    {
        _context = context;
    }
    
    public async Task<bool> AssignToGymClassesAsync(int userId, List<int> gymClassIds)
    {
        if (userId == null || gymClassIds == null || !gymClassIds.Any())
        {
            return false;
        }

        var existingAssigments = await _context.GymClassUsers
            .Where(gc => gc.UserId == userId && !gymClassIds.Any())
            .ToListAsync();

        var newAssignments = gymClassIds.Where(id => !existingAssigments.Any(ea => ea.GymClassId == id))
            .Select(id => new GymClassUsers { UserId = userId, GymClassId = id })
            .ToList();

        if (newAssignments.Any())
        {
            await _context.GymClassUsers.AddRangeAsync(newAssignments);
            await _context.SaveChangesAsync();
        }
        return true;
    }
    public async Task<List<GymClass>> GetGymClassesByUserAsync(int userld)
    {
        return await _context.GymClassUsers
            .Where(gc => gc.UserId == userld)
            .Select(gc => gc.GymClass)
            .ToListAsync();
    }
}