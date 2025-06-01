using GymMembership.DATA;
using GymMembership.DATA.Entities;
using GymMembership.DATA.Infastructures;
using Microsoft.EntityFrameworkCore;

namespace GymMembership.DAL.Repositories;

public interface IPersonRepository : IBaseRepository<Person>
{
    Task<Person> GetLastAddedUserAsync(Person PersonMapper);
}
public class PersonRepository : BaseRepository<Person> , IPersonRepository
{
    private readonly GymMembershipDbContext _context;
    
    public PersonRepository(GymMembershipDbContext context) : base(context)
    {
        
    }

    public async Task<Person> GetLastAddedUserAsync(Person person)
    {
        await _context.Persons.AddAsync(person);
        await _context.SaveChangesAsync();
        
        return await _context.Persons
            .OrderBy(e => e.PersonId)
            .LastOrDefaultAsync();
    }
}