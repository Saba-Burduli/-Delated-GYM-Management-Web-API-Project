using GymMembership.DAL.Repositories;
using GymMembership.SERVICE.DTOs.UserModels;
using GymMembership.SERVICE.Interfaces;


namespace GymMembership.SERVICE;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public Task<UserModel> GetUserProfileAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AuthResponseModel> UserRegistrationAsync(int? roleld, RegisterUserModel model)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResponseModel> LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    }
        //Lets check git 
    public Task<AuthResponseModel> UpdateUserProfileAsync(UpdateUserModel model)
    {
        throw new NotImplementedException();
    }

    
    
    public Task<AuthResponseModel> DeleteUserProfileAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> AssignGymClassesAsync(List<int> gymClassIds)
    {
        throw new NotImplementedException();
    }

    
    public List<GymClassModel> GetGymClassesByUserAsync(int userld)
    {
        throw new NotImplementedException();
    }
}