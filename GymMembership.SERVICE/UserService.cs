using GymMembership.DAL.Repositories;
using GymMembership.DATA.Entities;
using GymMembership.SERVICE.DTOs.UserModels;
using GymMembership.SERVICE.Interfaces;


namespace GymMembership.SERVICE;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserService _userService;
    private readonly IGymClassRepository _gymClassRepository;
    private readonly IRoleRepository _rolesRepository;

    public UserService(IUserRepository userRepository, IUserService userService, IPasswordHasher passwordHasher, IGymClassRepository gymClassRepository,IRoleRepository rolesRepository)
    {
        _userService = userService;
        _gymClassRepository = gymClassRepository;
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _rolesRepository = rolesRepository;
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
        var existingUser = await _userRepository.GetAllUserByEmailAsync(model.Email);
        if (existingUser!=null)
        {
            return new AuthResponseModel{Success = true, Message = "User already exists"};
        }
        // we need manual mapping in there for Person Class
        
        var lastAddedUser = await _userService.UserRegistrationAsync(roleld, model);
        var roles = await _rolesRepository.GetAllAsync(); // we need rolesRepository
        return new AuthResponseModel{Success = true, Message = "User added"};
    }
    
    public Task<AuthResponseModel> LoginAsync(LoginUserModel model)
    {
        var user = _userRepository.GetAllUserByEmailAsync(model.Email);
        if (user == null)
            return Task.FromResult(new AuthResponseModel { Success = false, Message = "User not found" });
        
        return Task.FromResult(new AuthResponseModel { Success = true, Message = "User Logged in" });
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
        return await _gymClassRepository.AssignToGymClassesAsync(userId,gymClassIds);
    }
    //here i can use IUserRepository to delete user profile.
    
    public async Task<List<GymClassModel>> GetGymClassesByUserAsync(int userld)
    {
        var user = await _gymClassRepository.GetGymClassesByUserAsync(userld);
        if (user==null)
        {
            throw new NullReferenceException("User is null");
        }
        
        // return GymClassModel()
        // {
        //      //we have to add manual mapping in there
        //      //here is website link for learn manual mapping :
        //      //https://dev.to/drsimplegraffiti/manual-mapping-net-web-api-2do8
        // }
    }
    
    public async Task<UserRolesModel> GetUserWithRolesByIdAsync(int userld) //new method
    {
        var user = await _userRepository.GetUserWithRolesByIdAsync(userld);
        // return UserRolesModel()
        // {
        //     //we have to add manual mapping in there
        //     //here is website link for learn manual mapping :
        //     //https://dev.to/drsimplegraffiti/manual-mapping-net-web-api-2do8
        // }
    }
    //im gonna add GymClassRepository 
}