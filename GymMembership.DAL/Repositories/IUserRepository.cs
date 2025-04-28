using GymMembership.DATA.Entities;
using GymMembership.DATA.Infastructures;

namespace GymMembership.DAL.Repositories;

public class IUserRepository : IBaseRepository<User>
{
    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIDAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}