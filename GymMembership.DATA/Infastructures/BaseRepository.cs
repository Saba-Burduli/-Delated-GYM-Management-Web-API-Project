using Microsoft.EntityFrameworkCore;

namespace GymMembership.DATA.Infastructures;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly GymMembershipDbContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(GymMembershipDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(_context));
        _dbSet = context.Set<T>() ?? throw new ArgumentNullException($"The context {nameof(context)} is null");
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        if (_context == null || _dbSet == null)
        {
            throw new InvalidOperationException("Database context is not initilized");
        }
        return await _dbSet.ToListAsync();
    }
    
    
    public Task<T> GetByIDAsync(int id)
    {
        throw new NotImplementedException();
    }

    
    public Task AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    
    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
    

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
    
}
