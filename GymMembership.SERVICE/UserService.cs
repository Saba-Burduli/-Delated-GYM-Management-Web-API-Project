using GymMembership.DAL.Repositories;
using GymMembership.SERVICE.DTOs.UserModels;
using GymMembership.SERVICE.Interfaces;


namespace GymMembership.SERVICE;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserService _userService;
    private readonly IGymClassRepository _GymClassRepository;

    public UserService(IUserRepository userRepository, IUserService userService, IPasswordHasher passwordHasher, IGymClassRepository gymClassRepository)
    {
        _userService = userService;
        _GymClassRepository = gymClassRepository;
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
    }

    public async Task<UserModel> GetUserProfileAsync(int userId)
    {
        var user = await _userRepository.GetUserProfileAsync(userId);
        if (user == null)
        {
            throw new NullReferenceException("User is null");
        }

        return new UserModel()
        {
            UserId = userId,
            UserName = user.UserName,
            Email = user.Email,
            RegistrationDate = user.RegistrationDate,
        };
    } 
    public async Task<AuthResponseModel> UserRegistrationAsync(int? roleld, RegisterUserModel model)
    {
        // var user = await _userRepository.UserRegistrationAsync(); //i need this method to add in IUserRepository
        throw new NotImplementedException();
    }
    
    public Task<AuthResponseModel> LoginAsync(string username, string password)
    {
        throw new NotImplementedException();
    } //here i need Ipasswordhash.

    public async Task<AuthResponseModel> UpdateUserProfileAsync(UpdateUserModel model, int userId)
    {
        var user = await _userRepository.GetByIDAsync(userId);

        if (user == null)
            return new AuthResponseModel { Success = false, Message = "User not found" };

        if (!string.IsNullOrWhiteSpace(model.UserName))
            user.UserName = model.UserName;

        if (!string.IsNullOrEmpty(model.Password))
        {
            //i have to hashpassword method in there but check dachis project
            bool verified =
                await _passwordHasher.VerifyPasswordHashAsync(user.PasswordHash,
                    model.Password); //added this by myself (and i have to check if its right)
            return new AuthResponseModel { Success = true, Message = "All good" };
        }

        return await _userService.UpdateUserProfileAsync(model, userId); //i added this by myself
    } //here i can use IUserRepository to update user profile.

    public async Task<AuthResponseModel> DeleteUserProfileAsync(int userId)
    {
        var user = await _userRepository.GetByIDAsync(userId);
        if (user == null)
            return new AuthResponseModel { Success = false, Message = "User not found" };
        
        await _userRepository.DeleteAsync(user.UserId);
        return new AuthResponseModel { Success = true, Message = "User deleted" };
    }

    public async Task<bool> AssignToGymClassesAsync(int userId,List<int> gymClassIds) //Added this methods name +To
    {
        return await _GymClassRepository.AssignToGymClassesAsync(userId,gymClassIds);
    }
    //here i can use IUserRepository to delete user profile.
    
    public List<GymClassModel> GetGymClassesByUserAsync(int userld)
    {
        throw new NotImplementedException();
    }
    
    public Task<UserRolesModel> GetUserWithRolesByIdAsync(int userld) //new method
    {
        throw new NotImplementedException();
    }
    //im gonna add GymClassRepository 
}