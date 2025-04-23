namespace GymMembership.DATA.Infastructures;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    public Task<IEnumerable<T>> GetAllAsync()
    { 
        throw new NotImplementedException();
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