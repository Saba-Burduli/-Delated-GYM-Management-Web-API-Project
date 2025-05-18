using GymMembership.DATA;
using GymMembership.DATA.Entities;
using GymMembership.DATA.Infastructures;
using Microsoft.EntityFrameworkCore;

namespace GymMembership.DAL.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetUserProfileAsync(int userId);
    Task<User> GetAllUserByIdAsync(int userId);
    Task<User> GetAllUserByEmailAsync(string email);
    Task<User> GetUserWithRolesByIdAsync(int userId);
    Task<User> GetAllUserByRolesIdAsync(int roleId); // i added by myself 
    Task<List<User>> GetAllMembersAsync(); //if we need to GET all members together we mush use List in Task "<>"
    Task<List<User>> GetAllTrainersAsync();//if we need to GET all members together we mush use List in Task "<>"
    
    //maybe we gonna add more methods inside this repisitory file
    // like : GetUserProfileAsync() (optional) ,UpdateUserProfileAsync() (optional), DelateUserProfileAsync() (optional)
}

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly GymMembershipDbContext _context;

    public UserRepository(GymMembershipDbContext context):base(context)
    {
        _context = context;
    }
    
    public async Task<User> GetUserProfileAsync(int userId)
    {
        if (_context.Users==null)
        {
            throw new NullReferenceException("User is null");
        }
        return await _context.Users
            .Include(u => u.Person)
            .FirstOrDefaultAsync(u => u.UserId == userId);
    }

    public async Task<User> GetAllUserByIdAsync(int userId)
    {
        if (_context.Users == null)
        {
            throw new NullReferenceException("User is null");
        }
        return await _context.Users
            .Include(u => u.Person)
            .FirstOrDefaultAsync(u => u.UserId == userId);
    }
    
    public async Task<User> GetAllUserByEmailAsync(string email)
    {
        if (_context == null || _context.Users ==null)
        {
            throw new ArgumentNullException("Bridge between DataBase and Application cannot be null.. or Users cannot be null");
            //we can make this exeption shorter 
        }

        return _context.Users.FirstOrDefault(u => u.Email == email);
    }

    public async Task<User> GetUserWithRolesByIdAsync(int userId)
    {
        //this if is just checking if User is null or not
        if (userId==null || _context.Users == null || _context.Roles == null)
        {
            throw new ArgumentNullException("Users cannot be null.");
        }
      return await _context.Users
          .Include(u=>u.Roles)
          .FirstOrDefaultAsync(u=>u.UserId == userId);
    }

    public async Task<User> GetAllUserByRolesIdAsync(int roleId)
    {
        //this if is just checking if User is null or not
        if (roleId==null || _context.Users == null || _context.Roles == null)
        {
            throw new ArgumentNullException("Users cannot be null.");
        }
        return await _context.Users
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Roles.Any(r => r.RoleId == roleId));
    }

    public async Task<List<User>> GetAllMembersAsync()
    {
        if (_context==null || _context.Users == null)
        {
            throw new NullReferenceException("Users cannot be null.");
        }
        return await _context.Users
            .Where(u => u.Roles.Any(r => r.RoleName == "Trainer"))
            .ToListAsync(); //this is how we can actually get specific data for example if
                            //we need to get only Trainers We gonna use this type of code.
    }
    
    public Task<List<User>> GetAllTrainersAsync()
    {
        if (_context==null || _context.Users == null)
        {
            throw new NullReferenceException("Users cannot be null.");
        }

        return _context.Users
            .Where(u => u.Roles.Any(r => r.RoleName == "trainer"))
            .ToListAsync();
        //this is how we can actually get specific data for example if
        //we need to get only Trainers We gonna use this type of code.
    }
}
