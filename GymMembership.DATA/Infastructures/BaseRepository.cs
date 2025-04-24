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
    
    public async Task<T> GetByIDAsync(int id)
    {
        if (_context == null || _dbSet == null)
        {
            throw new InvalidOperationException("Database context is not initilized");
        }
        return await _dbSet.FindAsync(id);
    }

    
    public async Task AddAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(entity)} is null");
        }

        if (_context == null || _dbSet == null)
        {
            throw new InvalidOperationException("Database context is not initilized");
        }
         await _dbSet.AddAsync(entity);
         await _context.SaveChangesAsync();//this is for save changes and paste it in _context class
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
