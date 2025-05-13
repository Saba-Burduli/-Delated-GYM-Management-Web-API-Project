using GymMembership.SERVICE.DTOs.UserModels;
using GymMembership.SERVICE.Interfaces;

namespace GymMembership.SERVICE;

public class AdminService : IAdminService
{
    public Task<List<UserModel>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }
    
    public Task<UserModel> GetUserByIdAsync(int userld)
    {
        throw new NotImplementedException();
    }
    
    public Task<UserModel> AddUserAsync(UserModel model)
    {
        throw new NotImplementedException();
    }
    
    public Task<AuthResponseModel> UpdateUserDetailsAsync(int userld, UpdateUserModel model)
    {
        throw new NotImplementedException();
    }
    
    public Task<AuthResponseModel> RemoveUserAsync(int userld)
    {
        throw new NotImplementedException();
    }
}
