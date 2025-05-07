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
        if (entity == null)
        {
            throw new NotImplementedException($"type {typeof(T).Name} is not implemented");
        }

        if (_context == null || _dbSet == null)
        {
            throw new InvalidOperationException("Database context is not initilized");
        }
        _dbSet.Update(entity);
        return _context.SaveChangesAsync();
    }
    
    
    public async Task DeleteAsync(int id)
    {
        if (_context == null || _dbSet == null)
            throw new InvalidOperationException("database context is not initilized");
        
        var user = await _context.Users.FindAsync(id);
        _context.Remove(user);
        await _context.SaveChangesAsync();
    }
    
}
