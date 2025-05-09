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
    
    public async Task<UserModel> GetUserProfileAsync(int userId)
    {
        var user = await _userRepository.GetUserProfileAsync(userId);
        if (user==null)
        {
            throw new NullReferenceException("User is null");
        }
        return new UserModel()
        {
            UserId = userId,
            UserName = user.UserName,
            Email = user.Email,
            RegistrationDate = user.RegistrationDate,
        }; //this is manual mapping.

    }//here i can use IUserRepository to get user profile.

    public async Task<AuthResponseModel> UserRegistrationAsync(int? roleld, RegisterUserModel model)
    {
        // var user = await _userRepository.UserRegistrationAsync(); //i need this method to add in IUserRepository
        throw new NotImplementedException();
    }

    public Task<AuthResponseModel> LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    }//here i need Ipasswordhash.
    
    public async Task<AuthResponseModel> UpdateUserProfileAsync(UpdateUserModel model,int userId)
    {
        var user = await _userRepository.GetByIDAsync(userId);
        if (user == null)
            return new AuthResponseModel{Success = false, Message = "User not found"};
        if (!string.IsNullOrWhiteSpace(model.UserName))
        {
            user.UserName = model.UserName;
        }

        if (!string.IsNullOrEmpty(model.Password))
        {
            return new AuthResponseModel{Success = false, Message = "Password cannot be empty"};//i have to delate this 
            // user.PasswordHash= await _passwordHash i need PasswordHasherRepo
        }
    }//here i can use IUserRepository to update user profile.
    
    public Task<AuthResponseModel> DeleteUserProfileAsync()
    {
        throw new NotImplementedException();
    }//here i can use IUserRepository to delete user profile.

    public Task<bool> AssignGymClassesAsync(List<int> gymClassIds)
    {
        throw new NotImplementedException();
    }//im gonna add GymClassRepository 
    
    public List<GymClassModel> GetGymClassesByUserAsync(int userld)
    {
        throw new NotImplementedException();
    }//im gonna add GymClassRepository 
}