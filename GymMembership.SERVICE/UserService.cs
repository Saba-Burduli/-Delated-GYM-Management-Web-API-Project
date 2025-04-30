using GymMembership.SERVICE.DTOs.UserModels;
using GymMembership.SERVICE.Interfaces;

namespace GymMembership.SERVICE;

public class UserService : IUserService
{
    //We have to implement some methods in there
    //methods are in pdf
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