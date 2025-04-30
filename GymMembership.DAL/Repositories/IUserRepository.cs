using GymMembership.DATA;
using GymMembership.DATA.Entities;
using GymMembership.DATA.Infastructures;
using GymMembership.SERVICE.DTOs.UserModels;

namespace GymMembership.DAL.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<UserModel> GetUserProfileAsync();
    Task<AuthResponseModel> GetAllUserByIdAsync(int userId);
    Task<User> GetAllUserByEmailAsync(string email);
    Task<AuthResponseModel> GetUserWithRolesByIdAsync(int userId);
    Task<AuthResponseModel> GetAllUserByRolesIdAsync(int roleId); // i added by myself 
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
    
    public Task<UserModel> GetUserProfileAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AuthResponseModel> GetAllUserByIdAsync(int userId)
    {
        throw new NotImplementedException();
    }
    
    public async Task<User> GetAllUserByEmailAsync(string email)
    {
        if (_context == null || _context.Users ==null)
        {
            throw new ArgumentNullException("Bridge between DataBase and Application cannot be null.. or Users cannot be null");
            //we can make this exeption shorter 
        }
        return _context.Users.FirstOrDefault(u => u.Email == email)
    }

    public Task<AuthResponseModel> GetUserWithRolesByIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResponseModel> GetAllUserByRolesIdAsync(int roleId)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResponseModel> GetAllMembersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AuthResponseModel> GetAllTrainersAsync()
    {
        throw new NotImplementedException();
    }
}
